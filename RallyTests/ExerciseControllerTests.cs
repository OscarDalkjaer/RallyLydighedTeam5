using API.Controllers;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Models;
using BusinessLogic.Services;
using BusinessLogic;
using DataAccess;

namespace RallyTests
{
    public class ExerciseControllerTests
    {
        [TestMethod]
        public async Task TestAddExercise()
        {
            //Arrange
            ExerciseTestRepository testRepository = new ExerciseTestRepository();
            ExerciseController exerciseController = new ExerciseController(testRepository);
            Exercise exercise = new Exercise(1, 1, LevelEnum.Beginner, TypeEnum.Cone);
            testRepository.exercises.Clear();


            //Act
            exerciseController.AddExercise(exercise);


            //Assert
            Assert.AreEqual(testRepository.exercises.Count(), 1);


        }


    }
}
