using BusinessLogic.Models;

namespace API.ViewModels
{
    public class AddCourseResponseViewModel
    {
        public int CourseId { get; }
        public LevelEnum Level { get; }
        public List<int> ExerciseNumbers { get; private set; }
        //public List<GetExerciseViewModel> ExerciseVMList { get; } = [];
        public AddCourseResponseViewModel() { }
        //public AddCourseResponseViewModel(int courseId, LevelEnum level, List<Exercise> exerciseList)
        //{
        //    CourseId = courseId;
        //    Level = level;
        //    ExerciseVMList = exerciseList.Select(x =>
        //    {
        //        return new GetExerciseViewModel(x.ExerciseId, x.Number, x.Name, x.Description, x.DefaultHandlingPosition,
        //    x.Stationary, x.WithCone, x.TypeOfJump, x.Level);

        //    }).ToList();
        //}

        public AddCourseResponseViewModel(int courseId, LevelEnum level, List<int> exerciseNumbers) 
        {
            CourseId = courseId;
            Level = level;
            ExerciseNumbers = exerciseNumbers;
        }

        public static AddCourseResponseViewModel ConvertCourseToAddCourseResponseViewModel(Course course) 
        {
            List<int> exerciseNumbers = course.ExerciseList.Select(x => x.Number).ToList();
            var model = new AddCourseResponseViewModel(course.CourseId, course.Level, exerciseNumbers);
            return model;
        }

            

            //ExerciseList = exerciseList.Select(x =>
            //{
            //    x.CourseList.Clear();
            //    return x;
            //}).ToList();
        
        































        
    }
}
