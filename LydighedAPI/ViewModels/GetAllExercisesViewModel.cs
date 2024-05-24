using Core.Domain.Entities;

namespace API.ViewModels
{
    public class GetAllExercisesViewModel
    {
        public required List<GetExerciseViewModel> Exercises { get; init; }

        public static GetAllExercisesViewModel ConvertFromExercises(IEnumerable<Exercise> exercises)
        {
            return new GetAllExercisesViewModel
            {
                Exercises = exercises
                .Select(exercise => GetExerciseViewModel.ConvertFromCourse(exercise))
                .ToList()
            };
        }
    }
}