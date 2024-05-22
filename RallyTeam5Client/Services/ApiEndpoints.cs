using Microsoft.AspNetCore.Components.WebAssembly.Http;

namespace RallyTeam5Client;

public class ApiEndpoints
{
    private readonly HttpClient httpClient;

    public ApiEndpoints(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    record ExercisesResponse(IEnumerable<ExerciseResponse> Exercises);

    public async Task<IEnumerable<ExerciseResponse>> GetAllExercise()
    {
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get,"api/exercise");
        httpRequestMessage.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
        
        var response = await httpClient.SendAsync(httpRequestMessage);
        var res = await response.Content.ReadFromJsonAsync<ExercisesResponse>();
        return res?.Exercises ?? [];
    }
}

public record ExerciseResponse(
    int GetExerciseId,
    int Number,
    string Name,
    string Description,
    int DefaultHandlingPosition,
    bool Stationary,
    bool WithCone,
    int? TypeOfJump,
    int? Level
);
