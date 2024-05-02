using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccessModels
{
     public class ExerciseDataAccessModel
    {
        public int ExerciseId { get; set; }
        public int? Number { get; set; }
        public TypeEnum? Type { get; set; }
        protected ExerciseDataAccessModel() { }

        public ExerciseDataAccessModel(int exerciseId, int? number, TypeEnum? type) 
        {
            ExerciseId = exerciseId;
            Number = number;
            Type = type;

        }
    }
}
