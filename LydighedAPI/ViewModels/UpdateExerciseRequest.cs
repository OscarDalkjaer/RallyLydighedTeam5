using Core.Domain.Entities;

namespace API.ViewModels;

public class UpdateExerciseRequest
{
    public required int UpdateExerciseRequestViewModelId { get; init; }
    public required int Number { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required DefaultHandlingPositionEnum DefaultHandlingPosition { get; init; }
    public required bool Stationary { get; init; }
    public required bool WithCone { get; init; }
    public JumpEnum? TypeOfJump { get; init; }
    public LevelEnum? Level { get; init; }

    public Exercise ConvertToExercise()
    {
        return new Exercise(
            UpdateExerciseRequestViewModelId,
            Number,
            Name,
            Description,
            DefaultHandlingPosition,
            Stationary,
            WithCone,
            TypeOfJump,
            Level);
    }
}
