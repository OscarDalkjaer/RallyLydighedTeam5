using API.Controllers;
using BusinessLogic.Models;
using DataAccess;
using API.ViewModels;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;

namespace RallyTests;

[TestClass]
public class ExerciseControllerTests
{
    private readonly ExerciseTestRepository testRepository;
    private readonly ExerciseController exerciseController;

    public ExerciseControllerTests()
    {
        testRepository = new ExerciseTestRepository();
        exerciseController = new ExerciseController(testRepository);
    }

    [TestMethod]
    public async Task TestAddExercise()
    {
        //Arrange
        AddExerciseViewModel addExerciseViewModel = new AddExerciseViewModel(1, TypeEnum.Cone);


        //Act
        await exerciseController.AddExercise(addExerciseViewModel);


        //Assert
        Assert.AreEqual(1, testRepository.TestExercises.Count);
           
    }

    [TestMethod]
    public async Task TestGetExercise()
    {
        //Arrange
        AddExerciseViewModel addExerciseViewModel = new AddExerciseViewModel(1, TypeEnum.Cone);
        await exerciseController.AddExercise(addExerciseViewModel);

        //Act

       
        GetExerciseViewModel getExerciseViewModel = (await exerciseController.GetExercise(1)).GetValueAs<GetExerciseViewModel>();


        //Assert
        Assert.AreEqual(getExerciseViewModel.GetExerciseId, 1);
        Assert.AreEqual(getExerciseViewModel.Type, TypeEnum.Cone);

    }

    [TestMethod]
    public async Task TestGetAllExercises()
    {
        //Arrange
        AddExerciseViewModel addExerciseViewModel = new AddExerciseViewModel(1, TypeEnum.Cone);
        AddExerciseViewModel addExerciseViewModel1 = new AddExerciseViewModel(2, TypeEnum.Standard);
        await exerciseController.AddExercise(addExerciseViewModel);
        await exerciseController.AddExercise(addExerciseViewModel1);

        //Act
       GetAllExercisesViewModel getAllExerciseViewModel = (await exerciseController.GetAllExercises())
            .GetValueAs<GetAllExercisesViewModel>();

        //Assert
        Assert.AreEqual(1, getAllExerciseViewModel.Exercises[0].GetExerciseId);
        Assert.AreEqual(TypeEnum.Cone, getAllExerciseViewModel.Exercises[0].Type);
        Assert.AreEqual(2, getAllExerciseViewModel.Exercises[1].Number);
        Assert.AreEqual(TypeEnum.Cone, getAllExerciseViewModel.Exercises[1].Type);

    }

    [TestMethod]
    public async Task TestUpdateExercise()
    {
        //Arrange
        AddExerciseViewModel addExerciseViewModel = new AddExerciseViewModel(1, TypeEnum.Cone);            
        UpdateExerciseViewModel updatedExerciseViewModel = new UpdateExerciseViewModel(2, TypeEnum.Standard, 1);
        await exerciseController.AddExercise(addExerciseViewModel);

        //Act
        IActionResult result = await exerciseController.UpdateExercise(updatedExerciseViewModel);

        //Assert
        Assert.IsInstanceOfType<OkObjectResult>(result);
        Assert.AreEqual(testRepository.TestExercises[0].Number, 2);
        Assert.AreEqual(testRepository.TestExercises[0].ExerciseId, 1);
        Assert.AreEqual(testRepository.TestExercises[0].Type, TypeEnum.Standard);
    }

    [TestMethod]
    public async Task TestDeleteExercise() 
    {
        //Arrange
        AddExerciseViewModel addExerciseViewModel = new AddExerciseViewModel(1, TypeEnum.Cone);
        await exerciseController.AddExercise(addExerciseViewModel);

        //Act
        IActionResult result = await exerciseController.DeleteExercise(1);
        

        //Assert
        Assert.IsInstanceOfType<OkObjectResult>(result);
        Assert.AreEqual(0, testRepository.TestExercises.Count);
    }
}
