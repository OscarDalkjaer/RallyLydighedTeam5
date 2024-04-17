using BusinessLogic.Models;

namespace API.ViewModels
{
    public class UpdateExerciseViewModel
    {
        public int UpdateExerciseViewModelId { get; set; }
        public int Number { get; set; }
        public TypeEnum Type { get; set; }


        public UpdateExerciseViewModel(int number, TypeEnum type, int updateExerciseViewModelId)
        {
            Number = number;
            Type = type;
            UpdateExerciseViewModelId = updateExerciseViewModelId;
        }
    }
}
