using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class CourseValidator
    {
        public CourseValidator() { }

        public bool ValidateLengthOfExerciseList(Course course)
        {
            int min = course.GetMinLengthOfExerciseList(course.Level);
            int max = course.GetMaxLengthOfExerciseList(course.Level);

            int LengthOfExerciseList = course.ExerciseList.Count;

            if (min <= LengthOfExerciseList && LengthOfExerciseList<= max) 
            {
                return true;
            }
            return false;
        }

        public async Task<bool> ValidateRightPositionOnlyBetweenTwoChangesOfPosition(Course course, StartPositionEnum startPosition)
        {
            bool validator;
            ValidationResults validationResults = new ValidationResults();
            List<Exercise> exercises = course.AssignListNumbers();
            await CreatePropertyListsofExercisesAccordingToHandlingPosition(startPosition, exercises, validationResults);

          
            List<Exercise> exercisesLackingChangeOfPositionPrefix = new List<Exercise>();
            List<Exercise> exercisesLackingChangeOfPositionSuffix = new List<Exercise>();

            List<Exercise> rightHandledExercises = validationResults.ExerciseIdOnRightHandledExercises;
            if (rightHandledExercises != null)
            {
                foreach (Exercise exercise in rightHandledExercises) 
                {
                    int index = exercise.IndexNumber;


                    if (exercise.IndexNumber == (index - 1))
                    {
                        if(exercise.HandlingPosition == HandlingPositionEnum.ChangeOfPosition) 
                        {
                            continue;
                        }
                        if(exercise.HandlingPosition != HandlingPositionEnum.ChangeOfPosition) 
                        {
                            exercisesLackingChangeOfPositionPrefix.Add(exercise);
                            continue;
                        }
                    }

                    if (exercise.IndexNumber == (index + 1)) 
                    {
                        if (exercise.HandlingPosition == HandlingPositionEnum.ChangeOfPosition)
                        {
                            continue;
                        }
                        if (exercise.HandlingPosition != HandlingPositionEnum.ChangeOfPosition)
                        {
                            exercisesLackingChangeOfPositionSuffix.Add(exercise);
                            continue;
                        }
                    }
                }

                validationResults.NumberOfExercisesLackingChangeOfPositionPrefix = exercisesLackingChangeOfPositionPrefix.Count();
                validationResults.NumberOfExercisesLackingChangeOfPositionSuffix = exercisesLackingChangeOfPositionSuffix.Count();

                if(validationResults.NumberOfExercisesLackingChangeOfPositionPrefix != 0) 
                {
                    throw new Exception($"Number of exercises lacking a changeOfPostionPrefix is: " +
                        $"{validationResults.NumberOfExercisesLackingChangeOfPositionPrefix}");
                    
                }
                if(validationResults.NumberOfExercisesLackingChangeOfPositionSuffix != 0) 
                {
                    throw new Exception($"Number of exercises lacking a changeOfPositionSuffix is: " +
                        $"{validationResults.NumberOfExercisesLackingChangeOfPositionSuffix}");
                }
                else 
                {
                    validator = true;
                    return validator;
                }
            }

        }

        public Task CreatePropertyListsofExercisesAccordingToHandlingPosition(StartPositionEnum startPosition, List<Exercise> exercises, ValidationResults validationResults2) 
        {
            ValidationResults validationResults = validationResults2;

            bool dogIsLeftHandled = true;
            if (startPosition == StartPositionEnum.Right)
            {
                dogIsLeftHandled = false;
            }
            List<Exercise> exerciseList = exercises;

            foreach (Exercise exercise in exerciseList)
            {
                if (dogIsLeftHandled == true)
                {
                    if (exercise.HandlingPosition == HandlingPositionEnum.Optional)
                    {
                        dogIsLeftHandled = true;
                        validationResults.ExerciseIdOnLefttHandledExercises.Add(exercise);
                        continue;
                        
                    }
                    if (exercise.HandlingPosition == HandlingPositionEnum.Left)
                    {
                        dogIsLeftHandled = true;
                        validationResults.ExerciseIdOnLefttHandledExercises.Add(exercise);
                        continue;
                    }
                    if (exercise.HandlingPosition == HandlingPositionEnum.Right)
                    {
                        dogIsLeftHandled = false;
                        validationResults.ExerciseIdOnRightHandledExercises.Add(exercise);
                        continue;

                    }
                    if(exercise.HandlingPosition == HandlingPositionEnum.ChangeOfPosition) 
                    {
                        dogIsLeftHandled = false;
                        validationResults.ExerciseIdOnRightHandledExercises.Add(exercise);
                        continue;

                    }
                }
                if (dogIsLeftHandled == false) 
                {
                    if (exercise.HandlingPosition == HandlingPositionEnum.Optional)
                    {
                        dogIsLeftHandled = false;
                        validationResults.ExerciseIdOnRightHandledExercises.Add(exercise);
                        continue;
                    }
                    if (exercise.HandlingPosition == HandlingPositionEnum.Left) // er dette muligt?
                    {
                        dogIsLeftHandled = true;
                        validationResults.ExerciseIdOnLefttHandledExercises.Add(exercise);
                        continue;
                    }
                    if (exercise.HandlingPosition == HandlingPositionEnum.Right)
                    {
                        dogIsLeftHandled = false;
                        validationResults.ExerciseIdOnRightHandledExercises.Add(exercise);
                        continue;
                    }
                    if (exercise.HandlingPosition == HandlingPositionEnum.ChangeOfPosition)
                    {
                        dogIsLeftHandled = true;
                        validationResults.ExerciseIdOnLefttHandledExercises.Add(exercise);
                        continue;
                    }
                }                
            }
            return Task.CompletedTask;
        }
    }
}
