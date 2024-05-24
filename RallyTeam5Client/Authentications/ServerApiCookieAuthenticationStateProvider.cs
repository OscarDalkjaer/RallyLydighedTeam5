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
        LoginRequest loginRequest = new LoginRequest(email, password);
        HttpRequestMessage requestMessage = CreateLoginHttpRequestMessage(loginRequest);

        HttpResponseMessage responseMessage = await httpClient.SendAsync(requestMessage);
        responseMessage.EnsureSuccessStatusCode();

        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    private static HttpRequestMessage CreateLoginHttpRequestMessage(LoginRequest loginRequest)
    {
        JsonContent jsonContent = JsonContent.Create(loginRequest);
        HttpRequestMessage message = new(HttpMethod.Post, "login?useCookies=true") { Content = jsonContent };
        message.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

        return message;
    }

    public async override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "manage/info");
        requestMessage.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

        HttpResponseMessage responseMessage = await httpClient.SendAsync(requestMessage);

        if (responseMessage.IsSuccessStatusCode is false) return AnonymousUser;

        UserInfo? userInfo = await responseMessage.Content.ReadFromJsonAsync<UserInfo>();
        if (userInfo is null) return AnonymousUser;

        return GetAuthenticatedUserFrom(userInfo);
    }

    private static AuthenticationState GetAuthenticatedUserFrom(UserInfo userInfo)
    {
        List<Claim> userClaims = new List<Claim>(){
            new Claim(ClaimTypes.Name, userInfo.Email),
            new Claim(ClaimTypes.Email, userInfo.Email)
        };

        ClaimsIdentity userClaimsIdentity = new(userClaims, nameof(ServerApiCookieAuthenticationStateProvider));
        ClaimsPrincipal userClaimsPrincipal = new ClaimsPrincipal(userClaimsIdentity);

        return new AuthenticationState(userClaimsPrincipal);
    }
}