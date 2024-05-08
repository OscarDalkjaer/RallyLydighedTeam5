using BusinessLogic.Models;

namespace API.ViewModels
{
    public class AddCourseResponsViewModel
    {
        public int CourseId { get; }
        public LevelEnum Level { get; }
        public List<GetExerciseViewModel> ExerciseVMList { get; } = [];
        public AddCourseResponsViewModel() { }
        public AddCourseResponsViewModel(int courseId, LevelEnum level, List<Exercise> exerciseList)
        {
            CourseId = courseId;
            Level = level;
            ExerciseVMList = exerciseList.Select(x =>
            {
                return new GetExerciseViewModel(x.ExerciseId, x.Number, x.Name, x.Description, x.ChangeOfPosition,
            x.Stationary, x.WithCone, x.TypeOfJump, x.Level);
                
            }).ToList();
        }
            

            //ExerciseList = exerciseList.Select(x =>
            //{
            //    x.CourseList.Clear();
            //    return x;
            //}).ToList();
        
        































        
    }
}
