using BusinessLogic.Models;

namespace API.ViewModels
{
    public class UpdateCourseResponseViewModel
    {
        public int UpdateCourseResponseViewModelId { get; set; }
        public LevelEnum Level { get; set; }
        public List<Exercise> ExerciseList { get; }
        public UpdateCourseResponseViewModel(int updateCourseResponseViewModelId,
            LevelEnum level, List<Exercise> exerciseList)
        {
            UpdateCourseResponseViewModelId = updateCourseResponseViewModelId;
            Level = level;
            ExerciseList = exerciseList;

        }

        public UpdateCourseResponseViewModel() { }
    }
}
