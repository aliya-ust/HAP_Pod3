using HealthCare.Api.BackgroundServices;
using HealthCare.Api.Consumers;
using HealthCare.Api.Data;
using HealthCare.Api.Mapping;
using HealthCare.Api.Middleware;
using HealthCare.Api.Models;
using HealthCare.Shared.Events;
using MassTransit;
using HealthCare.Api.Repositories.Implementations;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Implementations;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingProfile>();
});

builder.Services.AddCors(p =>
{
    p.AddPolicy("CorsPolicy", cfg =>
    {
        var origins = builder.Configuration.GetValue<string>("Cors:AllowedOrigins")
            ?? "https://localhost:7166,http://localhost:4200";
        cfg.WithOrigins(origins.Split(',', StringSplitOptions.TrimEntries))
           .AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddProblemDetails();
builder.Services.AddControllers();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddDbContext<HealthCareDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Default")
        ?? builder.Configuration.GetConnectionString("HealthCareDbConnection"))
);

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<HealthCareDbContext>().AddDefaultTokenProviders();
    
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(option =>
{
    var jwt = builder.Configuration.GetSection("Jwt");
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = jwt["Issuer"],
        ValidateAudience = true,
        ValidAudience = jwt["Audience"],
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]!)),

        RoleClaimType = ClaimTypes.Role,
        NameClaimType = ClaimTypes.NameIdentifier,

        ClockSkew = TimeSpan.Zero
    };
    option.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            return Task.CompletedTask;
        }
    };
});

// Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IHealthRecordRepository, HealthRecordRepository>();

// Services
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IDoctorService>(sp =>
{
    var ttl = sp.GetRequiredService<IConfiguration>().GetValue<int>("Cache:TtlMinutes", 5);
    return new DoctorService(
        sp.GetRequiredService<IDoctorRepository>(),
        sp.GetRequiredService<IAppointmentRepository>(),
        sp.GetRequiredService<IMapper>(),
        sp.GetRequiredService<UserManager<User>>(),
        sp.GetRequiredService<IDistributedCache>(),
        sp.GetRequiredService<ILogger<DoctorService>>(),
        ttl);
});
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IHealthRecordService, HealthRecordService>();

// Background Services
builder.Services.AddHostedService<HeartbeatService>();
builder.Services.AddHostedService<NotificationCleanupService>();

// Cache (Redis)
var redisConnection = builder.Configuration.GetValue<string>("Redis:ConnectionString");
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSingleton<GarnetHostedService>();
    builder.Services.AddHostedService(sp => sp.GetRequiredService<GarnetHostedService>());
    builder.Services.AddStackExchangeRedisCache(options =>
        options.Configuration = redisConnection ?? "localhost:3278");
}
else if (!string.IsNullOrEmpty(redisConnection))
{
    builder.Services.AddStackExchangeRedisCache(options =>
        options.Configuration = redisConnection);
}

// MassTransit + RabbitMQ
var rabbitHost = builder.Configuration.GetValue<string>("RabbitMq:Host");
if (!string.IsNullOrEmpty(rabbitHost))
{
    builder.Services.AddMassTransit(x =>
    {
        x.AddConsumer<AppointmentBookedConsumer>();

        x.UsingRabbitMq((context, cfg) =>
        {
            cfg.Host(rabbitHost, h =>
            {
                h.Username(builder.Configuration.GetValue<string>("RabbitMq:Username") ?? "guest");
                h.Password(builder.Configuration.GetValue<string>("RabbitMq:Password") ?? "guest");
            });

            cfg.ConfigureEndpoints(context);
        });
    });
}

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "HealthApp API",
        Version = "v1"
    });

    options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Description = "Enter JWT token only. Do not type Bearer."
    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("bearer", document)] = []
    });
});

builder.Services.AddAuthorization();

// Serilog
builder.Host.UseSerilog((context, config) =>
{
    config.MinimumLevel.Information()
          .WriteTo.Console()
          .WriteTo.File("logs/healthcare-.log", rollingInterval: RollingInterval.Day);

    if (context.HostingEnvironment.IsDevelopment())
    {
        config.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(
            new Uri(context.Configuration["Elasticsearch:Uri"] ?? "http://localhost:9200"))
        {
            IndexFormat = "healthcare-logs-{0:yyyy.MM.dd}",
            AutoRegisterTemplate = true,
            NumberOfShards = 1,
            NumberOfReplicas = 0
        });
    }

    config.Enrich.FromLogContext();
});

var app = builder.Build();
app.UseSerilogRequestLogging();
app.UseExceptionHandler();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<User>>();
    var config = services.GetRequiredService<IConfiguration>();

    var dbContext = services.GetRequiredService<HealthCareDbContext>();
    await dbContext.Database.EnsureCreatedAsync();

    await RoleSeeder.SeedRolesAsync(roleManager);
    await UserSeeder.SeedAdminAsync(userManager, roleManager, config);
    await DataSeeder.SeedTestDataAsync(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}
app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapGet("/health", () => Results.Ok("Healthy"));

await app.RunAsync();
