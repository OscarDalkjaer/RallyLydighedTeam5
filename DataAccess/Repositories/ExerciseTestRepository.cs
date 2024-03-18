using BusinessLogic.Models;
using BusinessLogic.Services;

namespace DataAccess
{
    public class ExerciseTestRepository : IExerciseRepository
    {
        public List<Exercise> exercises = new List<Exercise>();

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