using BusinessLogic.Models;

namespace API.ViewModels
{
    public class UpdateExerciseResponseViewModel
    {
        private int UpdateExerciseResponseViewModelId;
        public int Number { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }


        public UpdateExerciseResponseViewModel() { }

        public UpdateExerciseResponseViewModel(int updateExerciseResponseViewModelId, int number, string name, string description)
        {
            UpdateExerciseResponseViewModelId = updateExerciseResponseViewModelId;
            Number = number;
            Name = name;
            Description = description;           
        }       
    }
}
