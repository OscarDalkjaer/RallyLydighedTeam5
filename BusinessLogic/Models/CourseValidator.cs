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

        //public bool validateRighthandledExercises(Course course)
        //{
        //    CourseVa
        //}

    }
}


