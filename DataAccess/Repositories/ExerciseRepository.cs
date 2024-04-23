using BusinessLogic.Models;
using BusinessLogic.Services;
using DataAccessDbContext;
using Microsoft.EntityFrameworkCore;

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
        
            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Exercise>> GetAllExercises()
        {
            return await _context.Exercises.ToListAsync();
        }

        public async Task<Exercise?> GetExercise(int exerciseId)
        {
            {
                return  await _context.Exercises.FirstOrDefaultAsync(e => e.ExerciseId == exerciseId);
            }

        }

        public async Task UpdateExercise(Exercise exercise)
        {
            Exercise? exerciseToUpdate = await _context.Exercises
                .SingleOrDefaultAsync(e => e.ExerciseId == exercise.ExerciseId);
            
            if (exerciseToUpdate != null)
            {
                exerciseToUpdate.Number = exercise.Number;
                exerciseToUpdate.Type = exercise.Type;
                await _context.SaveChangesAsync();
            }
       }

        public async Task DeleteExercise(int exerciseId)
        {
            Exercise? exercise =await _context.Exercises.FirstOrDefaultAsync(e => e.ExerciseId == exerciseId);
            if (exercise != null)
            {
                _context.Exercises.Remove(exercise);
                await _context.SaveChangesAsync();
            }

        }
    }
}
