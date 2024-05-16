using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace BusinessLogic.Models
{
    public class CourseValidator
    {
        private readonly CourseVisualizer _visualizer;

        public CourseValidator()
        {
            _visualizer = new CourseVisualizer();
        }

        public bool ValidateLengthOfExerciseList(Course course)
        {
            int min = course.GetMinLengthOfExerciseList(course.Level);
            int max = course.GetMaxLengthOfExerciseList(course.Level);
            int exerciseCount = 0;

            foreach (Exercise exercise in course.ExerciseList)
            {
                if (exercise.ExerciseId > 1)
                {
                    exerciseCount++;
                }
            }

            if (min <= exerciseCount && exerciseCount <= max)
            {
                return true;
            }
            return false;
        }


        public bool ValidateRightHandlingOnlyBetweenTwoChangesOfPositions(List<(int, int, string, bool)> rightHandledExerises, Course course)
        {
            List<Exercise> exercisesWithProperties = course.AssignIndexNumberAndLeftHandletProperties();
            bool actualExerciseMakesChangeOfPosition;
            bool previousExerciseMakesChangeOfPosition;
            

            try
            {
                foreach (var item in rightHandledExerises)
                {
                    int id = item.Item1;
                    int index = exercisesWithProperties.FindIndex(x => x.ExerciseId == item.Item1);

                    //Is actual exercise making a change of position?
                    actualExerciseMakesChangeOfPosition = exercisesWithProperties[index].DefaultHandlingPosition == DefaultHandlingPositionEnum.ChangeOfPosition;

                    //Is next exercise making a change of position?
                    previousExerciseMakesChangeOfPosition = exercisesWithProperties[index + 1].DefaultHandlingPosition == DefaultHandlingPositionEnum.ChangeOfPosition;
                    
                    //Is any of the two exercises NOT making a changeOfPosition => throw exception
                        
                        
                    if (actualExerciseMakesChangeOfPosition == false || previousExerciseMakesChangeOfPosition == false)
                    {
                        throw new Exception($"RightHandling must be between two changes of position, exerciseId: {id}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public bool ValidateMaxNumberOfRepeatedRightHandledExercises(List<(int, int, string, bool)> rightHandledExerises, Course course, DefaultHandlingPositionEnum startPosition)
        {
            try // wraps in a try-catch to ensure a return bool if exception is thrown
            {
                List<(int, int, string, bool)> courseVisualised = _visualizer.VisualiseCourse(course, startPosition);

                bool validationOfExpertLevel = true;
                bool validationOfChampionLevel = true;
                int max = course.GetMaxRepeatedRightHandledExercises(course.Level);

                foreach (var rightHandled in rightHandledExerises)
                {
                    int id = rightHandled.Item1;
                    // find indexnummer using id
                    int index = courseVisualised.FindIndex(visualised => visualised.Item1 == id);

                    if (index - 2 < 0) { continue; }

                    // Using the "LeftHandlet"-property of items in courseVisualised
                    bool previousExerciseIsRightHandlet = !courseVisualised[index - 1].Item4;
                    bool exerciseSecondBeforeExerciseIsRightHandlet = !courseVisualised[index - 2].Item4;

                    //****  Validation of ExpertLevel ****
                    if(course.Level == LevelEnum.Expert) 
                    {
                        if (previousExerciseIsRightHandlet == true)
                        {
                            // if exercise second before actual exercise also is righthandlet => validation of expertLevel is false
                            validationOfExpertLevel = !exerciseSecondBeforeExerciseIsRightHandlet;
                            if (validationOfExpertLevel == false)
                            {
                                throw new Exception($"Max {max} repeated RightHandled exercises, error at ecerciseId: {id}");
                            }

                        }
                    }
                    
                    // **** Validation of ChampionLevel ****
                    if(course.Level == LevelEnum.Champion) 
                    {
                        if (index - 3 < 0) { continue; }
                        bool exerciseThirdBeforeExerciseIsRightHandlet = !courseVisualised[index - 3].Item4;

                        if (previousExerciseIsRightHandlet == true && exerciseSecondBeforeExerciseIsRightHandlet == true)

                            validationOfChampionLevel = !exerciseThirdBeforeExerciseIsRightHandlet;
                        if (validationOfChampionLevel == false)
                        {
                            throw new Exception($"Max {max} repeated RightHandled exercises, error at ecerciseId: {id}");
                        }
                    }
                }
                if (course.Level == LevelEnum.Expert)
                {
                    return validationOfExpertLevel;
                }
                if (course.Level == LevelEnum.Champion)
                {
                    return validationOfChampionLevel;
                }
                else { return false; }
            }
            catch (Exception ex) 
            {
                return false;   
            }
            
            
        }

        public bool ValidateMaxNumberOfStationaryExercises(Course course)
        {
            int max = course.GetMaxOfStationaryExercises(course.Level);
            int actualNumber = 0;   

            foreach(Exercise exercise in course.ExerciseList) 
            {
                if(exercise.Stationary == true) 
                {
                    actualNumber++;
                }
            }
            if(actualNumber <= max) 
            {
                return true;
            }
            return false;
        }
    }

                

}


