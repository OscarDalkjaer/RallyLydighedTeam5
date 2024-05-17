using API.ViewModels;
using BusinessLogic.Models;

namespace API.ViewModels
{
    public class UpdateCourseRequestViewModel
    {
        public int CourseId { get; set; }
        public LevelEnum Level { get; set; }
        //public List<UpdateExerciseViewModel> UpdateExerciseVMList { get;  }

        public List<int> ExerciseNumbers { get; set; }
        //public UpdateCourseRequestViewModel(int courseId, 
        //    LevelEnum level, List<UpdateExerciseViewModel> updateExerciseVMList)
        //{
        //    CourseId = courseId;
        //    Level = level;
        //    UpdateExerciseVMList = updateExerciseVMList;

        //}

        public UpdateCourseRequestViewModel(int courseId,
            LevelEnum level, List<int> updatedExerciseNumbers)
        {
            CourseId = courseId;
            Level = level;
            ExerciseNumbers = updatedExerciseNumbers;

        }



        public UpdateCourseRequestViewModel() { }
    }
}






