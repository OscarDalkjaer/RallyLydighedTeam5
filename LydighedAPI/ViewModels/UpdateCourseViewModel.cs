using BusinessLogic.Models;

namespace API.ViewModels
{
    public class UpdateCourseViewModel
    {
        public int UpdatedCourseId { get; set; }
        public LevelEnum Level { get; set; }

        public UpdateCourseViewModel(int courseId, LevelEnum level)
        {
            UpdatedCourseId = courseId;
            Level = level;
        }

        public UpdateCourseViewModel() { }
    }
}

