using BusinessLogic.Models;
using System.Linq;

namespace API.ViewModels
{
    public class AddCourseResponsViewModel
    {
        public int CourseId { get; }
        public LevelEnum Level { get; }
        public List<ExerciseViewModel> ExerciseVMList { get; }
        public AddCourseResponsViewModel() { }
        public AddCourseResponsViewModel(int courseId, LevelEnum level, List<Exercise> exerciseList)
        {
            CourseId = courseId;
            Level = level;
            ExerciseVMList = exerciseList.Select(x =>
            {
                return new ExerciseViewModel(x.ExerciseId, x.Number, x.Type);
                
            }).ToList();
        }
            

            //ExerciseList = exerciseList.Select(x =>
            //{
            //    x.CourseList.Clear();
            //    return x;
            //}).ToList();
        
        































        
    }
}
