using BusinessLogic.Models;
using BusinessLogic.Services;

namespace DataAccess
{
    public class ExerciseTestRepository : IExerciseRepository
    {
        public List<Exercise> exercises = new List<Exercise>();

        public Task AddExercise(int number, TypeEnum type)
        {
            throw new NotImplementedException();
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

        //public async Task AddExercise(LevelEnum level)
        //{
        //    int courseId = TestExercises.Count + 1;
        //    Exercise exercise = new Exercise(level);
        //    exercise.ExerciseId = exerciseId;
        //    TestExercises.Add(exercise);
        //    await Task.CompletedTask;
        //}
    }
}