using BusinessLogic.Models;
using System.ComponentModel.DataAnnotations;

namespace API.ViewModels
{
    public class UpdateCourseRequestViewModel
    
    {     
        public int CourseId { get; set; }
        public LevelEnum Level { get; set; }       
        public List<int> ExerciseNumbers { get; set; }
        public int JudgeId { get; set; } = 0;
        public int EventId { get; set; } = 0;
        
        public bool IsStartPositionLeftHandled { get; set; }

        public UpdateCourseRequestViewModel() { }

       
       
    }
}






