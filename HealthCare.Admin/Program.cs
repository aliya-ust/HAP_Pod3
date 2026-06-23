using HealthCare.Admin;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<NotificationService>();

builder.Services.AddScoped<ConfirmModalService>();

//// 1. Register Token Service
//builder.Services.AddScoped<TokenService>();

//// 2. Register Handler
//builder.Services.AddTransient<AuthTokenHandler>();

//// 3. Register HttpClient with the Handler
//builder.Services.AddHttpClient("AdminPortalAPI", client =>
//{
//    client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]);
//})
//.AddHttpMessageHandler<AuthTokenHandler>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
