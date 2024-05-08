using BusinessLogic.Models;
using BusinessLogic.Services;

namespace DataAccess
{
    public class ExerciseTestRepository : IExerciseRepository
    {
        public List<Exercise> TestExercises { get; } = new List<Exercise>();

        public ExerciseTestRepository() 
        {
            SeedNullExercise();
        }

        public async Task AddExercise(Exercise exercise)
        {

            exercise.ExerciseId = TestExercises.Count + 1;
            TestExercises.Add(exercise);
            await Task.CompletedTask;

        }

        public async Task<Exercise?> GetExercise(int exerciseId)
        {
            Exercise? exercise = TestExercises.SingleOrDefault(e => e.ExerciseId == exerciseId);
            return await Task.FromResult(exercise);
        }

        public async Task<IEnumerable<Exercise>> GetAllExercises()
        {
            return await Task.FromResult(TestExercises);
        }

        public async Task UpdateExercise(Exercise exercise)
        {
            Exercise? exerciseToUpdate = TestExercises.SingleOrDefault(e => e.ExerciseId == exercise.ExerciseId);

            if (exerciseToUpdate != null)
            {
                exerciseToUpdate.Number = exercise.Number;
                exerciseToUpdate.Type = exercise.Type;
            }

            await Task.CompletedTask;
        }


        public async Task DeleteExercise(int exerciseId)
        {
            Exercise? exercise = TestExercises.SingleOrDefault(e => e.ExerciseId == exerciseId);
            if (exercise != null)
            {
                TestExercises.Remove(exercise);
            }
            await Task.CompletedTask;
        }

        //public async Task<Exercise> GetNullExercise()
        //{
        //    Exercise? nullExercise = await GetExercise(1);
        //    if (nullExercise == null)
        //    {
        //        Exercise exercise = new Exercise(1, 0, null);
        //        TestExercises.Add(exercise);
        //        return exercise;
        //    }
        //    return nullExercise;

        //}

        public async Task SeedNullExercise()
        {
            Exercise? nullExercise = await GetExercise(1);
            if (nullExercise == null)
            {
                Exercise exercise = new Exercise(1, 0, null);
                TestExercises.Add(exercise);
               
            }
                        
        }






    }
}