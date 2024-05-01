using BusinessLogic.Models;

namespace API.ViewModels
{
    public class UpdateCourseResponseViewModel
    {
        public int CourseId { get; set; }
        public LevelEnum Level { get; set; }
        public List<ExerciseViewModel> ExerciseList { get; }
        public UpdateCourseResponseViewModel(int courseId,
            LevelEnum level, List<ExerciseViewModel> exerciseList)
        {
            CourseId = courseId;
            Level = level;
            ExerciseList = exerciseList;

        }

        public UpdateCourseResponseViewModel() { }
    }
}
