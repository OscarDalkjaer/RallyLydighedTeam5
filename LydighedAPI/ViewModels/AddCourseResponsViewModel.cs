using BusinessLogic.Models;

namespace API.ViewModels
{
    public class AddCourseResponsViewModel
    {
        public AddCourseResponsViewModel() { }
        public AddCourseResponsViewModel(int AddCourseResponsVMId, LevelEnum level, List<Exercise> exerciseList) 
        {
            this.AddCourseResponsVMId = AddCourseResponsVMId;
            Level = level;
            ExerciseList = exerciseList;
        }

        public int AddCourseResponsVMId { get; }
        public LevelEnum Level { get; }
        public List<Exercise> ExerciseList { get; }
    }
}
