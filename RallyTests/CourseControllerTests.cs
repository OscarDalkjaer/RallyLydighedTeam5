using API.Controllers;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Infrastructure;
using Core.Domain.Entities;

namespace RallyTests;

[TestClass]
public class CourseControllerTests
{
    private readonly CourseTestRepository _testRepository;
    private readonly ExerciseTestRepository _exerciseTestRepository;

    private readonly CourseController _courseController;

    public CourseControllerTests()
    {
        _testRepository = new CourseTestRepository();
        _exerciseTestRepository = new ExerciseTestRepository();
        _courseController = new CourseController(_testRepository, _exerciseTestRepository, null);
    }

    [TestMethod]
    public async Task TestAddCourse()
    {
        //Arrange
        AddCourseRequest addCourseViewModel = new AddCourseRequest { Level = LevelEnum.Champion };

        //Act
        await _courseController.AddCourse(addCourseViewModel);

        //Assert
        Assert.AreEqual(1, _testRepository.TestCourses.Count);
    }

    [TestMethod]
    public async Task TestGetCourse()
    {
        //Arrange
        await _testRepository.AddCourse(new Course(1, LevelEnum.Advanced));

        //Act
        GetCourseResponse getCourseViewModel = (await _courseController.GetCourse(1))
            .GetValueAs<GetCourseResponse>();

        //Assert
        Assert.AreEqual(LevelEnum.Advanced, getCourseViewModel.Level);
    }

    [TestMethod]
    public async Task TestGetAllCourses()
    {
        //Arrange
        await _testRepository.AddCourse(new Course(LevelEnum.Advanced));
        await _testRepository.AddCourse(new Course(LevelEnum.Beginner));

        //Act            
        GetAllCoursesResponse getAllCoursesViewModel = (await _courseController.GetAllCourses())
            .GetValueAs<GetAllCoursesResponse>();

        //Assert
        Assert.AreEqual(getAllCoursesViewModel.Courses[0].Level, LevelEnum.Advanced);
        Assert.AreEqual(getAllCoursesViewModel.Courses[1].Level, LevelEnum.Beginner);
    }

    [TestMethod]
    public async Task TestDeleteCourse()
    {
        //Arrange
        await _testRepository.AddCourse(new Course(1, LevelEnum.Advanced));

        //Act
        IActionResult result = await _courseController.DeleteCourse(1);

        //Assert
        Assert.IsInstanceOfType<OkResult>(result);
        Assert.AreEqual(0, _testRepository.TestCourses.Count);
    }
}