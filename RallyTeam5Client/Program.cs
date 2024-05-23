using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RallyTeam5Client;
using RallyTeam5Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri("https://localhost:7288/") });

builder.Services.AddScoped<ServerApiCookieAuthenticationStateProvider>();

builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<ServerApiCookieAuthenticationStateProvider>());
builder.Services.AddScoped<IUserManager>(sp => sp.GetRequiredService<ServerApiCookieAuthenticationStateProvider>());

builder.Services.AddScoped<ApiEndpoints>();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();