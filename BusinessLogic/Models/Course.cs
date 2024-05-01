using System.ComponentModel;
using System.ComponentModel.Design;

namespace BusinessLogic.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public LevelEnum Level { get; set; }

        public ICollection<Exercise> ExerciseList
        {
            get
            {
                return Relations.Select(rel => rel.Exercise).ToList();
            }
        }

        public List<CourseExerciseRelation> Relations { get; set; } = new();

        public Course(LevelEnum level)
        {
            Level = level;
        }

        public Course(int courseId, LevelEnum level, List<Exercise> exerciseList)
        {
            CourseId = courseId;
            Level = level;
            foreach (Exercise exercise in exerciseList)
                Relations.Add(new CourseExerciseRelation
                {
                    Course = this,
                    Exercise = exercise,
                });
        }

        
        
    }   
    
}
