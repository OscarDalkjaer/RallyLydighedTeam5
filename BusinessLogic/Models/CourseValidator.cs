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

        //public bool ValidateOnlyRightPositionedBetweenTwoPositionChanges(Course course) 
        //{
        //    List<Exercise> exerciseList = course.ExerciseList;
        //    foreach (Exercise exercise in exerciseList) 
        //    {
                
        //    }
        //}
    }
}
