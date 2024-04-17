using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IExerciseRepository
    {
        Task AddExercise(Exercise exercise);
        Task<Exercise?> GetExercise(int exerciseId);
        public Task<IEnumerable<Exercise>> GetAllExercises();
        Task UpdateExercise(Exercise exercise);
        Task DeleteExercise(int exerciseId);
    }
}
