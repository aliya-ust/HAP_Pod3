using HealthCare.AdminBlazor;
using HealthCare.AdminBlazor.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"];

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(apiBaseUrl!)
});

builder.Services.AddScoped<DoctorAdminService>();
builder.Services.AddScoped<PatientAdminService>();
builder.Services.AddScoped<AppointmentAdminService>();
builder.Services.AddScoped<DashboardService>();
builder.Services.AddScoped<JwtService>();



await builder.Build().RunAsync();