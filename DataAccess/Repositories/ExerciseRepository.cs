using BusinessLogic.Models;
using BusinessLogic.Services;
using DataAccessDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly CourseContext _context;
        public ExerciseRepository(CourseContext context)
        {
            _context = context;
        }

        public async Task AddExercise(int number, TypeEnum type)
        {
            if (type == null || number == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                _context.Exercises.Add(new Exercise(number, type));
            }
            await _context.SaveChangesAsync();
        }

        public Task DeleteExercise(int exerciseId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Exercise>> GetAllExercises()
        {
            throw new NotImplementedException();
        }

        public Task<Exercise?> GetExercise(int exerciseId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateExercise(Exercise exercise)
        {
            throw new NotImplementedException();
        }
    }
}
