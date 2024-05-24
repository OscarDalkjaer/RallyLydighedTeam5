using BusinessLogic.Models;
using BusinessLogic.Services;

namespace Infrastructure
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
                exerciseToUpdate.Name = exercise.Name;
                exerciseToUpdate.Description = exercise.Description;
                exerciseToUpdate.DefaultHandlingPosition = exercise.DefaultHandlingPosition;
                exerciseToUpdate.Stationary = exercise.Stationary;
                exerciseToUpdate.WithCone = exercise.WithCone;
                exerciseToUpdate.TypeOfJump = exercise.TypeOfJump;
                exerciseToUpdate.Level = exercise.Level;
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

        public async Task SeedNullExercise()
        {
            Exercise? nullExercise = await GetExercise(1);
            if (nullExercise == null)
            {
                Exercise exercise = new Exercise(1, 0, "", "", DefaultHandlingPositionEnum.Right, false, false, null, null);
                TestExercises.Add(exercise);
            }
        }

        public Task<List<Exercise>> GetExercisesFromNumbers(List<int> exerciseNumbers)
        {
            List<Exercise> exercises = new List<Exercise>();
            foreach (int number in exerciseNumbers)
            {
                Exercise exercise = TestExercises.SingleOrDefault(x => x.Number == number);
                exercises.Add(exercise);
            }
            return Task.FromResult(exercises);
        }

        Task<(List<Exercise>, List<string>)> IExerciseRepository.GetExercisesFromNumbers(List<int> exerciseNumbers)
        {
            throw new NotImplementedException();
        }
    }
}