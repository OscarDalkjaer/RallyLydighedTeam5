using BusinessLogic.Models;

namespace API.ViewModels
{
    public class GetExerciseViewModel
    {
        public int GetExerciseId { get; set;}
        public int Number { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool ChangeOfPosition { get; private set; }
        public bool Stationary { get; private set; }
        public bool WithCone { get; private set; }
        public jumpEnum? TypeOfJump { get; private set; }
        public LevelEnum? Level { get; private set; }
        

        public GetExerciseViewModel(int exerciseId, int number, string name, string description,
            bool changeOfPosition, bool stationary, bool withCone, jumpEnum? typeOfJump, LevelEnum? level)
        {
            GetExerciseId = exerciseId;
            Number = number;
            Name = name;
            Description = description;
            ChangeOfPosition = changeOfPosition;
            Stationary = stationary;
            WithCone = withCone;
            TypeOfJump = typeOfJump;
            Level = level;

        }

        

        public GetExerciseViewModel()
        {
        }

    }

}
