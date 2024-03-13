using BusinessLogic.Models;

namespace API.ViewModels
{
    public class CreateCourseViewModel
    {
        public LevelEnum Level { get; set; }

        public CreateCourseViewModel(LevelEnum level)
        {
            Level = level;
        }
    }
}

