using API.ViewModels;
using Core.Domain.Entities;
using Core.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/exercise")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseRepository _exerciseRepository;
        public ExerciseController(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }


        [HttpPost]
        public async Task<IActionResult> AddExercise([FromBody] AddExerciseRequest addExerciseRequestViewModel)
        {
            if (addExerciseRequestViewModel == null) return BadRequest("viewModel was null");

            Exercise exercise = new Exercise(
                addExerciseRequestViewModel.Number, 
                addExerciseRequestViewModel.Name, 
                addExerciseRequestViewModel.Description,
                addExerciseRequestViewModel.DefaultHandlingPosition, 
                addExerciseRequestViewModel.Stationary, 
                addExerciseRequestViewModel.WithCone,
                addExerciseRequestViewModel.TypeOfJump, 
                addExerciseRequestViewModel.Level);
            await _exerciseRepository.AddExercise(exercise);
            AddExerciseResponse responseViewModel = new AddExerciseResponse(
                exercise.Number,
                exercise.Name,
                exercise.Description,
                exercise.DefaultHandlingPosition,
                exercise.Stationary,
                exercise.WithCone,
                exercise.TypeOfJump,
                exercise.Level,
                exercise.ExerciseId
                );
            return Ok(responseViewModel);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateExercise([FromBody] UpdateExerciseRequest updateExerciseViewModel)
        {
            if (updateExerciseViewModel is null) return BadRequest("ViewModel was null");

            Exercise updatedExercise = updateExerciseViewModel.ConvertToExercise();
            await _exerciseRepository.UpdateExercise(updatedExercise);

            return Ok();
        }

        [HttpGet("{exerciseId}", Name = "GetExercise")]
        public async Task<IActionResult> GetExercise(int exerciseId)
        {
            if (exerciseId <= 0) return BadRequest("exerciseId must be greater than 0");

            Exercise? exercise = await _exerciseRepository.GetExercise(exerciseId);

            if (exercise == null) return NotFound($"exercise with id {exerciseId} not found");

            GetExerciseResponse getExerciseViewModel = GetExerciseResponse.ConvertFromExercise(exercise);
            return Ok(getExerciseViewModel);
        }

        [HttpDelete(Name = "DeleteExercise")]
        public async Task<IActionResult> DeleteExercise(int exerciseId)
        {
            if (exerciseId <= 0) return BadRequest("exerciseId must be greater than 0");

            await _exerciseRepository.DeleteExercise(exerciseId);
            return Ok();
        }

        [HttpGet(Name = "GetAllExercises")]
        public async Task<IActionResult> GetAllExercises()
        {
            IEnumerable<Exercise> exercises = await _exerciseRepository.GetAllExercises();
            GetAllExercisesResponse getAllExercisesViewModel = GetAllExercisesResponse.ConvertFromExercises(exercises);

            return getAllExercisesViewModel.Exercises.Count is 0
                ? NoContent()
                : Ok(getAllExercisesViewModel);
        }
    }
}