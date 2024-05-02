using System.ComponentModel;
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
        }

        public Course(int courseId, LevelEnum level)
        {
            CourseId = courseId;
            Level = level;
            ExerciseList = new List<Exercise>();
            //foreach (Exercise exercise in exerciseList)
            //    Relations.Add(new CourseExerciseRelation
            //    {
            //        Course = this,
            //        Exercise = exercise,
            //    });
        }

        public int GetMaxLengthOfExerciseList(LevelEnum level) 
        {
            switch (level) 
            {
                case LevelEnum.Beginner:
                    return 15;
                    break;
                case LevelEnum.Advanced:
                    return 17;
                    break;
                case LevelEnum.Expert:
                    return 20;
                    break;
                case LevelEnum.Champion:
                    return 20;
                    break;
                case LevelEnum.OpenClass:
                    return 18;
                    break;
                default:
                    return 0;
                    break;
            }
        }

        //public ICollection<Exercise> ExerciseList
        //{
        //    get
        //    {
        //        return Relations.Select(rel => rel.Exercise).ToList();
        //    }
        //}

        //public List<CourseExerciseRelation> Relations { get; set; } = new();

        for (int i = 1; i <= 15; i++)
                    {
                        course.Relations.Add(new CourseExerciseRelation
                        {
                            Course = course,
                            Exercise = nullExercise
    });
                    }



    }   
    
}
