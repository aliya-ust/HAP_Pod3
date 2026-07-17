using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using HealthCare.Admin.Services;
namespace HealthCare.Admin
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7234/") });
            builder.Services.AddScoped<PatientService>();
            builder.Services.AddScoped<DoctorService>();
            builder.Services.AddScoped<AppointmentService>();
            builder.Services.AddScoped<AuthHeaderService>();

            await builder.Build().RunAsync();
          
        }
    }
}
