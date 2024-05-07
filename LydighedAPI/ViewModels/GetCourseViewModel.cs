using BusinessLogic.Models;

namespace API.ViewModels
{
    public class GetCourseViewModel
    {
        public LevelEnum Level { get; set; }
        public int CourseId { get; set; }
        public List<ExerciseViewModel> ExerciseViewModels { get; set; }

        public GetCourseViewModel(int courseId, LevelEnum level, List<Exercise> exerciseList)
        {
            Level = level;
            CourseId = courseId;
            ExerciseViewModels = exerciseList.Select(x => new ExerciseViewModel(x.ExerciseId, x.Number, x.Type)).ToList();
        }

        
    }
}
