namespace BusinessLogic.Models
{
    public class CourseValidator
    {
        private readonly CourseVisualizer _visualizer;

        public List<(int, int, string, bool)> VisualisedCourse { get; set; }
        public List<(int, int, string, bool)> ListOfRightHandledExercises { get; set; }
        public List<string> StatusStrings { get; set; }

        public CourseValidator() 
        {
            _visualizer = new CourseVisualizer();
            StatusStrings = new List<string>();
        }

        public void InitializeValidatorBasics(Course course)
        {            
            VisualisedCourse = _visualizer.VisualiseCourse(course);
            ListOfRightHandledExercises = _visualizer.VisualiseRightHandledExercises(VisualisedCourse);            
        }

        public (bool, string) ValidateRightHandlingIsAllowedStartPosition(Course course) 
        {
            bool validate;
            string statusString = "";

            if (course.IsStartPositionLeftHandled == false)
            {
                validate = course.Level == LevelEnum.Expert || course.Level == LevelEnum.Champion;
                if (validate == true)
                {
                    statusString = $"KORREKT. StartPosition = HøjreHåndteret. Tilladt: Højre- og venstre-håndteret";
                    StatusStrings.Add(statusString);
                    return (validate, statusString);
                }
                else
                {
                    statusString =$"OBS! StartPosition = HøjreHåndteret. Tilladt: Venstre-håndteret";
                    StatusStrings.Add(statusString);
                    return (validate, statusString);
                }
            }
            if(course.IsStartPositionLeftHandled == true) 
            {
                validate = true;
                if (course.Level == LevelEnum.Expert || course.Level == LevelEnum.Champion)                    
                {
                    statusString = $"KORREKT. StartPosition = VenstreHåndteret. Tilladt: Højre- og venstre-håndteret";
                    StatusStrings.Add(statusString);
                    return (validate, statusString);
                }
                else
                {
                    statusString = $"KORREKT. StartPosition = VenstreHåndteret. Tilladt: Venstre-håndteret";
                    StatusStrings.Add(statusString);
                    return (validate, statusString);
                }
            }          
            return (false, statusString);            
        }
     
        public (bool, string) ValidateLengthOfExerciseList(Course course)
        {
            int min = course.GetMinLengthOfExerciseList(course.Level);
            int max = course.GetMaxLengthOfExerciseList(course.Level);
            int exerciseCount = 0;

            foreach (Exercise exercise in course.ExerciseList)
            {
                if (exercise.ExerciseId > 1 && exercise.ExerciseId != 111)
                {
                    exerciseCount++;
                }
            }
            string statusString = $"Aktuelt antal øvelser: {exerciseCount}. KRAV: Minimum: {min}, maximum: {max}";

            bool validate = false;
            if (min <= exerciseCount && exerciseCount <= max)
            {
                validate = true;
            }
          
            if(!string.IsNullOrEmpty(statusString)) 
            {
                StatusStrings.Add(statusString);
            }
               
            return (validate, statusString);
        }


        public (bool, string) ValidateRightHandlingOnlyBetweenTwoChangesOfPositions(Course course)
        {
            if (course.Level != LevelEnum.Beginner) { return (true, ""); }
          
            bool actualExerciseMakesChangeOfPosition;
            bool nextExerciseMakesChangeOfPosition;

            string statusString = "";
            bool validate = false;
            try
            {
                foreach (var item in ListOfRightHandledExercises)
                {
                    int id = item.Item1;
                    int index = course.ExerciseList.FindIndex(x => x.ExerciseId == item.Item1);

                    //Is actual exercise making a change of position?
                    actualExerciseMakesChangeOfPosition = course.ExerciseList[index].DefaultHandlingPosition == DefaultHandlingPositionEnum.ChangeOfPosition;

                    //Is next exercise making a change of position?
                    nextExerciseMakesChangeOfPosition = course.ExerciseList[index + 1].DefaultHandlingPosition == DefaultHandlingPositionEnum.ChangeOfPosition;

                    // If actualExercise is making Change of position, validation is true IF the next exercise makes a change of position too
                    if (actualExerciseMakesChangeOfPosition == true &&  nextExerciseMakesChangeOfPosition == true)
                    {
                        statusString = $"KORREKT anvendelse af højrehåndteret øvelse mellem to sideskift";
                        validate = true;
                    }
                    //Is any of the two exercises NOT making a changeOfPosition => error
                    if (actualExerciseMakesChangeOfPosition == false || nextExerciseMakesChangeOfPosition == false)
                    {
                        statusString = $"OBS! På dette niveau må højre-håndtering kun ske mellem to øvelser med sideskift. Se øvelse:{id}";
                        validate = false;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("problems with database???????");
                statusString = "";
                validate = false;
            }
            if (!string.IsNullOrEmpty(statusString))
            {
                StatusStrings.Add(statusString);
            }
            return (validate, statusString);
        }

        public (bool, string) ValidateMaxNumberOfRepeatedRightHandledExercises(Course course)
        {
            InitializeValidatorBasics(course);
            int max = course.GetMaxRepeatedRightHandledExercises(course.Level);
            bool validate = false;
            string statusString = "";

            foreach (var rightHandled in ListOfRightHandledExercises)
            {              
                int id = rightHandled.Item1;

                // find indexnummer using id
                int index = VisualisedCourse.FindIndex(visualised => visualised.Item1 == id);

                // for index < 1 there will be no validationProblems, so first two items can be skipped
                if (index - 2 < 0) { continue; }

                // Using the "LeftHandlet"-property of items in courseVisualised
                bool previousExerciseIsLeftHandlet = VisualisedCourse[index - 1].Item4;
                bool exerciseSecondBeforeExerciseIsLeftHandlet = VisualisedCourse[index - 2].Item4;                


                if (previousExerciseIsLeftHandlet == true)
                {
                    validate = true;
                    statusString = $"KORREKT. Antal højrehåndterede øvelser i træk: 0. Max tilladte: {max}";
                    continue;
                }

                if (previousExerciseIsLeftHandlet == false && exerciseSecondBeforeExerciseIsLeftHandlet == true)
                {
                    validate = true;
                    statusString = $"KORREKT. Antal højrehåndterede øvelser i træk: 2. Max tilladte: {max}";
                    continue;
                }

                if (course.Level == LevelEnum.Expert)
                {
                    if (previousExerciseIsLeftHandlet == false && exerciseSecondBeforeExerciseIsLeftHandlet == false)
                    {
                        statusString = $"OBS! Antal højrehåndterede øvelser i træk: 3. Max tilladte: {max}";
                        validate = false;
                        break;
                    }
                }                                 

                if (course.Level == LevelEnum.Champion && index - 3 >= 0)
                {
                    bool exercíseThirdBeforeExerciseIsLeftHandledt = VisualisedCourse[index - 3].Item4;
                    if (previousExerciseIsLeftHandlet == false && exerciseSecondBeforeExerciseIsLeftHandlet == false && exercíseThirdBeforeExerciseIsLeftHandledt == true)
                    {
                        statusString = $"KORREKT. Antal højrehåndterede øvelser i træk: 3. Max tilladte: {max}";
                        validate = true;
                        continue;
                    }

                    if (previousExerciseIsLeftHandlet == false && exerciseSecondBeforeExerciseIsLeftHandlet == false && exercíseThirdBeforeExerciseIsLeftHandledt == false)
                    {
                        statusString = $"OBS! Antal højrehåndterede øvelser i træk: 4. Max tilladte: {max}";
                        validate = false;
                        break;
                    }
                }
            }
            if (!string.IsNullOrEmpty(statusString))
            {
                StatusStrings.Add(statusString);
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
                        statusString = $"KORREKT Antal statiske øvelser: {actualNumber}. Maximale antal: {max}";
                        validate = true;
                        continue;
                    }
                    if (actualNumber > max)
                    {
                        statusString = $"OBS! Antal statiske øvlser: {actualNumber} Maximale antal: {max}";
                        validate = false;
                        break;
                    }
                }
            }
            if (!string.IsNullOrEmpty(statusString))
            {
                StatusStrings.Add(statusString);
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
                        statusString = $"KORREKT. Antal kegleøvelser: {actualNumber} Maximum: {max}";
                        validate = true;
                        continue;
                    }
                    if (actualNumber > max) 
                    {
                        statusString = $"OBS! Antal kegleøvelser: {actualNumber} Maximum: {max}";
                        validate = false;
                        break;
                    }
                }
            }
            if (!string.IsNullOrEmpty(statusString))
            {
                StatusStrings.Add(statusString);
            }
            return (validate, statusString);           
        }

        public (bool, string) ValidateMaxNumberOfExercisesInNonTypicalSpeed(Course course)
        {
            InitializeValidatorBasics(course);
            bool validate = false;
            string statusString = "";
            if (course.Level == LevelEnum.Beginner)
            {
                validate = true;
                return (validate, statusString);
            }

            bool noChangesOfSpeedAttAll;
            bool maxOneExerciseIsChangingTheSpeed;

            // Create list of exercises changing the speed 
            List<Exercise> exercisesWithChangeOfSpeed = course.ExerciseList.Where(x => x.Number == 21 || x.Number == 22).ToList();

            // Valdidate, if speed is changed at all
            noChangesOfSpeedAttAll = exercisesWithChangeOfSpeed.Count == 0 ? true : false;
            if (noChangesOfSpeedAttAll == true)
            {
                statusString = $"KORREKT. Antal øvelser, der ændrer på udførelses-hastigheden: 0. Maximum: 1";
                validate = true;
                return (validate, statusString);
            }

            // Validate, if speed is changed more than once
            maxOneExerciseIsChangingTheSpeed = exercisesWithChangeOfSpeed.Count < 2 ? true : false;
            if (maxOneExerciseIsChangingTheSpeed == false)
            {
                statusString = $"OBS! Antal øvelser, der ændrer på udførelses-hastigheden:{exercisesWithChangeOfSpeed.Count} Maximum: 1";
                validate = false;
                return (validate, statusString);
            }


            if (exercisesWithChangeOfSpeed.Count == 1)
            {
                // Is first or second exercise changing speed back to normal?
                int index = exercisesWithChangeOfSpeed[0].IndexNumber;
                bool noExercisesBeforeReturnToNormalSpeedValidated = course.ExerciseList[index + 1].Number == 23;
                bool onlyOneExercisesBeforeReturnToNormalSpeedValidated = course.ExerciseList[index + 2].Number == 23;

                int indexForExerciseNumber23 = course.ExerciseList.FindIndex(index => index.Number == 23);
                int numberOfExercisesInAtypicalSpeed = indexForExerciseNumber23 - index;

                // If neither first or second exercise changes speed back to normal => return false
                if (noExercisesBeforeReturnToNormalSpeedValidated == false && onlyOneExercisesBeforeReturnToNormalSpeedValidated == false)
                {

                    statusString = $"OBS! Antal øvelser, der udføres i atypisk hastighed: {numberOfExercisesInAtypicalSpeed}. Maximum: 1";
                    validate = false;
                    return (validate, statusString);
                }

                if (noExercisesBeforeReturnToNormalSpeedValidated == true)
                {
                    statusString = $"KORREKT. Antal øvelser, der udføres i atypisk hastighed: {numberOfExercisesInAtypicalSpeed}. Maximum: 1";
                    validate = true;
                    return (validate, statusString);
                }

                if (noExercisesBeforeReturnToNormalSpeedValidated == false && onlyOneExercisesBeforeReturnToNormalSpeedValidated == true)
                {
                    // If one exercise is changed in speed, does it have  3 <= exerciseNumber <= 15?
                    if (course.ExerciseList[index + 1].Number < 3 || course.ExerciseList[index + 1].Number > 15)
                    {
                        statusString = $" KORREKT. Øvelsen, der udføres i atypisk hastighed, er nummer: {course.ExerciseList[index + 1]}  Øvelsen skal være nummer 3-15";
                        validate = false;
                        return (validate, statusString);
                    }
                    statusString = $"OBS! Øvelsen, der udføres i atypisk hastighed, er nummer: {course.ExerciseList[index + 1]}  Øvelsen skal være nummer 3-15 ";
                    validate = true;
                    return (validate, statusString);
                }
            }
            if (!string.IsNullOrEmpty(statusString))
            {
                StatusStrings.Add(statusString);
            }
            return (validate, statusString);
        }
        

        public (bool, string) ValidateNumberOfRightHandletExercises(Course course) 
        {
            int min = course.GetMinNumberOfRightHandledExercises(course.Level);
            int max = course.GetMaxNumberOfRightHandledExercises(course.Level);
            string statusString = "";

            int countOfRightHandletExercises = ListOfRightHandledExercises.Count();
            
            bool validate = min <= countOfRightHandletExercises && countOfRightHandletExercises >= max;
            if(validate == true && course.Level != LevelEnum.OpenClass) 
            {
                statusString = $"KORREKT. Antal højrehåndterede øvelser: {countOfRightHandletExercises}. Minimum: {min} Maximum: {max}";

            }
            if (validate == false)
            {
                statusString = $"OBS!. Antal højrehåndterede øvelser: {countOfRightHandletExercises}. Minimum: {min} Maximum: {max}";

            }

            if (countOfRightHandletExercises > 0 && course.Level == LevelEnum.OpenClass) 
            {
                Exercise? ex = course.ExerciseList.SingleOrDefault(exercise => exercise.ExerciseId == ListOfRightHandledExercises[0].Item1);
                if (ex != null) 
                {
                    validate = ex.Level == LevelEnum.Beginner;
                    if(validate == true) 
                    {
                        statusString = $"KORREKT. Den højrehåndterede øvelses niveau er: {ex.Level}. Niveuet skal være: Begynder ";
                    }
                    if (validate == false) 
                    {
                        statusString = $"OBS! Den højrehåndterede øvelses niveau er: {ex.Level}. Niveuet skal være: Begynder ";
                    }
                }               
            }
            if (!string.IsNullOrEmpty(statusString))
            {
                StatusStrings.Add(statusString);
            }
            return (validate, statusString);
        }

        public (bool, string) ValidateLevelDistributionOfTheExercises(Course course) 
        {
            (int, int, int, int, int) min = course.GetMinimalAmountOfExercisesFromAllLevels(course.Level);
            (int, int, int, int, int) max = course.GetMaxAmountOfExercisesFromAllLevels(course.Level);
            (int, int, int, int, int) levelDistribution = _visualizer.VisualiseLevelDistributionOfTheExercises(course);

            string statusString =
                $"Begynder-Øvelser:{levelDistribution.Item1}, krav: ({min.Item1} - {max.Item1}), " +
                $"øvet-øvelser:{levelDistribution.Item2}, krav: ({min.Item2} - {max.Item2}) " +
                $"ekspert-øvelser: {levelDistribution.Item3}, krav: ({min.Item3} - {max.Item3}) " +
                $"champion-øvelser:{levelDistribution.Item4}, krav: ( {min.Item4}  -  {max.Item4} ) " +
                $"open-class-øvelser{levelDistribution.Item5}, krav: ({min.Item5} - {max.Item5})";
            StatusStrings.Add(statusString);

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

            statusString = $"Antal enkelt-spring: {actualNumberOfSingleJumps}, maximum: {maxSingleJumpMaxDoubleJumpMaxTotal.Item1}. " +
                $"Antal dobbelt-spring: {actualNumberOfDoubleJumps}, maximum: {maxSingleJumpMaxDoubleJumpMaxTotal.Item2}. "+
                $"Totale antal spring {actualtotalAmountOfJumps}, maximum: {maxSingleJumpMaxDoubleJumpMaxTotal.Item3} ";

            validator = actualNumberOfSingleJumps <= maxSingleJumpMaxDoubleJumpMaxTotal.Item1 &&
                actualNumberOfDoubleJumps <= maxSingleJumpMaxDoubleJumpMaxTotal.Item2 &&
                actualtotalAmountOfJumps <= maxSingleJumpMaxDoubleJumpMaxTotal.Item3;

            if (!string.IsNullOrEmpty(statusString))
            {
                StatusStrings.Add(statusString);
            }
            return (validator, statusString);
        }
    }               
}


