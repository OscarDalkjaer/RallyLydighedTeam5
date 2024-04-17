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
using API.ViewModels;

namespace RallyTests
{
    [TestClass]
    public class ExerciseControllerTests
    {
        [TestMethod]
        public async Task TestAddExercise()
        {
            //Arrange
            ExerciseTestRepository testRepository = new ExerciseTestRepository();
            ExerciseController exerciseController = new ExerciseController(testRepository);
            AddExerciseViewModel addExerciseViewModel = new AddExerciseViewModel(1, TypeEnum.Cone);


            //Act
            exerciseController.AddExercise(addExerciseViewModel);


            //Assert
            Assert.AreEqual(testRepository.exercises.Count(), 1);
        }

        [TestMethod]
        public async Task TestGetExercise()
        {
            //Arrange
            ExerciseTestRepository testRepository = new ExerciseTestRepository();
            ExerciseController exerciseController = new ExerciseController(testRepository);
            AddExerciseViewModel addExerciseViewModel = new AddExerciseViewModel(1, TypeEnum.Cone);
            await exerciseController.AddExercise(addExerciseViewModel);

            //Act
            GetExerciseViewModel exerciseVM = await exerciseController.GetExercise(1);


            //Assert
            Assert.AreEqual(exerciseVM.GetExerciseId, 1);
            Assert.AreEqual(exerciseVM.Type, TypeEnum.Cone);

        }

        [TestMethod]
        public async Task TestGetAllExercises()
        {
            //Arrange
            ExerciseTestRepository testRepository = new ExerciseTestRepository();
            ExerciseController exerciseController = new ExerciseController(testRepository);
            AddExerciseViewModel addExerciseViewModel = new AddExerciseViewModel(1, TypeEnum.Cone);
            AddExerciseViewModel addExerciseViewModel1 = new AddExerciseViewModel(2, TypeEnum.Cone);
            await exerciseController.AddExercise(addExerciseViewModel);
            await exerciseController.AddExercise(addExerciseViewModel1);

            //Act
            IEnumerable<GetExerciseViewModel> exerciseVMs = await exerciseController.GetAllExercises();
            int count = exerciseVMs.Count();


            //Assert
            Assert.AreEqual(count, 2);

        }

        [TestMethod]
        public async Task TestUpdateExercise()
        {
            //Arrange
            ExerciseTestRepository testRepository = new ExerciseTestRepository();
            ExerciseController exerciseController = new ExerciseController(testRepository);
            AddExerciseViewModel addExerciseViewModel = new AddExerciseViewModel(1, TypeEnum.Cone);            
            await exerciseController.AddExercise(addExerciseViewModel);
            UpdateExerciseViewModel updatedVM = new UpdateExerciseViewModel(2, TypeEnum.Standard, 1);

            //Act
            await exerciseController.UpdateExercise(updatedVM);

            //Assert
            Assert.AreEqual(testRepository.exercises[0].Number, 2);
            Assert.AreEqual(testRepository.exercises[0].ExerciseId, 1);
            Assert.AreEqual(testRepository.exercises[0].Type, TypeEnum.Standard);
            
        }

        [TestMethod]
        public async Task TestDeleteExercise() 
        {
            //Arrange
            ExerciseTestRepository testRepository = new ExerciseTestRepository();
            ExerciseController exerciseController = new ExerciseController(testRepository);
            AddExerciseViewModel addExerciseViewModel = new AddExerciseViewModel(1, TypeEnum.Cone);
            await exerciseController.AddExercise(addExerciseViewModel);

            //Act
            await exerciseController.DeleteExercise(1);
            int count = testRepository.exercises.Count();

            //Assert
            Assert.AreEqual(count, 0);

        }
    }
}
