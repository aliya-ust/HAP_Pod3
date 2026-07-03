using HealthCare.Admin;
using HealthCare.Admin.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<ToastService>();

builder.Services.AddScoped<ConfirmModalService>();
builder.Services.AddScoped<DashboardService>();
builder.Services.AddScoped<DoctorService>();
builder.Services.AddScoped<PatientService>();
builder.Services.AddScoped<AppointmentService>();

//// 1. Register Token Service
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<AuthService>();

//// 2. Register Handler
builder.Services.AddTransient<AuthTokenHandler>();
builder.Services.AddTransient<GlobalExceptionHandler>();
builder.Services.AddTransient<TestAuthStateProvider>();

//// 3. Register HttpClient with the Handler
builder.Services.AddHttpClient("AdminPortalAPI", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]!);
})
.AddHttpMessageHandler<AuthTokenHandler>()
.AddHttpMessageHandler<GlobalExceptionHandler>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]!) });

await builder.Build().RunAsync();
