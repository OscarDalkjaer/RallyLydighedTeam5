using BusinessLogic.Models;
using BusinessLogic.Services;
using DataAccessDbContext;
using Microsoft.EntityFrameworkCore;
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

        public async Task AddExercise(Exercise exercise)
        {
            if (exercise == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                _context.Exercises.Add(exercise);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Exercise>> GetAllExercises()
        {
            return await _context.Exercises.ToListAsync();
        }

        public async Task<Exercise?> GetExercise(int exerciseId)
        {
            {
                return _context.Exercises.FirstOrDefault(e => e.ExerciseId == exerciseId);
               
            }

        }

        public async Task UpdateExercise(Exercise exercise)
        {
            Exercise? exerciseToUpdate = _context.Exercises.SingleOrDefault(e => e.ExerciseId == exercise.ExerciseId);
            if (exerciseToUpdate != null)
            {
                exerciseToUpdate.Number = exercise.Number;
                exerciseToUpdate.Type = exercise.Type;
                await _context.SaveChangesAsync();
            }
       }

        public async Task DeleteExercise(int exerciseId)
        {
            Exercise? exercise = _context.Exercises.FirstOrDefault(e => e.ExerciseId == exerciseId);
            if (exercise != null)
            {
                _context.Exercises.Remove(exercise);
                await _context.SaveChangesAsync();
            }

        }
    }
}
