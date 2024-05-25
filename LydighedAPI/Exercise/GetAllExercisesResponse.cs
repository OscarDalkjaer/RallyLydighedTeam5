using Core.Domain.Entities;

namespace API.ViewModels;

public class GetAllExercisesResponse
{
    public required List<GetExerciseResponse> Exercises { get; init; }

    public static GetAllExercisesResponse ConvertFromExercises(IEnumerable<Exercise> exercises)
    {
        return new GetAllExercisesResponse
        {
            Exercises = exercises
            .Select(exercise => GetExerciseResponse.ConvertFromExercise(exercise))
            .ToList()
        };
    }

    internal bool IsEmpty()
    {
        return Exercises.Count == 0;
    }
}