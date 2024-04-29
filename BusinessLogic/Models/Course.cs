using System.ComponentModel.Design;

namespace BusinessLogic.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public LevelEnum Level { get; set; }

        public List<Exercise> ExerciseList { get; set; }

        public Course(LevelEnum level)
        {
            Level = level;
            ExerciseList = new List<Exercise>();
            
        }

        public Course(int courseId, LevelEnum level)
        {
            CourseId = courseId;
            Level = level;
        }

        
        
    }   
    
}
