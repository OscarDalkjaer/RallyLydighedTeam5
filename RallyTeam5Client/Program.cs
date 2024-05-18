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

            builder.Services.AddTransient<CustomMessageHandler>();
            builder.Services.AddHttpClient<IRallyTeam5HttpClient, RallyTeam5HttpClient>()
                .ConfigureHttpClient(httpClient => {
                    httpClient.BaseAddress = new Uri("https://localhost:7288");// builder.HostEnvironment.BaseAddress);
                    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

                    // httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");

                });//.AddHttpMessageHandler<CustomMessageHandler>();

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            //builder.Services.AddScoped(sp =>{
            //    HttpClient httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7288") };
            //    return httpClient;
            //    });

            builder.Services.AddScoped<RallyTeam5HttpClient>();

            await builder.Build().RunAsync();
        }
    }
}

file class CustomMessageHandler: DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if(request.Method == HttpMethod.Post)
        {
            request.Content!.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        }
        return base.SendAsync(request, cancellationToken);
    }
}
