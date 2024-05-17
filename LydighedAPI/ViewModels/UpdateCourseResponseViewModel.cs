using BusinessLogic.Models;

namespace API.ViewModels
{
    public class UpdateCourseResponseViewModel
    {
        public int CourseId { get; set; }
        public LevelEnum Level { get; set; }
        public List<UpdateExerciseViewModel> UpdateExerciseVMList { get; set; }
        public UpdateCourseResponseViewModel(int courseId,
            LevelEnum level, List<UpdateExerciseViewModel> updateExerciseVMList)
        {
            CourseId = courseId;
            Level = level;
            UpdateExerciseVMList = updateExerciseVMList;

        }

        public UpdateCourseResponseViewModel() { }
    }
}
