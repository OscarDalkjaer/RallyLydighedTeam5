using BusinessLogic.Models;
using BusinessLogic.Services;
using DataAccess.Repositories;
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

        [HttpPost(Name = "AddExercise")]
        public async Task AddExercise(int number, TypeEnum type)
        {
            await _exerciseRepository.AddExercise(number, type);
        }

      

        [HttpPut(Name = "UpdateExercise")]
        public async Task UpdateExercise(Exercise exercise)
        {
            throw new NotImplementedException();
        }

        [HttpGet(Name = "GetExercise")]
        public async Task GetExercise(Exercise exercise)
        {
            throw new NotImplementedException();
        }
    }
}