using BusinessLogic.Models;

namespace API.ViewModels
{
    public class AddExerciseViewModel
    {
        public int Number { get; set; }
        public TypeEnum Type { get; set; }


        public AddExerciseViewModel(int number, TypeEnum type)
        {
            Number = number;
            Type = type;
        }
    }
}
