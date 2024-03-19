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

        [HttpPost]
        public void AddExercise(Exercise exercise)
        {
            throw new NotImplementedException();
        }
    }
}