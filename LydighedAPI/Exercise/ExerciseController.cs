using API.ViewModels;
using Core.Domain.Entities;
using Core.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

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
    public async Task<ActionResult<AddExerciseResponse>> AddExercise([FromBody] AddExerciseRequest addExerciseRequest)
    {
        if (addExerciseRequest == null) return BadRequest("viewModel was null");

        Exercise exercise =addExerciseRequest.ConvertToExercise();
        await _exerciseRepository.AddExercise(exercise);
        AddExerciseResponse addExerciseResponse = AddExerciseResponse.ConvertFromExercise(exercise);

        return Ok(addExerciseResponse);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateExercise([FromBody] UpdateExerciseRequest updateExerciseRequest)
    {
        if (updateExerciseRequest is null) return BadRequest("ViewModel was null");

        Exercise updatedExercise = updateExerciseRequest.ConvertToExercise();
        await _exerciseRepository.UpdateExercise(updatedExercise);

        return Ok();
    }

    [HttpGet("{exerciseId}", Name = "GetExercise")]
    public async Task<ActionResult<GetExerciseResponse>> GetExercise(int exerciseId)
    {
        if (exerciseId <= 0) return BadRequest("exerciseId must be greater than 0");

        Exercise? exercise = await _exerciseRepository.GetExercise(exerciseId);
        if (exercise == null) return NotFound($"exercise with id {exerciseId} not found");

        GetExerciseResponse getExerciseResponse = GetExerciseResponse.ConvertFromExercise(exercise);
        return Ok(getExerciseResponse);
    }

    [HttpDelete(Name = "DeleteExercise")]
    public async Task<IActionResult> DeleteExercise(int exerciseId)
    {
        if (exerciseId <= 0) return BadRequest("exerciseId must be greater than 0");

        await _exerciseRepository.DeleteExercise(exerciseId);

        return Ok();
    }

    [HttpGet(Name = "GetAllExercises")]
    public async Task<ActionResult<GetAllExercisesResponse>> GetAllExercises()
    {
        IEnumerable<Exercise> exercises = await _exerciseRepository.GetAllExercises();
        GetAllExercisesResponse getAllExercisesResponse = GetAllExercisesResponse.ConvertFromExercises(exercises);

        return getAllExercisesResponse.IsEmpty()
            ? NoContent()
            : Ok(getAllExercisesResponse);
    }
}