

using HealthCare.Api.Data;
using HealthCare.Api.Mapping;
using HealthCare.Api.Middleware;
using HealthCare.Api.Repositories.Implementations;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Implementations;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;

namespace HealthCare.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                });
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<HealthCareDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            // IDENTITY CONFIGURATION 

            // ========================================== 



            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>

            {

                // Require unique email addresses 

                options.User.RequireUniqueEmail = true;



                // Optional: Password requirements 

                 options.Password.RequireDigit = true; 

                 options.Password.RequireLowercase = true; 

                 options.Password.RequireUppercase = true; 

                options.Password.RequireNonAlphanumeric = true; 

                 options.Password.RequiredLength = 8; 

            })

            .AddEntityFrameworkStores<HealthCareDbContext>()  // Use EF Core for storage 

            .AddDefaultTokenProviders();               // Add token providers for password reset, etc. 


            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)

                .AddJwtBearer(options =>

                {

                    // Get JWT settings from appsettings.json 

                    var jwt = builder.Configuration.GetSection("jwt");



                    options.TokenValidationParameters = new TokenValidationParameters

                    {

                        // Validate the token was issued by your application 

                        ValidateIssuer = true, 

                        ValidIssuer = jwt["Issuer"],



                        // Validate the token is intended for your application 

                        ValidateAudience = true,

                        ValidAudience = jwt["Audience"],



                        // Validate the token hasn't expired 

                        ValidateLifetime = true,



                        // Validate the token signature is correct 

                        ValidateIssuerSigningKey = true,

                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]!)),



                        // Remove default 5-minute grace period for expiration 

                        ClockSkew = TimeSpan.Zero

                    };

                });

            //Exception Handler
            builder.Services.AddProblemDetails();
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();





            // Repositories
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IPatientRepository, PatientRepository>();
            builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
            builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            builder.Services.AddScoped<IHealthRecordRepository, HealthRecordRepository>();

            // Services
            builder.Services.AddScoped<IPatientService, PatientService>();
            builder.Services.AddScoped<IDoctorService, DoctorService>();
            builder.Services.AddScoped<IAppointmentService, AppointmentService>();
            builder.Services.AddScoped<IHealthRecordService, HealthRecordService>();
            builder.Services.AddScoped<IAuthService, AuthService>();  // Register auth service
            // AUTOMAPPER CONFIGURATION
            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MappingProfile>();

            });

            // BUILD APPLICATION 

            // ========================================== 



            var app = builder.Build();
            app.UseExceptionHandler();



            // ========================================== 

            // SEED ROLES ON STARTUP 

            // ========================================== 



            using (var scope = app.Services.CreateScope())

            {

                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                await RoleSeeder.SeedRolesAsync(roleManager);

            } 


            // MIDDLEWARE PIPELINE 
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();
            
 

            app.Run();
        }
    }
}
