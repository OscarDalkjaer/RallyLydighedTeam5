using Microsoft.Extensions.Options;
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
            string statusString = $"Du har nu {exerciseCount} øvelser på din bane. På dette niveau skal der min. være: {min} øvelser, max er: {max}";

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
                        statusString = $"Der er korrekt brug af højrehåndterede øvelser ifht. banens niveau";
                        validate = true;
                    }
                    //Is any of the two exercises NOT making a changeOfPosition => error
                    if (actualExerciseMakesChangeOfPosition == false || nextExerciseMakesChangeOfPosition == false)
                    {
                        statusString = $"På dette niveau må højre-håndtering kun ske mellem to øvelser med sideskift. Fejl ved øvelse:{id}";
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
                    statusString = $"Din bane har ingen højrehåndterede øvelser. På dette niveau må banen maximalt have {max} højrehåndterede øvelser i træk";
                    continue;
                }

                if (previousExerciseIsRightHandlet == true && exerciseSecondBeforeExerciseIsRightHandlet == false)
                {
                    validate = true;
                    statusString = $"Din bane har nu 2 højrehåndterede øvelser i træk. På dette niveau må banen maximalt have {max} højrehåndterede øvelser i træk";
                    continue;
                }

                if (course.Level == LevelEnum.Expert)
                {
                    if (previousExerciseIsRightHandlet == true && exerciseSecondBeforeExerciseIsRightHandlet == true)
                    {
                        statusString = $"Din bane har nu 3 højrehåndterede øvelser. På dette niveau må banen maximalt have {max} højrehåndterede øvelser i træk";
                        validate = false;
                        break;
                    }
                }                                 

                if (course.Level == LevelEnum.Champion && index - 3 >= 0)
                {
                    bool exercíseThirdBeforeExerciseIsRightHandledt = !courseVisualised[index - 3].Item4;
                    if (previousExerciseIsRightHandlet == true && exerciseSecondBeforeExerciseIsRightHandlet == true && exercíseThirdBeforeExerciseIsRightHandledt == false)
                    {
                        statusString = $"Din bane har nu 3 højrehåndterede øvelser. På dette niveau må banen maximalt have {max} højrehåndterede øvelser i træk";
                        validate = true;
                        continue;
                    }

                    if (previousExerciseIsRightHandlet == true && exerciseSecondBeforeExerciseIsRightHandlet == true && exercíseThirdBeforeExerciseIsRightHandledt == true)
                    {
                        statusString = $"Din bane har nu 4 højrehåndterede øvelser. På dette niveau må banen maximalt have {max} højrehåndterede øvelser i træk";
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
                        statusString = $"Du har nu tilføjet  {actualNumber} stationære øvelser til banen. Det maximale antal på dette baneniveau er: {max}";
                        validate = true;
                        continue;
                    }
                    if (actualNumber > max)
                    {
                        statusString = $"Du har nu tilføjet  {actualNumber} stationære øvelser til banen. Det maximale antal på dette baneniveau er: {max}";
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
                        statusString = $"Du har nu filføjet {actualNumber} kegle-øveler til banen. Det maximale tilladte antal på dette niveau er: {max}";
                        validate = true;
                        continue;
                    }
                    if (actualNumber > max) 
                    {
                        statusString = $"Du har nu filføjet {actualNumber} kegle-øveler til banen. Det maximale tilladte antal på dette niveau er: {max}";
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
                statusString = $"Du har ikke tilføjet nogle øvelser, der ændrer på udførelses-hastigheden";
                validate = true;
                return (validate, statusString);
            }

            // Validate, if speed is changed more than once
            maxOneExerciseIsChangingTheSpeed = exercisesWithChangeOfSpeed.Count < 2 ? true : false;
            if (maxOneExerciseIsChangingTheSpeed == false)
            {
                statusString = $"Du har nu {exercisesWithChangeOfSpeed.Count} øvelser, der ændrer på udførelses-hastigheden. Det maximalt tilladte antal af sådanne øvelser på dette banenieveau er: 1";
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
                    statusString = $"Du har overskredet grænsen for, hvor mange øvelser, der må udføres i atypisk tempo. Det maximale antal for dette på dette baneniveau er: 1";
                    validate = false;
                    return (validate, statusString);
                }

                if (noExercisesBeforeReturnToNormalSpeedValidated == true)
                {
                    statusString = $"Du har ikke tilføjet nogle øverlser, der ændrer på udførelses-hastigheden. På dette baneniveu, er det maximalt tilladte af sådanne øveler: 1";
                    validate = true;
                    return (validate, statusString);
                }

                if (noExercisesBeforeReturnToNormalSpeedValidated == false && onlyOneExercisesBeforeReturnToNormalSpeedValidated == true)
                {
                    // If one exercise is changed in speed, does it have  3 <= exerciseNumber <= 15?
                    if (exercisesWithIndexNumber[index + 1].Number < 3 || exercisesWithIndexNumber[index + 1].Number > 15)
                    {
                        statusString = $"Din bane har nu 1 øvelse med atypisk udførelses-hastighed. På dete baneniveau er max-grænsen for sådanne øveler: 1. Øvelsen skal være nummer 3-15";
                        validate = false;
                        return (validate, statusString);
                    }
                    statusString = $"Din bane har nu 1 øvelse med atypisk udførelses-hastighed. På dete baneniveau er max-grænsen for sådanne øveler: 1. Øvelsen skal være nummer 3-15";
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
            string statusString = $"Din bane har nu {countOfRightHandletExercises} højrehåndterede øvelser. Minimum er {min} og maximum er {max}"; 
            
            if(course.Level == LevelEnum.OpenClass) 
            {
                Exercise? ex = course.ExerciseList.SingleOrDefault(exercise => exercise.ExerciseId == rightHandledExerises[0].Item1);
                if (ex != null) 
                {
                    validate = ex.Level == LevelEnum.Beginner;
                    if (validate == false) 
                    {
                        throw new Exception($"På dette baneniveau skal den højrehåndterede øvelse være på befynderniveau'");
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

            string statusString = $"Din bane har nu {levelDistribution.Item1} øvelser fra begynderniveau, {levelDistribution.Item2} øvelser fra øvet niveau, " +
                        $"{levelDistribution.Item3} øvelser fra ekspert niveau, {levelDistribution.Item4} øvelser fra champion niveau og " +
                        $"{levelDistribution.Item5} øvelser fra open class niveau. Minimumværdier for disse parametre er henholdsvist {min} og maximum er {max}";

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

        public (bool, string) ValidateMaxNumberOfDifferentTypesOfJump(Course course)
        {
            string statusString = "";
            bool validator = false;

            List<(int, int, string, jumpEnum?)> visualisedJumpExercises = _visualizer.VisualiseJumpPropertyForExercise(course);
            (int, int, int) maxSingleJumpMaxDoubleJumpMaxTotal = course.GetMaximunNumberOfDifferentJumps(course.Level);
            int actualNumberOfSingleJumps = visualisedJumpExercises.Count(x => x.Item4 == jumpEnum.SingleJump);
            int actualNumberOfDoubleJumps = visualisedJumpExercises.Count(x => x.Item4 > jumpEnum.DoubleJump);  
            int actualtotalAmountOfJumps = actualNumberOfSingleJumps + actualNumberOfDoubleJumps;

            statusString = $"Din bane har nu {actualNumberOfSingleJumps} øverser med enkelt-spring, {actualNumberOfDoubleJumps} øvelser med dobbelt-spring og " +
                $"{actualtotalAmountOfJumps} spring-øvelser ialt. Max-værdier for disse er på dette baneniveau henholdsvist: {maxSingleJumpMaxDoubleJumpMaxTotal.Item1}, " +
                $"{maxSingleJumpMaxDoubleJumpMaxTotal.Item2}, {maxSingleJumpMaxDoubleJumpMaxTotal.Item3}";

            validator = actualNumberOfSingleJumps <= maxSingleJumpMaxDoubleJumpMaxTotal.Item1 &&
                actualNumberOfDoubleJumps <= maxSingleJumpMaxDoubleJumpMaxTotal.Item2 &&
                actualtotalAmountOfJumps <= maxSingleJumpMaxDoubleJumpMaxTotal.Item3;
            return (validator, statusString);
        }
    }

                

}


