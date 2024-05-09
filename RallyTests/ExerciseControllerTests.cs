using API.Controllers;
using BusinessLogic.Models;
using DataAccess;
using API.ViewModels;
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
        AddExerciseViewModel addExerciseViewModel = new AddExerciseViewModel(1, "Jump", "JumpForJoy", 
            HandlingPositionEnum.Right, true, false, jumpEnum.DoubleJump, LevelEnum.Beginner);
        


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
        AddExerciseViewModel addExerciseViewModel = new AddExerciseViewModel(1, "Jump", "JumpForJoy", HandlingPositionEnum.Left, 
            true, false, jumpEnum.DoubleJump, LevelEnum.Beginner);
        await exerciseController.AddExercise(addExerciseViewModel);

        //Act


        GetExerciseViewModel getExerciseViewModel = (await exerciseController.GetExercise(2)).GetValueAs<GetExerciseViewModel>();


        //Assert
        Assert.AreEqual(2, getExerciseViewModel.GetExerciseId);
        Assert.AreEqual("Jump", getExerciseViewModel.Name);
        Assert.AreEqual("JumpForJoy", getExerciseViewModel.Description);
        Assert.AreEqual(HandlingPositionEnum.Left, getExerciseViewModel.HandlingPosition);
        Assert.AreEqual(true, getExerciseViewModel.Stationary);
        Assert.AreEqual(false, getExerciseViewModel.WithCone);
        Assert.AreEqual(jumpEnum.DoubleJump, getExerciseViewModel.TypeOfJump);
        Assert.AreEqual(LevelEnum.Beginner, getExerciseViewModel.Level);
    }

    [TestMethod]
    public async Task TestGetAllExercises()
    {
        //Arrange
        await exerciseController.AddExercise(new AddExerciseViewModel(1, "Jump", "JumpForJoy",
            HandlingPositionEnum.Optional, true, false, jumpEnum.DoubleJump, LevelEnum.Beginner));
        await exerciseController.AddExercise(new AddExerciseViewModel(2, "DoubleJump", "JumpALot",
            HandlingPositionEnum.Right, false, true, jumpEnum.DoubleJump, LevelEnum.Advanced));

        //Act
        GetAllExercisesViewModel getAllExerciseViewModel = (await exerciseController.GetAllExercises())
            .GetValueAs<GetAllExercisesViewModel>();

        //Assert
        Assert.AreEqual(2, getAllExerciseViewModel.Exercises[1].GetExerciseId);
        Assert.AreEqual("Jump", getAllExerciseViewModel.Exercises[1].Name);
        Assert.AreEqual("JumpForJoy", getAllExerciseViewModel.Exercises[1].Description);
        Assert.AreEqual(HandlingPositionEnum.Optional, getAllExerciseViewModel.Exercises[1].HandlingPosition);
        Assert.AreEqual(true, getAllExerciseViewModel.Exercises[1].Stationary);
        Assert.AreEqual(false, getAllExerciseViewModel.Exercises[1].WithCone);
        Assert.AreEqual(jumpEnum.DoubleJump, getAllExerciseViewModel.Exercises[1].TypeOfJump);
        Assert.AreEqual(LevelEnum.Beginner, getAllExerciseViewModel.Exercises[1].Level);

        Assert.AreEqual(3, getAllExerciseViewModel.Exercises[2].GetExerciseId);
        Assert.AreEqual("DoubleJump", getAllExerciseViewModel.Exercises[2].Name);
        Assert.AreEqual("JumpALot", getAllExerciseViewModel.Exercises[2].Description);
        Assert.AreEqual(HandlingPositionEnum.Right, getAllExerciseViewModel.Exercises[2].HandlingPosition);
        Assert.AreEqual(false, getAllExerciseViewModel.Exercises[2].Stationary);
        Assert.AreEqual(true, getAllExerciseViewModel.Exercises[2].WithCone);
        Assert.AreEqual(jumpEnum.DoubleJump, getAllExerciseViewModel.Exercises[2].TypeOfJump);
        Assert.AreEqual(LevelEnum.Advanced, getAllExerciseViewModel.Exercises[2].Level);


    }

    [TestMethod]
    public async Task TestUpdateExercise()
    {
        //Arrange
        AddExerciseViewModel addExerciseViewModel = new AddExerciseViewModel(1, "Jump", "JumpForJoy",
            HandlingPositionEnum.Optional, true, false, jumpEnum.DoubleJump, LevelEnum.Beginner);
        UpdateExerciseViewModel updatedExerciseViewModel = new UpdateExerciseViewModel(1, 1, "MegaJump", "JumpForJoy",
            HandlingPositionEnum.ChangeOfPosition, true, false, jumpEnum.DoubleJump, LevelEnum.Beginner);

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
        AddExerciseViewModel addExerciseViewModel = new AddExerciseViewModel(1, "Jump", "JumpForJoy",
            HandlingPositionEnum.ChangeOfPosition, true, false, jumpEnum.DoubleJump, LevelEnum.Beginner);
        await exerciseController.AddExercise(addExerciseViewModel);

        //Act
        IActionResult result = await exerciseController.DeleteExercise(1);


        //Assert
        Assert.IsInstanceOfType<OkResult>(result);
        Assert.AreEqual(1, testRepository.TestExercises.Count);
    }

    [TestMethod]
    public async Task TestAssignListNumber() 
    {
        //Arrange
        Course course = new Course(LevelEnum.Beginner);
        List<Exercise> exercises = course.ExerciseList;
        exercises.Add(new Exercise(1, 1, "Jump", "JumpForJoy",
            HandlingPositionEnum.Left, true, false, jumpEnum.DoubleJump, LevelEnum.Beginner));
        exercises.Add(new Exercise(2, 2, "Jumping", "JumpALot",
            HandlingPositionEnum.Right, true, false, jumpEnum.DoubleJump, LevelEnum.Advanced));

        //Act
        await course.AssignListNumbers(course);

        //Assert
        Assert.AreEqual(0, exercises[0].IndexNumber);
        Assert.AreEqual(1, exercises[1].IndexNumber);

    }



}
