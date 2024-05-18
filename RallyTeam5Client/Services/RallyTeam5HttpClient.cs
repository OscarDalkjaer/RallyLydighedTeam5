using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;

namespace RallyTeam5Client.Services
{
    public class RallyTeam5HttpClient
    {
        public RallyTeam5HttpClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public HttpClient httpClient { get; }

        public async Task <string> Login (string username, string password)
        {
            LoginViewModel? vm = await httpClient.GetFromJsonAsync<LoginViewModel>("/login");
            return vm.AccessToken;
               }      

    }
}

file class LoginViewModel 
{
    public string AccessToken { get; set; }
}