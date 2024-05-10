using System;
using System.Collections.Generic;
using System.Linq;
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

        //public async Task (Course course, StartPositionEnum startPosition)
        //{
        //    ValidationResults validationResults = new ValidationResults();
        //    List<Exercise> exercises = course.AssignListNumbers();

        //    bool dogIsLeftHandled = true;
        //    if (startPosition == StartPositionEnum.Right)
        //    {
        //        dogIsLeftHandled = false;
        //    }

        //    DetermineHandlingPositions(startPosition, exercises, validationResults);

        //}

        public async Task CreatePropertyListsofExercisesAccordingToHandlingPosition(StartPositionEnum startPosition, List<Exercise> exercises, ValidationResults validationResults2) 
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
                        validationResults.ExerciseIdOnLefttHandledExercises.Add(exercise.ExerciseId);
                        continue;
                        
                    }
                    if (exercise.HandlingPosition == HandlingPositionEnum.Left)
                    {
                        dogIsLeftHandled = true;
                        validationResults.ExerciseIdOnLefttHandledExercises.Add(exercise.ExerciseId);
                        continue;
                    }
                    if (exercise.HandlingPosition == HandlingPositionEnum.Right)
                    {
                        dogIsLeftHandled = false;
                        validationResults.ExerciseIdOnRightHandledExercises.Add(exercise.ExerciseId);
                        continue;

                    }
                    if(exercise.HandlingPosition == HandlingPositionEnum.ChangeOfPosition) 
                    {
                        dogIsLeftHandled = false;
                        validationResults.ExerciseIdOnRightHandledExercises.Add(exercise.ExerciseId);
                        continue;

                    }
                }
                if (dogIsLeftHandled == false) 
                {
                    if (exercise.HandlingPosition == HandlingPositionEnum.Optional)
                    {
                        dogIsLeftHandled = false;
                        validationResults.ExerciseIdOnRightHandledExercises.Add(exercise.ExerciseId);
                        continue;
                    }
                    if (exercise.HandlingPosition == HandlingPositionEnum.Left) // er dette muligt?
                    {
                        dogIsLeftHandled = true;
                        validationResults.ExerciseIdOnLefttHandledExercises.Add(exercise.ExerciseId);
                        continue;
                    }
                    if (exercise.HandlingPosition == HandlingPositionEnum.Right)
                    {
                        dogIsLeftHandled = false;
                        validationResults.ExerciseIdOnRightHandledExercises.Add(exercise.ExerciseId);
                        continue;
                    }
                    if (exercise.HandlingPosition == HandlingPositionEnum.ChangeOfPosition)
                    {
                        dogIsLeftHandled = true;
                        validationResults.ExerciseIdOnLefttHandledExercises.Add(exercise.ExerciseId);
                        continue;
                    }
                }                
            }            
        }
    }
}
