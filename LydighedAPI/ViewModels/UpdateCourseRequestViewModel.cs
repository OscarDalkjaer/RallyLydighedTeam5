using API.ViewModels;
using BusinessLogic.Models;

namespace API.ViewModels
{
    public class UpdateCourseRequestViewModel
    {
        public int CourseId { get; set; }
        public LevelEnum Level { get; set; }
        public List<ExerciseViewModel> ExerciseVMList { get;  }
        public UpdateCourseRequestViewModel(int courseId, 
            LevelEnum level, List<ExerciseViewModel> exerciseVMList)
        {
            CourseId = courseId;
            Level = level;
            ExerciseVMList = exerciseVMList;

        }

        //public UpdateCourseRequestViewModel() { }
    }
}






