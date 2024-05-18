using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;

namespace RallyTeam5Client.Services
{
    public interface IRallyTeam5HttpClient
    {
        Task<string> Login(string username, string password);
    }

    public class RallyTeam5HttpClient : IRallyTeam5HttpClient
    {
        public RallyTeam5HttpClient(HttpClient httpClient)
        {
            try
            {
                this.httpClient = httpClient;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HttpClient httpClient { get; }

        public async Task<string> Login(string username, string password)
        {
            var json_ = JsonContent.Create(new
            {

                email = username,
                password
            });
            //var json_ = new StringContent(JsonSerializer.Serialize(new { email = username, password }), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsJsonAsync("login", json_);
            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            // LoginViewModel? vm = await httpClient.GetFromJsonAsync<LoginViewModel>("/login");
            return null!;// n vm.AccessToken;

        }

    }
}

file class LoginViewModel 
{
    public string AccessToken { get; set; }
}