using API.ViewModels;
using BusinessLogic.Models;

namespace API.ViewModels
{
    public class UpdateCourseRequestViewModel
    {
        public int UpdateCourseRequestViewModelId { get; set; }
        public LevelEnum Level { get; set; }
        public List<Exercise> ExerciseList { get; }
        public UpdateCourseRequestViewModel(int updateCourseRequestViewModelId, 
            LevelEnum level, List<Exercise> exerciseList)
        {
            UpdateCourseRequestViewModelId = updateCourseRequestViewModelId;
            Level = level;
            ExerciseList = exerciseList;

        }

        //public UpdateCourseRequestViewModel() { }
    }
}




