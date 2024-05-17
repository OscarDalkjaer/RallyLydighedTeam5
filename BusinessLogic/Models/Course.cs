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

        public int GetMaxOfStationaryExercises(LevelEnum level)
        {
            switch (level)
            {
                case LevelEnum.Beginner:
                    return 5;
                    break;
                case LevelEnum.Advanced:
                    return 7;
                    break;
                case LevelEnum.Expert:
                    return 7;
                    break;
                case LevelEnum.Champion:
                    return 7;
                    break;
                case LevelEnum.OpenClass:
                    return 18;
                    break;
                default:
                    return 0;
                    break;
            }
        }

        public int GetMaxOfExercisesWithCone(LevelEnum level)
        {
            if(level == LevelEnum.OpenClass) 
            {
                return 18;
            }
            return 5;            
        }

        public int GetMinNumberOfRightHandledExercises(LevelEnum level)
        {
            switch (level)
            {
                case LevelEnum.Beginner:
                    return 0;
                    break;
                case LevelEnum.Advanced:
                    return 0;
                    break;
                case LevelEnum.Expert:
                    return 2;
                    break;
                case LevelEnum.Champion:
                    return 4;
                    break;
                case LevelEnum.OpenClass:
                    return 0;
                    break;
                default:
                    return 0;
                    break;
            }
        }

        public int GetMaxNumberOfRightHandledExercises(LevelEnum level)
        {
            switch (level)
            {
                case LevelEnum.Beginner:
                    return 15;
                    break;
                case LevelEnum.Advanced:
                    return 1;
                    break;
                case LevelEnum.Expert:
                    return 4;
                    break;
                case LevelEnum.Champion:
                    return 18;
                    break;
                case LevelEnum.OpenClass:
                    return 1;
                    break;
                default:
                    return 0;
                    break;
            }
        }

        public (int, int, int, int, int) GetMinimalAmountOfExercisesFromAllLevels(LevelEnum level)
        {
            int minimumNumberFromBeginnerLevel;
            int minimumNumberFromAdvancedLevel;
            int minimumNUmberFromChampionLevel;
            int minimumNumberFromExpertLevel;
            int minimumNumberFromOpenClassLevel;

            switch (level)
            {
                case LevelEnum.Beginner:
                    return (0,0,0,0,0);
                    break;
                case LevelEnum.Advanced:
                    return (0,5,0,0,0);
                    break;
                case LevelEnum.Expert:
                    return (0,5,3,0,0);
                    break;
                case LevelEnum.Champion:
                    return (0,4,1,5,0);
                    break;
                case LevelEnum.OpenClass:
                    return (4,4,2,2,0);
                    break;
                default:
                    return (0, 0, 0, 0, 0);
                    break;
            }

        }

        public (int, int, int, int, int) GetMaxAmountOfExercisesFromAllLevels(LevelEnum level)
        {
            switch (level)
            {
                case LevelEnum.Beginner:
                    return (15, 15, 15, 15, 15);
                    break;
                case LevelEnum.Advanced:
                    return (12, 12, 12, 12, 12);
                    break;
                case LevelEnum.Expert:
                    return (12, 17, 15 ,12, 12);
                    break;
                case LevelEnum.Champion:
                    return (10, 11, 11, 15, 10);
                    break;
                case LevelEnum.OpenClass:
                    return (8, 5, 4, 4, 6);
                    break;
                default:
                    return (0,0,0,0,0);
                    break;
            }
        }

        public (int, int, int) GetMaximunNumberOfDifferentJumps(LevelEnum level) 
        {
            switch (level)
            {
                case LevelEnum.Beginner:
                    return (15, 15, 15);
                    break;
                case LevelEnum.Advanced:
                    return (17, 17, 17);
                    break;
                case LevelEnum.Expert:
                    return (3, 3, 3);
                    break;
                case LevelEnum.Champion:
                    return (2, 2, 4);
                    break;
                case LevelEnum.OpenClass:
                    return (3, 3, 3);
                    break;
                default:
                    return (0, 0, 0);
                    break;
            }
        }
    }   
    
}
