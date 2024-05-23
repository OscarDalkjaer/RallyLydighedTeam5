using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System.Net.Http.Json;
using System.Security.Claims;

namespace RallyTeam5Client.Services;

public interface IUserManager
{
    Task Login(string email, string password);
}

public class ServerApiCookieAuthenticationStateProvider
    : AuthenticationStateProvider, IUserManager
{
    private record LoginRequest(string Email, string Password);
    private record UserInfo(string Email);

    private class ServerApiCookieAuthenticationException(string message) : Exception(message)
    { }

    private readonly HttpClient httpClient;

    public ServerApiCookieAuthenticationStateProvider(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task Login(string email, string password)
    {
        HttpRequestMessage httpRequestMessage = new(HttpMethod.Post, "login?useCookies=true")
        {
            Content = JsonContent.Create(new LoginRequest(email, password))
        };
        httpRequestMessage.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

        var userResponse = await httpClient.SendAsync(httpRequestMessage);

        if (userResponse.IsSuccessStatusCode)
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }

    public async override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        HttpRequestMessage request = new(HttpMethod.Get, "manage/info");
        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

        HttpResponseMessage response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        UserInfo? userInfo = await response.Content.ReadFromJsonAsync<UserInfo>();
        return userInfo is null
            ? throw new ServerApiCookieAuthenticationException("Something went wrong!")
            : GetUserAuthenticationState(userInfo);
    }

    private static AuthenticationState GetUserAuthenticationState(UserInfo userInfo)
    {
        List<Claim> claims = [new(ClaimTypes.Email, userInfo.Email)];
        ClaimsIdentity claimsIdentity = new(claims, nameof(ServerApiCookieAuthenticationStateProvider));
        ClaimsPrincipal userClaimsPrincipal = new(claimsIdentity);
        return new AuthenticationState(userClaimsPrincipal);
    }
}