using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;

namespace RallyTeam5Client.Services;

public class RallyTeam5HttpClient
{
    public HttpClient httpClient { get; }

    public RallyTeam5HttpClient(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    record LoginRequest(string Email, string Password);
    record LoginResponse(string AccessToken);

    public async Task<string> Login(string username, string password)
    {
        HttpResponseMessage httpResponseMessage = await httpClient.PostAsJsonAsync(
            requestUri: "login",
            value: new LoginRequest(username, password)
        );

        httpResponseMessage.EnsureSuccessStatusCode();

        LoginResponse? loginResponse = await httpResponseMessage.Content.ReadFromJsonAsync<LoginResponse>();
        return loginResponse is not null
            ? loginResponse.AccessToken
            : throw new Exception("Loginresponse is null");
    }
}

file class LoginViewModel
{
public string AccessToken { get; set; }
}