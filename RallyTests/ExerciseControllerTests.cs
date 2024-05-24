using API.Controllers;
using BusinessLogic.Models;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Infrastructure;

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
        AddExerciseRequestViewModel addExerciseViewModel = new AddExerciseRequestViewModel(1, "Jump", "JumpForJoy", 
            DefaultHandlingPositionEnum.Right, true, false, jumpEnum.DoubleJump, LevelEnum.Beginner);
        


        //Act
        await exerciseController.AddExercise(addExerciseViewModel);


        //Assert
        Assert.AreEqual(2, testRepository.TestExercises.Count);
        Assert.AreEqual(2, testRepository.TestExercises[1].ExerciseId);

    }

    [TestMethod]
    public async Task TestGetExercise()
    {
        //Arrange
        AddExerciseRequestViewModel addExerciseRequestViewModel = new AddExerciseRequestViewModel(1, "Jump", "JumpForJoy", DefaultHandlingPositionEnum.Left, 
            true, false, jumpEnum.DoubleJump, LevelEnum.Beginner);
        await exerciseController.AddExercise(addExerciseRequestViewModel);

        //Act


        GetExerciseViewModel getExerciseViewModel = (await exerciseController.GetExercise(2)).GetValueAs<GetExerciseViewModel>();


        //Assert
        Assert.AreEqual(2, getExerciseViewModel.GetExerciseId);
        Assert.AreEqual("Jump", getExerciseViewModel.Name);
        Assert.AreEqual("JumpForJoy", getExerciseViewModel.Description);
        Assert.AreEqual(DefaultHandlingPositionEnum.Left, getExerciseViewModel.DefaultHandlingPosition);
        Assert.AreEqual(true, getExerciseViewModel.Stationary);
        Assert.AreEqual(false, getExerciseViewModel.WithCone);
        Assert.AreEqual(jumpEnum.DoubleJump, getExerciseViewModel.TypeOfJump);
        Assert.AreEqual(LevelEnum.Beginner, getExerciseViewModel.Level);
    }

    [TestMethod]
    public async Task TestGetAllExercises()
    {
        //Arrange
        await exerciseController.AddExercise(new AddExerciseRequestViewModel(1, "Jump", "JumpForJoy",
            DefaultHandlingPositionEnum.Optional, true, false, jumpEnum.DoubleJump, LevelEnum.Beginner));
        await exerciseController.AddExercise(new AddExerciseRequestViewModel(2, "DoubleJump", "JumpALot",
            DefaultHandlingPositionEnum.Right, false, true, jumpEnum.DoubleJump, LevelEnum.Advanced));

        //Act
        GetAllExercisesViewModel getAllExerciseViewModel = (await exerciseController.GetAllExercises())
            .GetValueAs<GetAllExercisesViewModel>();

        //Assert
        Assert.AreEqual(2, getAllExerciseViewModel.Exercises[1].GetExerciseId);
        Assert.AreEqual("Jump", getAllExerciseViewModel.Exercises[1].Name);
        Assert.AreEqual("JumpForJoy", getAllExerciseViewModel.Exercises[1].Description);
        Assert.AreEqual(DefaultHandlingPositionEnum.Optional, getAllExerciseViewModel.Exercises[1].DefaultHandlingPosition);
        Assert.AreEqual(true, getAllExerciseViewModel.Exercises[1].Stationary);
        Assert.AreEqual(false, getAllExerciseViewModel.Exercises[1].WithCone);
        Assert.AreEqual(jumpEnum.DoubleJump, getAllExerciseViewModel.Exercises[1].TypeOfJump);
        Assert.AreEqual(LevelEnum.Beginner, getAllExerciseViewModel.Exercises[1].Level);

        Assert.AreEqual(3, getAllExerciseViewModel.Exercises[2].GetExerciseId);
        Assert.AreEqual("DoubleJump", getAllExerciseViewModel.Exercises[2].Name);
        Assert.AreEqual("JumpALot", getAllExerciseViewModel.Exercises[2].Description);
        Assert.AreEqual(DefaultHandlingPositionEnum.Right, getAllExerciseViewModel.Exercises[2].DefaultHandlingPosition);
        Assert.AreEqual(false, getAllExerciseViewModel.Exercises[2].Stationary);
        Assert.AreEqual(true, getAllExerciseViewModel.Exercises[2].WithCone);
        Assert.AreEqual(jumpEnum.DoubleJump, getAllExerciseViewModel.Exercises[2].TypeOfJump);
        Assert.AreEqual(LevelEnum.Advanced, getAllExerciseViewModel.Exercises[2].Level);


    }

    [TestMethod]
    public async Task TestUpdateExercise()
    {
        //Arrange
        AddExerciseRequestViewModel addExerciseRequestViewModel = new AddExerciseRequestViewModel(1, "Jump", "JumpForJoy",
            DefaultHandlingPositionEnum.Optional, true, false, jumpEnum.DoubleJump, LevelEnum.Beginner);
        UpdateExerciseRequestViewModel updatedExerciseViewModel = new UpdateExerciseRequestViewModel(1, 1, "MegaJump", "JumpForJoy",
            DefaultHandlingPositionEnum.ChangeOfPosition, true, false, jumpEnum.DoubleJump, LevelEnum.Beginner);

        //Act
        IActionResult result = await exerciseController.UpdateExercise(updatedExerciseViewModel);

        //Assert
        Assert.IsInstanceOfType<OkResult>(result);
        Assert.AreEqual(1, testRepository.TestExercises[0].Number);
        Assert.AreEqual(1, testRepository.TestExercises[0].ExerciseId);
        Assert.AreEqual("MegaJump",testRepository.TestExercises[0].Name);
    }

    [TestMethod]
    public async Task TestDeleteExercise()
    {
        //Arrange
        AddExerciseRequestViewModel addExerciseRequestViewModel = new AddExerciseRequestViewModel(1, "Jump", "JumpForJoy",
            DefaultHandlingPositionEnum.ChangeOfPosition, true, false, jumpEnum.DoubleJump, LevelEnum.Beginner);
        await exerciseController.AddExercise(addExerciseRequestViewModel);

        //Act
        IActionResult result = await exerciseController.DeleteExercise(1);


        //Assert
        Assert.IsInstanceOfType<OkResult>(result);
        Assert.AreEqual(1, testRepository.TestExercises.Count);
    }

    



}
