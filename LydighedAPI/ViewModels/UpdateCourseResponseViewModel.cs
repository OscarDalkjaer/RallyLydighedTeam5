using BusinessLogic.Models;

namespace API.ViewModels
{
    public class UpdateCourseResponseViewModel
    {
        public int CourseId { get; set; }
        public LevelEnum Level { get; set; }
        public List<UpdateExerciseResponseViewModel> UpdateExerciseVMList { get; set; }
        public List<string> status { get; set; }


        public UpdateCourseResponseViewModel(int courseId,
            LevelEnum level, List<UpdateExerciseResponseViewModel> updateExerciseVMList, List<string> status)
        {
            CourseId = courseId;
            Level = level;
            UpdateExerciseVMList = updateExerciseVMList;
            this.status = status;
        }

        public UpdateCourseResponseViewModel() { }
    }
}
