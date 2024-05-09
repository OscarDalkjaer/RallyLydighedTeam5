﻿using API.Controllers;
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
            false, true, false, jumpEnum.DoubleJump, LevelEnum.Beginner);
        


        //Act
        await exerciseController.AddExercise(addExerciseViewModel);


        //Assert
        Assert.AreEqual(2, testRepository.TestExercises.Count);

    }

    [TestMethod]
    public async Task TestGetExercise()
    {
        //Arrange
        AddExerciseViewModel addExerciseViewModel = new AddExerciseViewModel(1, "Jump", "JumpForJoy", false, 
            true, false, jumpEnum.DoubleJump, LevelEnum.Beginner);
        await exerciseController.AddExercise(addExerciseViewModel);

        //Act


        GetExerciseViewModel getExerciseViewModel = (await exerciseController.GetExercise(2)).GetValueAs<GetExerciseViewModel>();


        //Assert
        Assert.AreEqual(2, getExerciseViewModel.GetExerciseId);
        Assert.AreEqual("Jump", getExerciseViewModel.Name);
        Assert.AreEqual("JumpForJoy", getExerciseViewModel.Description);
        Assert.AreEqual(false, getExerciseViewModel.ChangeOfPosition);
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
            false, true, false, jumpEnum.DoubleJump, LevelEnum.Beginner));
        await exerciseController.AddExercise(new AddExerciseViewModel(2, "DoubleJump", "JumpALot",
            true, false, true, jumpEnum.DoubleJump, LevelEnum.Advanced));

        //Act
        GetAllExercisesViewModel getAllExerciseViewModel = (await exerciseController.GetAllExercises())
            .GetValueAs<GetAllExercisesViewModel>();

        //Assert
        Assert.AreEqual(2, getAllExerciseViewModel.Exercises[1].GetExerciseId);
        Assert.AreEqual("Jump", getAllExerciseViewModel.Exercises[1].Name);
        Assert.AreEqual("JumpForJoy", getAllExerciseViewModel.Exercises[1].Description);
        Assert.AreEqual(false, getAllExerciseViewModel.Exercises[1].ChangeOfPosition);
        Assert.AreEqual(true, getAllExerciseViewModel.Exercises[1].Stationary);
        Assert.AreEqual(false, getAllExerciseViewModel.Exercises[1].WithCone);
        Assert.AreEqual(jumpEnum.DoubleJump, getAllExerciseViewModel.Exercises[1].TypeOfJump);
        Assert.AreEqual(LevelEnum.Beginner, getAllExerciseViewModel.Exercises[1].Level);

        Assert.AreEqual(3, getAllExerciseViewModel.Exercises[2].GetExerciseId);
        Assert.AreEqual("DoubleJump", getAllExerciseViewModel.Exercises[2].Name);
        Assert.AreEqual("JumpALot", getAllExerciseViewModel.Exercises[2].Description);
        Assert.AreEqual(true, getAllExerciseViewModel.Exercises[2].ChangeOfPosition);
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
            false, true, false, jumpEnum.DoubleJump, LevelEnum.Beginner);
        UpdateExerciseViewModel updatedExerciseViewModel = new UpdateExerciseViewModel(1, 1, "MegaJump", "JumpForJoy",
            false, true, false, jumpEnum.DoubleJump, LevelEnum.Beginner);

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
            false, true, false, jumpEnum.DoubleJump, LevelEnum.Beginner);
        await exerciseController.AddExercise(addExerciseViewModel);

        //Act
        IActionResult result = await exerciseController.DeleteExercise(1);


        //Assert
        Assert.IsInstanceOfType<OkResult>(result);
        Assert.AreEqual(1, testRepository.TestExercises.Count);
    }
}
