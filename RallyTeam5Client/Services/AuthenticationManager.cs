using System.Net.Http.Headers;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;

namespace RallyTeam5Client;

public class AuthenticationManager : AuthenticationStateProvider
{
    private class AuthenticationManagerException(string? message) : Exception(message) { };
    private record LoginRequest(string Email, string Password);
    private record LoginResponse(string AccessToken);

    private readonly HttpClient httpClient;

    public AuthenticationManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    private ClaimsPrincipal UserClaimsPrincipal = new ClaimsPrincipal();

    public async Task Login(HttpContext httpContext, string email, string password)
    {
        var accessToken = await GetAccessToken(email, password);
        UserClaimsPrincipal = GetUserClaimsPrincipal(email, accessToken);
        await GetAuthenticationStateAsync();
        //await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userClaimsPrincipal);
    }

    private async Task<string> GetAccessToken(string email, string password)
    {
        JsonContent jsonContent = JsonContent.Create(new LoginRequest(email, password));

        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "/login?useCookies=true") { Content = jsonContent };
        httpRequestMessage.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
        httpRequestMessage.SetBrowserRequestMode(BrowserRequestMode.Cors);

        HttpResponseMessage responseMessage = await httpClient.SendAsync(httpRequestMessage);//.PostAsync("/login?useCookies=true", jsonContent);

        if (!responseMessage.IsSuccessStatusCode)
        {
            var message = $"Login to server API failed with status code {responseMessage.StatusCode}.";
            throw new AuthenticationManagerException(message);
        }

        //var loginResponse = await responseMessage.Content.ReadFromJsonAsync<LoginResponse>();
        return "";// loginResponse?.AccessToken ?? throw new Exception("Failed reading login access token");
    }

    private ClaimsPrincipal GetUserClaimsPrincipal(string email, string accessToken)
    {
        List<Claim> claims = [new Claim(ClaimTypes.Email, email)];//, new Claim(ClaimTypes.Authentication, accessToken)];
        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        return new ClaimsPrincipal(claimsIdentity);
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        return Task.FromResult(new AuthenticationState(UserClaimsPrincipal));
    }
}


public class AuthenticationStateHandler : DelegatingHandler
{
    private readonly IServiceProvider serviceProvider;

    public AuthenticationStateHandler(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        ClaimsPrincipal user = GetUserClaimsPrincipal();

        if (user.Identity is not null && user.Identity.IsAuthenticated)
        {
            var authenticationClaim = user.Identities.First().Claims.SingleOrDefault(c => c.Type == ClaimTypes.Authentication);
            if (authenticationClaim is not null)
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authenticationClaim.Value);
        }

        request.SetBrowserRequestMode(BrowserRequestMode.Cors);
        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
        request.Headers.Add("X-Requested-With", ["XMLHttpRequest"]);

        return await base.SendAsync(request, cancellationToken);
    }

    private ClaimsPrincipal GetUserClaimsPrincipal()
    {
        var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
        ArgumentNullException.ThrowIfNull(httpContextAccessor.HttpContext);

        return httpContextAccessor.HttpContext.User;
    }
}