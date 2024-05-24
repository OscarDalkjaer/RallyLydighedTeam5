using Core.Domain.Entities;

namespace API.ViewModels;

public class UpdateExerciseResponse
{
    public required int UpdateExerciseResponseViewModelId { get; init; }
    public required int Number { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }

    public static UpdateExerciseResponse ConvertToUpdateExerciseResponse(Exercise exercise)
    {
        return new UpdateExerciseResponse
        {
            UpdateExerciseResponseViewModelId = exercise.ExerciseId,
            Number = exercise.Number,
            Name = exercise.Name,
            Description = exercise.Description
        };
    }
}
