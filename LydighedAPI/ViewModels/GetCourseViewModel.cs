using BusinessLogic.Models;

namespace API.ViewModels
{
    public class GetCourseViewModel
    {
        public LevelEnum Level { get; set; }
        public int CourseId { get; set; }

        public GetCourseViewModel(int courseId, LevelEnum level)
        {
            Level = level;
            CourseId = courseId;
        }

        
    }
}
