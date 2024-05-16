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

        public List<Exercise> AssignIndexNumberAndLeftHandletProperties()
        {
            List<Exercise> courseListOfExercises = this.ExerciseList;
            List<Exercise> exercisesWithIndexNumberAndLeftHandletProperty = new List<Exercise>();
            int indexNumber = 0;
            bool actualHandlingPositionIsLeftHandlet = true;
            //ActualHandlingPositionEnum? exercisePositionEnum = null;

            foreach (Exercise exercise in courseListOfExercises) 
            {
                Exercise assignedExercise = new Exercise(
                    exercise.ExerciseId,
                    exercise.Number,
                    exercise.Name,
                    exercise.Description,
                    exercise.DefaultHandlingPosition,
                    exercise.Stationary,
                    exercise.WithCone,
                    exercise.TypeOfJump,
                    exercise.Level,
                    indexNumber,
                    actualHandlingPositionIsLeftHandlet);
                exercisesWithIndexNumberAndLeftHandletProperty.Add(assignedExercise);
                indexNumber++;       
                
            }
            this.ExerciseList.Clear();
            foreach (Exercise exercise in exercisesWithIndexNumberAndLeftHandletProperty) 
            {
                this.ExerciseList.Add(exercise);
            }
            return this.ExerciseList;
        }

        public int GetMaxRepeatedRightHandledExercises(LevelEnum level) 
        {
            int max;
            if (level == LevelEnum.Expert)
            {
                max = 2;
                return max;
            }  
            if(level == LevelEnum.Champion) 
            {
                max = 3;
                return max;
            }
            else 
            {
                return 0;
            }
        }


    }   
    
}
