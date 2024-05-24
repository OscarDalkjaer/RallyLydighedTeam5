using Core.Domain.Entities;

namespace API.ViewModels
{
    public class UpdateExerciseRequest
    {
        public required int UpdateExerciseRequestViewModelId { get; set; }
        public required int Number { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required DefaultHandlingPositionEnum DefaultHandlingPosition { get; set; }
        public required bool Stationary { get; set; }
        public required bool WithCone { get; set; }
        public JumpEnum? TypeOfJump { get; set; }
        public LevelEnum? Level { get; set; }
    }
}
