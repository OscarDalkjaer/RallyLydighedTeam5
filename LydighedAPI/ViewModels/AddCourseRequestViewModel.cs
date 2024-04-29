using BusinessLogic.Models;

namespace API.ViewModels
{
    public class AddCourseRequestViewModel
    {
        public LevelEnum Level { get; set; }

        public AddCourseRequestViewModel(LevelEnum level)
        {
            Level = level;
        }
    }
}

