using BusinessLogic.Models;

namespace API.ViewModels
{
    public class AddCourseViewModel
    {
        public LevelEnum Level { get; set; }

        public AddCourseViewModel(LevelEnum level)
        {
            Level = level;
        }
    }
}

