using BusinessLogic.Models;

namespace API.ViewModels
{
    public class GetCourseViewModel
    {
        public LevelEnum Level { get; set; }
        public int CourseId { get; set; }
        public List<GetExerciseViewModel> GetExerciseViewModels { get; set; }

        public GetCourseViewModel(int courseId, LevelEnum level, List<Exercise> exerciseList)
        {
            Level = level;
            CourseId = courseId;
            GetExerciseViewModels = exerciseList.Select(x => new GetExerciseViewModel(x.ExerciseId, x.Number, x.Name, 
                x.Description, x.DefaultHandlingPosition, x.Stationary, x.WithCone, x.TypeOfJump, x.Level)).ToList();
        }

        
    }
}
