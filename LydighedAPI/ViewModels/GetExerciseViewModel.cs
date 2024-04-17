using BusinessLogic.Models;

namespace API.ViewModels
{
    public class GetExerciseViewModel
    {
        public int GetExerciseId { get; set;} 
        public int Number { get; set; }
        public TypeEnum Type { get; set; }

        public GetExerciseViewModel(int exerciseId, int number, TypeEnum type)
        {
            GetExerciseId = exerciseId;
            Number = number;
            Type = type;
        }

        public GetExerciseViewModel()
        {
        }

    }

}
