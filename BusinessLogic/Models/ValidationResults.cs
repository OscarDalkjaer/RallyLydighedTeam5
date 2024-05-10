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

        public List<Exercise> ExerciseIdOnRightHandledExercises { get; set; } = new List<Exercise>();
        public List<Exercise> ExerciseIdOnLefttHandledExercises { get; set; } = new List<Exercise>();

        public int NumberOfExercisesLackingChangeOfPositionPrefix { get; set; }
        public  int NumberOfExercisesLackingChangeOfPositionSuffix { get; set; }
    }



}
