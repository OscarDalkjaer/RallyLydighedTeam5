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
            bool handlingPositionOfPreviousExerciseIsChangeOfPosition;
            bool handlingPositionOfActualExerciseIsChangeOfPosition;

            try
            {
                foreach (var item in rightHandledExerises)
                {
                    int id = item.Item1;
                    int index = course.ExerciseList.FindIndex(x => x.ExerciseId == item.Item1);

                    HandlingPositionEnum previousExerciseHandlingPosition = course.ExerciseList[index - 1].HandlingPosition;
                    handlingPositionOfPreviousExerciseIsChangeOfPosition = previousExerciseHandlingPosition == HandlingPositionEnum.ChangeOfPosition;

                    handlingPositionOfActualExerciseIsChangeOfPosition = course.ExerciseList[index].HandlingPosition == HandlingPositionEnum.ChangeOfPosition;

                    if (handlingPositionOfPreviousExerciseIsChangeOfPosition == false || handlingPositionOfActualExerciseIsChangeOfPosition == false)
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

        public bool ValidateMaxNumberOfRepeatedRightHandledExercises(List<(int, int, string, bool)> rightHandledExerises, Course course)
        {
            HandlingPositionEnum startPosition = HandlingPositionEnum.Left;
            List<(int, int, string, bool)> courseVisualised = _visualizer.VisualiseCourse(course, startPosition);
            
            bool validationOfExpertLevel = true;
            bool validationOfChampionLevel = true;
            int max = course.GetMaxRepeatedRightHandledExercises(course.Level);

            foreach (var rightHandled in rightHandledExerises)
            {
                int id = rightHandled.Item1;
                int index = courseVisualised.FindIndex(visualised => visualised.Item2 == rightHandled.Item1);

                if(index-1 < 0 || index-2 < 0 ) { continue; }

                bool previousExerciseIsRightHandlet = !courseVisualised[index - 1].Item4;
                bool exerciseSecondBeforeExerciseIsRightHandlet= !courseVisualised[index - 2].Item4;
               
                // Validation of ExpertLevel
                if (previousExerciseIsRightHandlet == true)
                {
                    validationOfExpertLevel = !exerciseSecondBeforeExerciseIsRightHandlet;
                    if (validationOfExpertLevel == false)
                    {
                        throw new Exception($"Max {max} repeated RightHandled exercises, error at ecerciseId: {id}");
                    }
                                       
                }
                // Validation of ChampionLevel
                if (index - 3 < 0) { continue; }
                bool exerciseThirdBeforeExerciseIsRightHandlet = !course.ExerciseList[index - 3].LeftHandlet;

                if (previousExerciseIsRightHandlet == true && exerciseSecondBeforeExerciseIsRightHandlet == true)
                    
                    validationOfChampionLevel = !exerciseThirdBeforeExerciseIsRightHandlet;
                    if (validationOfChampionLevel == false)
                    {
                        throw new Exception($"Max {max} repeated RightHandled exercises, error at ecerciseId: {id}");
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
    }

                

}


