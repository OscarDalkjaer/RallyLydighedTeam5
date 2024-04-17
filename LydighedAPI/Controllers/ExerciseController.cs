using API.ViewModels;
using BusinessLogic.Models;
using BusinessLogic.Services;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        [HttpPost(Name = "AddExercise")]
        public async Task AddExercise(int number, TypeEnum type)
        {
            await _exerciseRepository.AddExercise(number, type);
        }

        [HttpPut(Name = "UpdateExercise")]
        public async Task UpdateExercise(Exercise exercise)
        {
            await _exerciseRepository.UpdateExercise(exercise);
        }

        [HttpGet("{exerciseId}", Name = "GetExercise")]
        public async Task<GetExerciseViewModel> GetExercise(int exerciseId)
        {
           
            Exercise exercise = await _exerciseRepository.GetExercise(exerciseId);
            GetExerciseViewModel getExerciseViewModel = new GetExerciseViewModel(exerciseId, exercise.Number, exercise.Type);
            return getExerciseViewModel;
        
        }
       

        [HttpDelete(Name = "DeleteExercise")]
        public async Task DeleteExercise(int exerciseId)
        {
            await _exerciseRepository.DeleteExercise(exerciseId);
        }

        [HttpGet(Name = "GetAllExercises")]
        public async Task<IEnumerable<GetExerciseViewModel>> GetAllExercises()
        {
            IEnumerable<Exercise> exercises = await _exerciseRepository.GetAllExercises();
            IEnumerable<GetExerciseViewModel> getExerciseViewModels = exercises.Select(e => new GetExerciseViewModel(e.ExerciseId, e.Number, e.Type));
            return getExerciseViewModels;
        }

    }
}