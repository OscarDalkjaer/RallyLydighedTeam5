﻿using API.ViewModels;
using BusinessLogic.Models;
using BusinessLogic.Services;
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
        public async Task<IActionResult> AddExercise([FromBody] AddExerciseViewModel addExerciseViewModel)
        {
            if (addExerciseViewModel == null) return BadRequest("viewModel was null");

            Exercise exercise = new Exercise(addExerciseViewModel.Number, addExerciseViewModel.Type);
            await _exerciseRepository.AddExercise(exercise);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateExercise([FromBody] UpdateExerciseViewModel updateExerciseViewModel)
        {
            if (updateExerciseViewModel is null) return BadRequest("ViewModel was null");

            Exercise updatedExercise = new Exercise(
                updateExerciseViewModel.UpdateExerciseViewModelId,
                updateExerciseViewModel.Number,
                updateExerciseViewModel.Type);

            await _exerciseRepository.UpdateExercise(updatedExercise);

            return Ok();
        }

        [HttpGet("{exerciseId}", Name = "GetExercise")]
        public async Task<IActionResult> GetExercise(int exerciseId)
        {
            if (exerciseId <= 0) return BadRequest("exerciseId must be greater than 0");

            Exercise? exercise = await _exerciseRepository.GetExercise(exerciseId);

            if (exercise == null) return NotFound($"exercise with id {exerciseId} not found");

            GetExerciseViewModel getExerciseViewModel = new GetExerciseViewModel(exerciseId, exercise.Number, exercise.Type);
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
            GetAllExercisesViewModel getAllExercisesViewModel = new GetAllExercisesViewModel(exercises);

            return getAllExercisesViewModel.Exercises.Count is 0
                ? NoContent()
                : Ok(getAllExercisesViewModel);
        }
    }
}