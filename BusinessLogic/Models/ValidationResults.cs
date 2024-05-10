using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class ValidationResults
    {
        public ValidationResults() { }

        public List<int> ExerciseIdOnRightHandledExercises { get; set; } = new List<int>();
        public List<int> ExerciseIdOnLefttHandledExercises { get; set; } = new List<int>();
    }



}
