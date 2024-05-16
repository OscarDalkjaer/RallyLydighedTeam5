using BusinessLogic.Models;

namespace API.ViewModels
{
    public class GetAllExercisesViewModel
    {
        public List<GetExerciseViewModel> Exercises { get; set; }

        public GetAllExercisesViewModel(IEnumerable<Exercise> exercises)

        {
            Exercises = exercises
                .Select(e => new GetExerciseViewModel(e.ExerciseId, e.Number, e.Name, e.Description, e.DefaultHandlingPosition,
            e.Stationary, e.WithCone, e.TypeOfJump, e.Level))
                .ToList();
        }
    }
}
