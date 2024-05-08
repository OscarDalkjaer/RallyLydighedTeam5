using API.ViewModels;
using BusinessLogic.Models;

namespace API.ViewModels
{
    public class UpdateCourseRequestViewModel
    {
        public int CourseId { get; set; }
        public LevelEnum Level { get; set; }
        public List<UpdateExerciseViewModel> UpdateExerciseVMList { get;  }
        public UpdateCourseRequestViewModel(int courseId, 
            LevelEnum level, List<UpdateExerciseViewModel> updateExerciseVMList)
        {
            CourseId = courseId;
            Level = level;
            UpdateExerciseVMList = updateExerciseVMList;

        }

        //public UpdateCourseRequestViewModel() { }
    }
}






