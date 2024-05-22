using API.ViewModels;
using BusinessLogic.Models;
using BusinessLogic.Services;
using System.ComponentModel.DataAnnotations;

namespace API.ViewModels
{
    public class UpdateCourseRequestViewModel
    
    {
       

        public int CourseId { get; set; }
        public LevelEnum Level { get; set; }
        
        
        
        public List<int> ExerciseNumbers { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "DommerId skal være større end 0 ")]
        public int JudgeId { get; set; }
        public int EventId { get; set; }
        
        public bool? IsStartPositionLeftHandled { get; set; }




        public UpdateCourseRequestViewModel(int courseId,
            LevelEnum level, List<int> updatedExerciseNumbers)
        {
            CourseId = courseId;
            Level = level;
            ExerciseNumbers = updatedExerciseNumbers;
           
        }

        
       

        public UpdateCourseRequestViewModel() { }

       
       
    }
}






