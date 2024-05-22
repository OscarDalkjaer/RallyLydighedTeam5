namespace RallyTeam5Client;

public class ApiEndpoints
{
    private readonly HttpClient httpClient;

    public ApiEndpoints(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    record AllExerciseResponse(IEnumerable<ExerciseResponse> Exercises);

    public async Task<IEnumerable<ExerciseResponse>> GetAllExercise()
    {
        var response = await httpClient.GetFromJsonAsync<AllExerciseResponse>("api/exercise");
        return response?.Exercises ?? [];
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
    int TypeOfJump,
    int Level
);
