using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace RallyTeam5Client;

public class AuthenticationManager
{
    private class AuthenticationManagerException(string? message) : Exception(message) { };
    private record LoginRequest(string Email, string Password);
    private record LoginResponse(string AccessToken);

    private readonly HttpClient httpClient;

    public AuthenticationManager(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task Login(HttpContext httpContext, string email, string password)
    {
        var accessToken = await GetAccessToken(email, password);
        ClaimsPrincipal userClaimsPrincipal = GetUserClaimsPrincipal(email, accessToken);

        await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userClaimsPrincipal);
    }

    private async Task<string> GetAccessToken(string email, string password)
    {
        JsonContent jsonContent = JsonContent.Create(new LoginRequest(email, password));
        HttpResponseMessage responseMessage = await httpClient.PostAsync("/login", jsonContent);

        if (!responseMessage.IsSuccessStatusCode)
        {
            var message = $"Login to server API failed with status code {responseMessage.StatusCode}.";
            throw new AuthenticationManagerException(message);
        }

        var loginResponse = await responseMessage.Content.ReadFromJsonAsync<LoginResponse>();
        return loginResponse?.AccessToken ?? throw new Exception("Failed reading login access token");
    }

    private ClaimsPrincipal GetUserClaimsPrincipal(string email, string accessToken)
    {
        List<Claim> claims = [new Claim(ClaimTypes.Email, email), new Claim(ClaimTypes.Authentication, accessToken)];
        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        return new ClaimsPrincipal(claimsIdentity);
    }
}
