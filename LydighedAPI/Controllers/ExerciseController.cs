using BusinessLogic.Models;
using BusinessLogic.Services;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ExerciseController
    {
        private readonly IExerciseRepository _exerciseRepository;
        public ExerciseController(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public void AddExercise(Exercise exercise)
        {
            throw new NotImplementedException();
        }
    }
}