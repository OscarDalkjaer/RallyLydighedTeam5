using BusinessLogic.Models;

namespace API.ViewModels
{
    public class ExerciseViewModel
    {
        public int ExerciseId { get; set; }
        public int Number { get; set; }
        public TypeEnum? Type { get; set; }
        

        public ExerciseViewModel(int exerciseId, int number, TypeEnum? type)
        {
            ExerciseId = exerciseId;
            Number = number;
            Type = type;
        }

        public ExerciseViewModel()
        {
        }

        
    }
}

