using BusinessLogic.Models;

namespace API.ViewModels
{
    public class GetExerciseViewModel
    {
        public int ExerciseId { get; set;} 
        public int Number { get; set; }
        public TypeEnum Type { get; set; }

        public GetExerciseViewModel(int exerciseId, int number, TypeEnum type)
        {
            ExerciseId = exerciseId;
            Number = number;
            Type = type;
        }

        public GetExerciseViewModel()
        {
        }

    }

}
