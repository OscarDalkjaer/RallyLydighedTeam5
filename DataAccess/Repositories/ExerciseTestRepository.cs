using BusinessLogic.Models;
using BusinessLogic.Services;

namespace DataAccess
{
    public class ExerciseTestRepository : IExerciseRepository
    {
        public List<Exercise> exercises = new List<Exercise>();

        public Task AddExercise(Exercise exercise)
        {
            int id = exercises.Count()+1;
            exercise.ExerciseId = id;
            exercises.Add(exercise);
            return Task.CompletedTask;
        }

        public async Task<Exercise?> GetExercise(int exerciseId)
        {
            Exercise? exercise = exercises.FirstOrDefault(e => e.ExerciseId == exerciseId);
            return await Task.FromResult(exercise);
        }

        public async Task<IEnumerable<Exercise>> GetAllExercises()
        {
            IEnumerable<Exercise> exercisess = exercises;
            return await Task.FromResult(exercisess);
        }

        public async Task UpdateExercise(Exercise exercise)
        {
            Exercise? exerciseToUpdate = exercises.FirstOrDefault(e => e.ExerciseId == exercise.ExerciseId);
            exerciseToUpdate.Number = exercise.Number;
            exerciseToUpdate.Type = exercise.Type;
            await Task.CompletedTask;
        }

      
        public async Task DeleteExercise(int exerciseId)
        {
            Exercise? exercise = exercises.FirstOrDefault(e => e.ExerciseId == exerciseId);
            if (exercise == null)
            {
                throw new Exception();
            }
            exercises.Remove(exercise);
            await Task.CompletedTask;
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