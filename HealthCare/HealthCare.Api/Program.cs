using HealthCare.Api.Consumers;
using HealthCare.Api.Data;
using HealthCare.Api.Mapping;

using HealthCare.Api.Middleware;
using HealthCare.Api.Models;
using HealthCare.Api.Options;
using HealthCare.Api.Repositories.Implementations;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Implementations;
using HealthCare.Api.Services.Interfaces;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Serilog;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddControllers();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingProfile>();
});

builder.Services.AddDbContext<HealthCareDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;
})
.AddEntityFrameworkStores<HealthCareDbContext>()
.AddDefaultTokenProviders();

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
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwt["Key"]!)
        ),

        RoleClaimType = ClaimTypes.Role,
        NameClaimType = ClaimTypes.NameIdentifier,

        ClockSkew = TimeSpan.Zero
    };
});

// Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IHealthRecordRepository, HealthRecordRepository>();

// Services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IHealthRecordService, HealthRecordService>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<AppointmentBookedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        var rabbitMq = builder.Configuration.GetSection("RabbitMQ");

        var hostName = rabbitMq["HostName"] ?? "localhost";
        var virtualHost = rabbitMq["VirtualHost"] ?? "/";
        var userName = rabbitMq["UserName"] ?? "guest";
        var password = rabbitMq["Password"] ?? "guest";
        var appointmentQueue = rabbitMq["AppointmentQueue"] ?? "appointment.events.queue";

        cfg.Host(hostName, virtualHost, h =>
        {
            h.Username(userName);
            h.Password(password);
        });

        cfg.ReceiveEndpoint(appointmentQueue, e =>
        {
            e.ConfigureConsumer<AppointmentBookedConsumer>(context);
        });
    });
});
builder.Services.Configure<GarnetOptions>(builder.Configuration.GetSection("Garnet"));


builder.Services.AddStackExchangeRedisCache(option => {


    var garnetOptions = builder.Configuration.GetSection("Garnet").Get<GarnetOptions>() ?? new GarnetOptions();


    option.Configuration = garnetOptions.ConnectionString;

    option.InstanceName = garnetOptions.InstanceName;

});




builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowClients", policy =>
    {
        policy
            .WithOrigins(
                "https://localhost:7058",
                "http://localhost:59971"
            )
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

app.UseExceptionHandler();

// Logs every API request: method, path, status
app.Use(async (context, next) =>
{
    await next();

    Log.Information(
        "API Request: {Method} {Path} responded {StatusCode}",
        context.Request.Method,
        context.Request.Path,
        context.Response.StatusCode
    );
});

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<User>>();

    await RoleSeeder.SeedRolesAsync(roleManager);
    await AdminSeeder.SeedAdminAsync(userManager, roleManager);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowClients");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

try
{
    await app.RunAsync();
}
finally
{
    Log.CloseAndFlush();
}