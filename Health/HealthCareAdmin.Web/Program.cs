using HealthCareAdmin.Web;
using HealthCareAdmin.Web.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Register IHttpClientFactory
builder.Services.AddHttpClient("ApiClient", (sp, client) =>
{
    var uri = new Uri(builder.HostEnvironment.BaseAddress);
    var siteRoot = $"{uri.Scheme}://{uri.Authority}/";

    client.BaseAddress = new Uri(siteRoot);
})
.AddHttpMessageHandler<AuthMessageHandler>();

// Register HttpClient for direct injection
builder.Services.AddScoped(sp =>
{
    var factory = sp.GetRequiredService<IHttpClientFactory>();
    return factory.CreateClient("ApiClient");
});

builder.Services.AddScoped<PatientService>();
builder.Services.AddScoped<DoctorService>();
builder.Services.AddScoped<AppointmentService>();
builder.Services.AddScoped<DashboardService>();
builder.Services.AddScoped<TokenProvider>();

builder.Services.AddTransient<AuthMessageHandler>();

await builder.Build().RunAsync();