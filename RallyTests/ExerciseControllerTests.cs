using API.Controllers;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Infrastructure;
using Core.Domain.Entities;

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
        AddExerciseRequest addExerciseViewModel = new AddExerciseRequest(1, "Jump", "JumpForJoy", DefaultHandlingPositionEnum.Right, true, false, JumpEnum.DoubleJump, LevelEnum.Beginner);

        //Act
        AddExerciseResponse response = (await exerciseController.AddExercise(addExerciseViewModel)).GetValueAs<AddExerciseResponse>();

        //Assert
        Assert.AreEqual(1, testRepository.TestExercises.Count);

        Assert.AreEqual("Jump", response.Name);
        Assert.AreEqual("JumpForJoy", response.Description);
        Assert.AreEqual(DefaultHandlingPositionEnum.Right, response.DefaultHandlingPosition);
        Assert.AreEqual(true, response.Stationary);
        Assert.AreEqual(false, response.WithCone);
        Assert.AreEqual(JumpEnum.DoubleJump, response.TypeOfJump);
        Assert.AreEqual(LevelEnum.Beginner, response.Level);

    }

    [TestMethod]
    public async Task TestGetExercise()
    {
        //Arrange
        await testRepository.AddExercise(new Exercise(2, 1, "Jump", "JumpForJoy", DefaultHandlingPositionEnum.Left, true, false, JumpEnum.DoubleJump, LevelEnum.Beginner));

        //Act
        GetExerciseResponse getExerciseViewModel = (await exerciseController.GetExercise(2)).GetValueAs<GetExerciseResponse>();

        //Assert
        Assert.AreEqual(2, getExerciseViewModel.GetExerciseId);
        Assert.AreEqual("Jump", getExerciseViewModel.Name);
        Assert.AreEqual("JumpForJoy", getExerciseViewModel.Description);
        Assert.AreEqual(DefaultHandlingPositionEnum.Left, getExerciseViewModel.DefaultHandlingPosition);
        Assert.AreEqual(true, getExerciseViewModel.Stationary);
        Assert.AreEqual(false, getExerciseViewModel.WithCone);
        Assert.AreEqual(JumpEnum.DoubleJump, getExerciseViewModel.TypeOfJump);
        Assert.AreEqual(LevelEnum.Beginner, getExerciseViewModel.Level);
    }

    [TestMethod]
    public async Task TestGetAllExercises()
    {
        //Arrange
        await testRepository.AddExercise(new Exercise(1, "Jump", "JumpForJoy", DefaultHandlingPositionEnum.Optional, true, false, JumpEnum.DoubleJump, LevelEnum.Beginner));
        await testRepository.AddExercise(new Exercise(2, "DoubleJump", "JumpALot", DefaultHandlingPositionEnum.Right, false, true, JumpEnum.DoubleJump, LevelEnum.Advanced));

        //Act
        GetAllExercisesResponse getAllExerciseViewModel = (await exerciseController.GetAllExercises()).GetValueAs<GetAllExercisesResponse>();

        //Assert
        Assert.AreEqual(2, getAllExerciseViewModel.Exercises.Count);
    }

    [TestMethod]
    public async Task TestUpdateExercise()
    {
        //Arrange
        await testRepository.AddExercise(new Exercise(exerciseId: 1, 1, "Jump", "JumpForJoy", DefaultHandlingPositionEnum.Optional, true, false, JumpEnum.DoubleJump, LevelEnum.Beginner));
        UpdateExerciseRequest updatedExerciseViewModel = new UpdateExerciseRequest
        {
            UpdateExerciseRequestViewModelId = 1,
            Number = 1,
            Name = "MegaJump",
            Description = "JumpForJoy",
            DefaultHandlingPosition = DefaultHandlingPositionEnum.ChangeOfPosition,
            Stationary = true,
            WithCone = false,
            TypeOfJump = JumpEnum.DoubleJump,
            Level = LevelEnum.Beginner
        };

        //Act
        IActionResult result = await exerciseController.UpdateExercise(updatedExerciseViewModel);

        //Assert
        Assert.IsInstanceOfType<OkResult>(result);
        Assert.AreEqual(1, testRepository.TestExercises[0].ExerciseId);
        Assert.AreEqual("MegaJump", testRepository.TestExercises[0].Name);
    }

    [TestMethod]
    public async Task TestDeleteExercise()
    {
        //Arrange
        await testRepository.AddExercise(new Exercise(1, 1, "Jump", "JumpForJoy", DefaultHandlingPositionEnum.ChangeOfPosition, true, false, JumpEnum.DoubleJump, LevelEnum.Beginner));

        //Act
        IActionResult result = await exerciseController.DeleteExercise(1);

        //Assert
        Assert.IsInstanceOfType<OkResult>(result);
        Assert.AreEqual(0, testRepository.TestExercises.Count);
    }
}
