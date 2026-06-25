using HealthCare.AdminBlazor;
using HealthCare.AdminBlazor.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7149")
});

builder.Services.AddScoped<DoctorAdminService>();
builder.Services.AddScoped<PatientAdminService>();
builder.Services.AddScoped<AppointmentAdminService>();
builder.Services.AddScoped<DashboardService>();
builder.Services.AddScoped<JwtService>();



await builder.Build().RunAsync();