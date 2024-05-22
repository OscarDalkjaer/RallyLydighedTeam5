using Microsoft.AspNetCore.Authentication.Cookies;
using RallyTeam5Client;
using RallyTeam5Client.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddCascadingAuthenticationState();

Action<HttpClient> ConfigureHttpClient = (httpClient) =>
    {
        httpClient.BaseAddress = new Uri("https://localhost:7288");
        httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
    };

builder.Services.AddHttpClient<ApiEndpoints>(
        httpClient => ConfigureHttpClient(httpClient));

builder.Services.AddHttpClient<AuthenticationManager>(
        httpClient => ConfigureHttpClient(httpClient));

builder.Services.AddHttpContextAccessor();

builder.Services
    .AddAuthentication()
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
        options.LogoutPath = "/logout";
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.UseHttpsRedirection();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
