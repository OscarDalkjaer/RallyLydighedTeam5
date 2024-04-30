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
        private readonly CourseTestRepository testRepository;
        private readonly CourseController courseController;

        public CourseControllerTests()
        {
            // Der mangler et test CourseBuilder
            testRepository = new CourseTestRepository();
            courseController = new CourseController(testRepository, new CourseBuilder(new ExerciseTestRepository()));
        }

        [TestMethod]
        public async Task TestAddCourse()
        {
            //Arrange
            AddCourseRequestViewModel addCourseViewModel = new AddCourseRequestViewModel(LevelEnum.Champion);

            //Act
            await courseController.AddCourse(addCourseViewModel);

            //Assert
            Assert.AreEqual(1, testRepository.TestCourses.Count);
            Assert.AreEqual(20, testRepository.TestCourses[0].ExerciseList.Count());   
        }

        [TestMethod]
        public async Task TestGetCourse()
        {
            //Arrange
            await testRepository.AddCourse(new Course(LevelEnum.Advanced));

            //Act
            GetCourseViewModel getCourseViewModel = (await courseController.GetCourse(1))
                .GetValueAs<GetCourseViewModel>();

            //Assert
            Assert.AreEqual(LevelEnum.Advanced, getCourseViewModel.Level);
        }

        [TestMethod]
        public async Task TestGetAllCourses()
        {
            //Arrange
            await testRepository.AddCourse(new Course(LevelEnum.Advanced));
            await testRepository.AddCourse(new Course(LevelEnum.Beginner));

            //Act            
            GetAllCoursesViewModel getAllCoursesViewModel = (await courseController.GetAllCourses())
                .GetValueAs<GetAllCoursesViewModel>();

            //Assert
            Assert.AreEqual(getAllCoursesViewModel.Courses[0].Level, LevelEnum.Advanced);
            Assert.AreEqual(getAllCoursesViewModel.Courses[1].Level, LevelEnum.Beginner);
        }

        [TestMethod]
        public async Task TestUpdateCourse()
        {
            //Arrange
            await testRepository.AddCourse(new Course(LevelEnum.Beginner));
            UpdateCourseRequestViewModel updatedCourseViewModel = new UpdateCourseViewModel(courseId: 1, LevelEnum.Advanced);

            //Act
            IActionResult result = await courseController.UpdateCourse(updatedCourseViewModel);

            //Assert
            Assert.IsInstanceOfType<OkResult>(result);
            Assert.AreEqual(LevelEnum.Advanced, testRepository.TestCourses[0].Level);
        }

        [TestMethod]
        public async Task TestDeleteCourse()
        {
            //Arrange
            await testRepository.AddCourse(new Course(LevelEnum.Advanced));

            //Act
            IActionResult result = await courseController.DeleteCourse(1);

            //Assert
            Assert.IsInstanceOfType<OkResult>(result);
            Assert.AreEqual(0, testRepository.TestCourses.Count);
        }
    }
}