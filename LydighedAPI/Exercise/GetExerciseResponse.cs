using Core.Domain.Entities;

namespace API.ViewModels;

public class GetExerciseResponse
{
    public required int GetExerciseId { get; init; }
    public required int Number { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required DefaultHandlingPositionEnum DefaultHandlingPosition { get; init; }
    public required bool Stationary { get; init; }
    public required bool WithCone { get; init; }
    public required JumpEnum? TypeOfJump { get; init; }
    public required LevelEnum? Level { get; init; }
    
    public static GetExerciseResponse ConvertFromExercise(Exercise exercise)
    {
        return new GetExerciseResponse
        {
            GetExerciseId = exercise.ExerciseId,
            Number = exercise.Number,
            Name = exercise.Name,
            Description = exercise.Description,
            DefaultHandlingPosition = exercise.DefaultHandlingPosition,
            Stationary = exercise.Stationary,
            WithCone = exercise.WithCone,
            TypeOfJump = exercise.TypeOfJump,
            Level = exercise.Level
        };
    }
}
