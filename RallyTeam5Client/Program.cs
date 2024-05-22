using Microsoft.AspNetCore.Components.Authorization;
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

//builder.Services.AddCircuitServicesAccessor();
builder.Services.AddScoped<AuthenticationStateHandler>();



builder.Services.AddScoped(sp =>
{
    var httpClient = new HttpClient();
    ConfigureHttpClient(httpClient);
    return httpClient;
});

// builder.Services.AddHttpClient<ApiEndpoints>(
//         httpClient => ConfigureHttpClient(httpClient))
//         .AddHttpMessageHandler<AuthenticationStateHandler>();

// builder.Services.AddHttpClient<AuthenticationManager>(
//         httpClient => ConfigureHttpClient(httpClient))
//         .AddHttpMessageHandler<AuthenticationStateHandler>();

// builder.Services.AddHttpClient<CookieAuthenticationStateProvider>(
//         httpClient => ConfigureHttpClient(httpClient));

builder.Services.AddScoped<ApiEndpoints>();
builder.Services.AddScoped<AuthenticationManager>();
builder.Services.AddTransient<AuthenticationStateProvider, CookieAuthenticationStateProvider>();


builder.Services.AddHttpContextAccessor();

builder.Services
    .AddAuthentication()
    .AddCookie(options =>
    {
        //options.Cookie.Name = ".AspNetCore.Identity.Application";
        options.LoginPath = "/login";
        options.LogoutPath = "/logout";
    });

builder.Services.AddAuthorizationCore();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// app.UseStaticFiles();

// app.UseAuthentication();
// app.UseAuthorization();

// app.UseAntiforgery();

// app.UseHttpsRedirection();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
