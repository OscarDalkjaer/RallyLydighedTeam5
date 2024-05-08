using BusinessLogic.Models;

namespace API.ViewModels
{
    public class UpdateCourseResponseViewModel
    {
        public int CourseId { get; set; }
        public LevelEnum Level { get; set; }
        public List<UpdateExerciseViewModel> UpdateExerciseList { get; }
        public UpdateCourseResponseViewModel(int courseId,
            LevelEnum level, List<UpdateExerciseViewModel> updateExerciseList)
        {
            CourseId = courseId;
            Level = level;
            UpdateExerciseList = updateExerciseList;

        }

        public UpdateCourseResponseViewModel() { }
    }
}
