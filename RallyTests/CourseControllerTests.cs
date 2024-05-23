using API.Controllers;
using DataAccess.Repositories;
using BusinessLogic.Models;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using DataAccess;

namespace RallyTests
{
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
            AddCourseRequestViewModel addCourseViewModel = new AddCourseRequestViewModel(LevelEnum.Champion);

            //Act
            await _courseController.AddCourse(addCourseViewModel);

            //Assert
            Assert.AreEqual(1, _testRepository.TestCourses.Count);
            Assert.AreEqual(20, _testRepository.TestCourses[0].ExerciseList.Count());
        }

        [TestMethod]
        public async Task TestGetCourse()
        {
            //Arrange
            await _testRepository.AddCourse(new Course(LevelEnum.Advanced));

            //Act
            GetCourseViewModel getCourseViewModel = (await _courseController.GetCourse(1))
                .GetValueAs<GetCourseViewModel>();

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
            GetAllCoursesViewModel getAllCoursesViewModel = (await _courseController.GetAllCourses())
                .GetValueAs<GetAllCoursesViewModel>();

            //Assert
            Assert.AreEqual(getAllCoursesViewModel.Courses[0].Level, LevelEnum.Advanced);
            Assert.AreEqual(getAllCoursesViewModel.Courses[1].Level, LevelEnum.Beginner);
        }

        

        [TestMethod]
        public async Task TestDeleteCourse()
        {
            //Arrange
            await _testRepository.AddCourse(new Course(LevelEnum.Advanced));

            //Act
            IActionResult result = await _courseController.DeleteCourse(1);

            //Assert
            Assert.IsInstanceOfType<OkResult>(result);
            Assert.AreEqual(0, _testRepository.TestCourses.Count);
        }
    }
}