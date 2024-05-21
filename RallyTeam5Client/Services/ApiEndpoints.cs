namespace RallyTeam5Client;

public class ApiEndpoints
{
    private record LoginRequest(string Email, string Password);
    private record LoginResponse(string AccessToken);
    private readonly HttpClient httpClient;

    public ApiEndpoints(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }
    public async Task Login(string email, string password)
    {
        const string requestUri = "/login?useSessionCookies=true";
        JsonContent jsonContent = JsonContent.Create(new LoginRequest(email, password));

        HttpResponseMessage responseMessage = await httpClient.PostAsync(requestUri, jsonContent);
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception("Login to Server API failed");
        }
    }
}