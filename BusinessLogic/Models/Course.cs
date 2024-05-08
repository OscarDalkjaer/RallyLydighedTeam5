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
            ExerciseList = new List<Exercise>();
        }

        public Course(int courseId, LevelEnum level)
        {
            CourseId = courseId;
            Level = level;
            ExerciseList = new List<Exercise>();
           
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

        public int GetMinLengthOfExerciseList(LevelEnum level)
        {
            switch (level)
            {
                case LevelEnum.Beginner:
                    return 10;
                    break;
                case LevelEnum.Advanced:
                    return 12;
                    break;
                case LevelEnum.Expert:
                    return 16;
                    break;
                case LevelEnum.Champion:
                    return 18;
                    break;
                case LevelEnum.OpenClass:
                    return 15;
                    break;
                default:
                    return 0;
                    break;
            }
        }




    }   
    
}
