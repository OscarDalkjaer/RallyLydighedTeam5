using BusinessLogic.Models;

namespace API.ViewModels
{
    public class UpdateExerciseRequestViewModel
    {
        public int UpdateExerciseRequestViewModelId { get; set; }
        public int Number { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DefaultHandlingPositionEnum DefaultHandlingPosition { get; set; }
        public bool Stationary { get; set; }
        public bool WithCone { get; set; }
        public jumpEnum? TypeOfJump { get; set; }
        public LevelEnum? Level { get; set; }


        public UpdateExerciseRequestViewModel(int updateExerciseRequestViewModelId, int number, string name, string description,
            DefaultHandlingPositionEnum defaultHandlingPosition, bool stationary, bool withCone, jumpEnum? typeOfJump, LevelEnum? level)
        {
            UpdateExerciseRequestViewModelId = updateExerciseRequestViewModelId;
            Number = number;
            Name = name;
            Description = description;
            DefaultHandlingPosition = defaultHandlingPosition;
            Stationary = stationary;
            WithCone = withCone;
            TypeOfJump = typeOfJump;
            Level = level;
        }        
    }
}
