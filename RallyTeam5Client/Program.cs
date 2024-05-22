using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RallyTeam5Client.Services;

namespace RallyTeam5Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            // builder.Services.AddHttpClient<RallyTeam5HttpClient>()
            //     .ConfigureHttpClient(httpClient => {
            //         httpClient.BaseAddress = new Uri("https://localhost:7288");// builder.HostEnvironment.BaseAddress);
            //         httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            //         // httpClient.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", "https://localhost:7288");
            //     });


            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7288/") });
            builder.Services.AddScoped<AuthenticationStateProvider, CookieAuthenticationStateProvider>();
                
            await builder.Build().RunAsync();
        }
    }
}