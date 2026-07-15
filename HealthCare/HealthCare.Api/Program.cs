using HealthCare.Api.Data;
using HealthCare.Api.Mapping;
using HealthCare.Api.Middleware;
using HealthCare.Api.Repositories.Implementations;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Impl;
using HealthCare.Api.Services.Implementations;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using System.Security.Claims;
using System.Text;
using Serilog;
using MassTransit;
using HealthCare.Api.Consumers;
using HealthCare.Api.Options;


Log.Logger = new LoggerConfiguration()
    .WriteTo.Console().CreateBootstrapLogger();
Log.Information("HealthCare App Api Starting....");
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSerilog(
    (services, Configuration) => 
         Configuration.ReadFrom.Configuration(builder.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext()
);

// Add services to the container.
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy =
            System.Text.Json.JsonNamingPolicy.CamelCase;
    });

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingProfile>();
});

builder.Services.AddDbContext<HealthCareDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HealthCareDbConnection"))
);

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
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
            Console.WriteLine($"JWT Error: {context.Exception.Message}");
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
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IHealthRecordService, HealthRecordService>();
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<AppointmentBookedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(
            builder.Configuration["RabbitMq:HostName"],
            ushort.Parse(builder.Configuration["RabbitMq:Port"]!),
            builder.Configuration["RabbitMq:VirtualHost"],
            h =>
            {
                h.Username(
                    builder.Configuration["RabbitMq:UserName"]!);

                h.Password(
                    builder.Configuration["RabbitMq:Password"]!);
            });

        cfg.ReceiveEndpoint(
            builder.Configuration["RabbitMq:HealthCareQueue"]!,
            e =>
            {
                //attach consumer to the queue
                e.ConfigureConsumer<
                    AppointmentBookedConsumer>(
                        context);
            });
    });
});
builder.Services.Configure<GarnetOptions>(builder.Configuration.GetSection("Garnet"));
builder.Services.AddStackExchangeRedisCache(option =>
{
    var garnetOptions = builder.Configuration.GetSection("Garnet").Get<GarnetOptions>() ?? new GarnetOptions();
    option.Configuration = garnetOptions.ConnectionString;
    option.InstanceName = garnetOptions.InstanceName;
});

var allowedOrigins = builder.Configuration
    .GetSection("Cors:AllowedOrigins")
    .Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllClients", policy =>
    {
        policy.WithOrigins(allowedOrigins ?? Array.Empty<string>())
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
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

var app = builder.Build();
app.UseSerilogRequestLogging();
app.UseExceptionHandler();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
    var config = services.GetRequiredService<IConfiguration>();

    await RoleSeeder.SeedRolesAsync(roleManager);
    await UserSeeder.SeedAdminAsync(userManager, roleManager, config);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAllClients");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await app.RunAsync();