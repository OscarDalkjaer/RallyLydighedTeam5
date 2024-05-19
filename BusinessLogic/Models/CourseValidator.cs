﻿using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public (bool, string) ValidateLengthOfExerciseList(Course course)
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
            string statusString = $"You have now applied {exerciseCount} to your course. Minimum amount is {min}, max is {max}";

            bool validate = false;
            if (min <= exerciseCount && exerciseCount <= max)
            {
                validate = true;
            }
            return (validate, statusString);
        }


        public (bool, string) ValidateRightHandlingOnlyBetweenTwoChangesOfPositions(List<(int, int, string, bool)> rightHandledExerises, Course course)
        {
            if (course.Level != LevelEnum.Beginner) { return (true, ""); }

            List<Exercise> exercisesWithProperties = course.AssignIndexNumberAndLeftHandletProperties();
            bool actualExerciseMakesChangeOfPosition;
            bool nextExerciseMakesChangeOfPosition;

            string statusString = "";
            bool validate = false;
            try
            {
                foreach (var item in rightHandledExerises)
                {
                    int id = item.Item1;
                    int index = exercisesWithProperties.FindIndex(x => x.ExerciseId == item.Item1);

                    //Is actual exercise making a change of position?
                    actualExerciseMakesChangeOfPosition = exercisesWithProperties[index].DefaultHandlingPosition == DefaultHandlingPositionEnum.ChangeOfPosition;

                    //Is next exercise making a change of position?
                    nextExerciseMakesChangeOfPosition = exercisesWithProperties[index + 1].DefaultHandlingPosition == DefaultHandlingPositionEnum.ChangeOfPosition;

                    // If actualExercise is making Change of position, validation is true IF next exercise makes a change of position too
                    if (actualExerciseMakesChangeOfPosition == true &&  nextExerciseMakesChangeOfPosition == true)
                    {
                        statusString = $"Correct use of rightHandling exercise at this level";
                        validate = true;
                    }
                    //Is any of the two exercises NOT making a changeOfPosition => error
                    if (actualExerciseMakesChangeOfPosition == false || nextExerciseMakesChangeOfPosition == false)
                    {
                        statusString = $"RightHandling must be between two changes of position, exerciseId: {id}";
                        validate = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("problems with database???????");
                statusString = "";
                validate = false;
            }
            return (validate, statusString);
        }

        public (bool, string) ValidateMaxNumberOfRepeatedRightHandledExercises(List<(int, int, string, bool)> rightHandledExerises, Course course, DefaultHandlingPositionEnum startPosition)
        {
            
            List<(int, int, string, bool)> courseVisualised = _visualizer.VisualiseCourse(course, startPosition);
            int max = course.GetMaxRepeatedRightHandledExercises(course.Level);
            bool validate = false;
            string statusString = "";

            foreach (var rightHandled in rightHandledExerises)
            {
              
                int id = rightHandled.Item1;
                // find indexnummer using id
                int index = courseVisualised.FindIndex(visualised => visualised.Item1 == id);

                if (index - 2 < 0) { continue; }

                // Using the "LeftHandlet"-property of items in courseVisualised
                bool previousExerciseIsRightHandlet = !courseVisualised[index - 1].Item4;
                bool exerciseSecondBeforeExerciseIsRightHandlet = !courseVisualised[index - 2].Item4;                


                if (previousExerciseIsRightHandlet == false)
                {
                    validate = true;
                    statusString = $"You now have no repeated righthandled exercises. At this level allow a maxnumber of {max} repeated righthandled exercises";
                    continue;
                }

                if (previousExerciseIsRightHandlet == true && exerciseSecondBeforeExerciseIsRightHandlet == false)
                {
                    validate = true;
                    statusString = $"You now have 2 repeated righthandled exercises. At this level allow a maxnumber of {max} repeated righthandled exercises";
                    continue;
                }

                if (course.Level == LevelEnum.Expert)
                {
                    if (previousExerciseIsRightHandlet == true && exerciseSecondBeforeExerciseIsRightHandlet == true)
                    {
                        statusString = $"You now have 3 repeated righthandled exercises. At this level allow a maxnumber of {max} repeated righthandled exercises";
                        validate = false;
                        break;
                    }
                }                                 

                if (course.Level == LevelEnum.Champion && index - 3 >= 0)
                {
                    bool exercíseThirdBeforeExerciseIsRightHandledt = !courseVisualised[index - 3].Item4;
                    if (previousExerciseIsRightHandlet == true && exerciseSecondBeforeExerciseIsRightHandlet == true && exercíseThirdBeforeExerciseIsRightHandledt == false)
                    {
                        statusString = $"You now have 3 repeated righthandled exercises. At this level allow a maxnumber of {max} repeated righthandled exercises";
                        validate = true;
                        continue;
                    }

                    if (previousExerciseIsRightHandlet == true && exerciseSecondBeforeExerciseIsRightHandlet == true && exercíseThirdBeforeExerciseIsRightHandledt == true)
                    {
                        statusString = $"You now have 4 repeated righthandled exercises. At this level allow a maxnumber of {max} repeated righthandled exercises";
                        validate = false;
                        break;
                    }
                }
            }
            return (validate, statusString);
        }

        public (bool, string) ValidateMaxNumberOfStationaryExercises(Course course)
        {
            int max = course.GetMaxOfStationaryExercises(course.Level);
            int actualNumber = 0;
            bool validate = false;
            string statusString = "";

            foreach (Exercise exercise in course.ExerciseList)
            {
                if (exercise.Stationary == true)
                {
                    actualNumber++;
                    if (actualNumber <= max)
                    {
                        statusString = $"You have now addet {actualNumber} stationary exercises. Max number of stationary exercises on this level is {max}";
                        validate = true;
                        continue;
                    }
                    if (actualNumber > max)
                    {
                        statusString = $"You have now addet {actualNumber} stationary exercises. Max number of stationary exercises on this level is {max}";
                        validate = false;
                        break;
                    }
                }
            }
            return (validate, statusString);
        }

            

        public (bool,string) ValidateMaxNumberOfExercisesWithCone(Course course)
        {
            int max = course.GetMaxOfExercisesWithCone(course.Level);
            int actualNumber = 0;
            bool validate = false;
            string statusString = "";

            foreach (Exercise exercise in course.ExerciseList)
            {
                if (exercise.WithCone == true)
                {
                    actualNumber++;
                    if (actualNumber <= max) 
                    {
                        statusString = $"You have now addet {actualNumber} exercises with cone. Max number of exercises with cone on this level is {max}";
                        validate = true;
                        continue;
                    }
                    if (actualNumber > max) 
                    {
                        statusString = $"You have now addet {actualNumber} exercises with cone. Max number of exercises with cone on this level is {max}";
                        validate = false;
                        break;
                    }
                }
            }
            return (validate, statusString);           
        }

        public (bool, string) ValidateMaxNumberOfExercisesInNonTypicalSpeed(Course course)
        {
            bool validate = false;
            string statusString = "";
            if (course.Level == LevelEnum.Beginner)
            {
                validate = true;
                return (validate, statusString);
            }

            List<Exercise> exercisesWithIndexNumber = course.AssignIndexNumberAndLeftHandletProperties();
            bool noChangesOfSpeedAttAll;
            bool maxOneExerciseIsChangingTheSpeed;

            // Create list of exercises changing the speed 
            List<Exercise> exercisesWithChangeOfSpeed = exercisesWithIndexNumber.Where(x => x.Number == 21 || x.Number == 22).ToList();

            // Valdidate, if speed is changed at all
            noChangesOfSpeedAttAll = exercisesWithChangeOfSpeed.Count == 0 ? true : false;
            if (noChangesOfSpeedAttAll == true)
            {
                statusString = $"You have not applied any exercises changing the exerciseSpeed";
                validate = true;
                return (validate, statusString);
            }

            // Validate, if speed is changed more than once
            maxOneExerciseIsChangingTheSpeed = exercisesWithChangeOfSpeed.Count < 2 ? true : false;
            if (maxOneExerciseIsChangingTheSpeed == false)
            {
                statusString = $"You now changes the speed from standard speed {exercisesWithChangeOfSpeed.Count} times. Maximum number for this in this level is: 1";
                validate = false;
                return (validate, statusString);
            }


            if (exercisesWithChangeOfSpeed.Count == 1)
            {
                // Is first or second exercise changing speed back to normal?
                int index = exercisesWithChangeOfSpeed[0].IndexNumber;
                bool noExercisesBeforeReturnToNormalSpeedValidated = exercisesWithIndexNumber[index + 1].Number == 23;
                bool onlyOneExercisesBeforeReturnToNormalSpeedValidated = exercisesWithIndexNumber[index + 2].Number == 23;

                // If neither first or second exercise changes speed back to normal => return false
                if (noExercisesBeforeReturnToNormalSpeedValidated == false && onlyOneExercisesBeforeReturnToNormalSpeedValidated == false)
                {
                    statusString = $"You exceed the allowed number of exercises in unusual speed. At this level a maximun number for this is: 1";
                    validate = false;
                    return (validate, statusString);
                }

                if (noExercisesBeforeReturnToNormalSpeedValidated == true)
                {
                    statusString = $"You have applied 0 exercies in a non-typical speed. At this level a maximun number for this is: 1";
                    validate = true;
                    return (validate, statusString);
                }

                if (noExercisesBeforeReturnToNormalSpeedValidated == false && onlyOneExercisesBeforeReturnToNormalSpeedValidated == true)
                {
                    // If one exercise is changed in speed, does it have  3 <= exerciseNumber <= 15?
                    if (exercisesWithIndexNumber[index + 1].Number < 3 || exercisesWithIndexNumber[index + 1].Number > 15)
                    {
                        statusString = $"You have applied 1 exercies in an unusual speed. At this level a maximun number for this is: 1. But exercise number must be between 3-15";
                        validate = false;
                        return (validate, statusString);
                    }
                    statusString = $"You have applied 1 exercies in an unusual speed. At this level a maximun number for this is: 1";
                    validate = true;
                    return (validate, statusString);
                }
            }
            return (validate, statusString);
        }
        

        public (bool, string) ValidateNumberOfRightHandletExercises(List<(int, int, string, bool)> rightHandledExerises, Course course) 
        {
            int min = course.GetMinNumberOfRightHandledExercises(course.Level);
            int max = course.GetMaxNumberOfRightHandledExercises(course.Level);

            int countOfRightHandletExercises = rightHandledExerises.Count();
            
            bool validate = min <= countOfRightHandletExercises && countOfRightHandletExercises >= max;
            string statusString = $"You have now applied {countOfRightHandletExercises} righthandled exercises. Minimum is {min} and maximum is {max}"; 
            
            if(course.Level == LevelEnum.OpenClass) 
            {
                Exercise? ex = course.ExerciseList.SingleOrDefault(exercise => exercise.ExerciseId == rightHandledExerises[0].Item1);
                if (ex != null) 
                {
                    validate = ex.Level == LevelEnum.Beginner;
                    if (validate == false) 
                    {
                        throw new Exception($"Level of rightHandlet exercise in this class must be 'beginner'");
                    }
                }               
            }
            return (validate, statusString);
        }

        public (bool, string) ValidateLevelDistributionOfTheExercises(Course course) 
        {
            (int, int, int, int, int) min = course.GetMinimalAmountOfExercisesFromAllLevels(course.Level);
            (int, int, int, int, int) max = course.GetMaxAmountOfExercisesFromAllLevels(course.Level);
            (int, int, int, int, int) levelDistribution = _visualizer.VisualiseLevelDistributionOfTheExercises(course);

            string statusString = $"You have now placed {levelDistribution.Item1} exercises from beginner level, {levelDistribution.Item2} exercises from advanced level, " +
                        $"{levelDistribution.Item3} exercises from expert level, {levelDistribution.Item4} exercises from  champion level and " +
                        $"{levelDistribution.Item5} exercises from open class level. Minimum values for these parameters are {min} and maximum values are {max}";

            bool validateAmountOfExercisesFromBeginnerLevel = min.Item1 <= levelDistribution.Item1 && max.Item1 >= levelDistribution.Item1;
            bool validateAmountOfExercisesFromAdvancedLevel = min.Item2 <= levelDistribution.Item2 && max.Item2 >= levelDistribution.Item2;
            bool validateAmountOfExercisesFromExpertLevel = min.Item3 <= levelDistribution.Item3 && max.Item3 >= levelDistribution.Item3;
            bool validateAmountOfExercisesFromChampionLevel = min.Item4 <= levelDistribution.Item4 && max.Item4 >= levelDistribution.Item4;
            bool validateAmountOfExercisesFromOpenClassLevel = min.Item5 <= levelDistribution.Item5 && max.Item5 >= levelDistribution.Item5;

            switch (course.Level)
            {
                case LevelEnum.Beginner:

                    return (validateAmountOfExercisesFromBeginnerLevel, statusString);
                    break;
                case LevelEnum.Advanced:          
                    return (validateAmountOfExercisesFromAdvancedLevel, statusString);
                    break;
                case LevelEnum.Expert:
                    return (validateAmountOfExercisesFromExpertLevel, statusString);
                    break;
                case LevelEnum.Champion:
                    return (validateAmountOfExercisesFromChampionLevel, statusString);
                    break;
                case LevelEnum.OpenClass:
                    return (validateAmountOfExercisesFromOpenClassLevel, statusString);
                    break;
                default:
                    return (false, "");
                    break;
            }
        }

        public bool ValidateMaxNumberOfDifferentTypesOfJump(Course course)
        {
            List<(int, int, string, jumpEnum?)> visualisedJumpExercises = _visualizer.VisualiseJumpPropertyForExercise(course);
            (int, int, int) maxSingleJumpMaxDoubleJumpMaxTotal = course.GetMaximunNumberOfDifferentJumps(course.Level);
            int actualNumberOfSingleJumps = visualisedJumpExercises.Count(x => x.Item4 == jumpEnum.SingleJump);
            int actualNumberOfDoubleJumps = visualisedJumpExercises.Count(x => x.Item4 > jumpEnum.DoubleJump);  
            int actualtotalAmountOfJumps = actualNumberOfSingleJumps + actualNumberOfDoubleJumps;

            bool validator = actualNumberOfSingleJumps <= maxSingleJumpMaxDoubleJumpMaxTotal.Item1 &&
                actualNumberOfDoubleJumps <= maxSingleJumpMaxDoubleJumpMaxTotal.Item2 &&
                actualtotalAmountOfJumps <= maxSingleJumpMaxDoubleJumpMaxTotal.Item3;
            return validator;
        }
    }

                

}


