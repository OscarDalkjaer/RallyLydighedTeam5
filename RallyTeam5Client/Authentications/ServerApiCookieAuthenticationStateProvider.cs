using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System.Net.Http.Json;
using System.Security.Claims;

namespace RallyTeam5Client.Services;

public interface IUserManager
{
    Task Login(string email, string password);
}

public class ServerApiCookieAuthenticationStateProvider : AuthenticationStateProvider, IUserManager
{
    private static readonly AuthenticationState AnonymousUser = new AuthenticationState(new ClaimsPrincipal());
    private record LoginRequest(string Email, string Password);
    private record UserInfo(string Email);
    private readonly HttpClient httpClient;

    public ServerApiCookieAuthenticationStateProvider(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task Login(string email, string password)
    {
        HttpRequestMessage message = CreateLoginHttpRequestMessage(email, password);

        var response = await httpClient.SendAsync(message);
        response.EnsureSuccessStatusCode();

        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    private static HttpRequestMessage CreateLoginHttpRequestMessage(string email, string password)
    {
        JsonContent jsonContent = JsonContent.Create(new LoginRequest(email, password));
        HttpRequestMessage message = new(HttpMethod.Post, "login?useCookies=true") { Content = jsonContent };
        message.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

        return message;
    }

    public async override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "manage/info");
        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

        HttpResponseMessage response = await httpClient.SendAsync(request);

        if (response.IsSuccessStatusCode is false) return AnonymousUser;

        UserInfo? userInfo = await response.Content.ReadFromJsonAsync<UserInfo>();
        if (userInfo is null) return AnonymousUser;

        return TryGetAuthenticatedUserFrom(userInfo);
    }

    private static AuthenticationState TryGetAuthenticatedUserFrom(UserInfo userInfo)
    {
        List<Claim> claims = new List<Claim>(){
            new Claim(ClaimTypes.Name, userInfo.Email),
            new Claim(ClaimTypes.Email, userInfo.Email)
        };

        ClaimsIdentity claimsIdentity = new(claims, nameof(ServerApiCookieAuthenticationStateProvider));
        ClaimsPrincipal userClaimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        return new AuthenticationState(userClaimsPrincipal);
    }
}