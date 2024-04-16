using BusinessLogic.Models;

namespace API.ViewModels
{
    public class CreateExerciseViewModel
    {
        public int Number { get; set; }
        public TypeEnum Type { get; set; }


        public CreateExerciseViewModel(int number, TypeEnum type)
        {
            Number = number;
            Type = type;
        }
    }
}
