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

//// 3. Build API base URI (support absolute URL in config or relative resolved against app origin)
var apiBaseUrl = builder.Configuration["ApiBaseUrl"]!;
var apiBaseUri = apiBaseUrl.StartsWith("http")
    ? new Uri(apiBaseUrl)
    : new Uri(new Uri(builder.HostEnvironment.BaseAddress), apiBaseUrl);

//// 4. Register HttpClient with the Handler
builder.Services.AddHttpClient("AdminPortalAPI", client =>
{
    client.BaseAddress = apiBaseUri;
})
.AddHttpMessageHandler<AuthTokenHandler>()
.AddHttpMessageHandler<GlobalExceptionHandler>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = apiBaseUri });

await builder.Build().RunAsync();
