using API.Controllers;
using BusinessLogic.Services;
using DataAccess.Repositories;
using BusinessLogic.Models;
using Microsoft.Identity.Client;
using API.ViewModels;

namespace RallyTests
{
    [TestClass]
    public class CourseControllerTests
    {
        [TestMethod]
        public async Task TestAddCourse()
        {
            //Arrange
            CourseTestRepository testRepository = new CourseTestRepository();
            CourseController courseController = new CourseController(testRepository);
            int count1 = testRepository.TestCourses.Count();
            
            //Act
            await courseController.AddCourse(LevelEnum.Beginner);
            int count2 = testRepository.TestCourses.Count();


            //Assert
            Assert.AreEqual(count1, count2-1);
        }

        //[TestMethod]
        //public async Task TestGetCourse()
        //{
        //    //Arrange
        //    CourseTestRepository testRepository = new CourseTestRepository();
        //    testRepository.TestCourses.Clear();
        //    await testRepository.AddCourse(LevelEnum.Advanced);
        //    CourseController courseController = new CourseController(testRepository);

        //    //Act
        //    GetCourseViewModel getCourseViewModel = await courseController.GetCourse(1);

        //    //Assert
        //    Assert.AreEqual(LevelEnum.Advanced, getCourseViewModel.Level);
        //    Assert.AreEqual(1, getCourseViewModel.CourseId);
        //}

        [TestMethod]
        public async Task TestGetAllCourses()
        {
            //Arrange
            CourseTestRepository testRepository = new CourseTestRepository();
            testRepository.TestCourses.Clear();
            await testRepository.AddCourse(LevelEnum.Advanced);
            await testRepository.AddCourse(LevelEnum.Beginner);
            CourseController courseController = new CourseController(testRepository);

            //Act            
            IEnumerable<GetCourseViewModel> courseViewModel = await courseController.GetAllCourses();
            List<GetCourseViewModel> courseViewModels = courseViewModel.ToList();
            
            //Assert
            Assert.AreEqual(courseViewModels[0].CourseId, 1);
            Assert.AreEqual(courseViewModels[1].CourseId, 2);
            Assert.AreEqual(courseViewModels[0].Level, LevelEnum.Advanced);
            Assert.AreEqual(courseViewModels[1].Level, LevelEnum.Beginner);            
        }

        [TestMethod]
        public async Task TestUpdateCourse()
        {
            //Arrange
            CourseTestRepository testRepository = new CourseTestRepository();
            CourseController courseController = new CourseController(testRepository);
            testRepository.TestCourses.Clear();
            await testRepository.AddCourse(LevelEnum.Advanced);
            Course course = new Course(LevelEnum.Beginner);
            course.CourseId = 1;

            //Act
            await courseController.UpdateCourse(course);

            //Assert
            Assert.AreEqual(testRepository.TestCourses[0].Level, LevelEnum.Beginner);
        }

        [TestMethod]
        public async Task TestDeleteCourse ()
        {
            //Arrange
            CourseTestRepository testRepository = new CourseTestRepository();
            CourseController courseController = new CourseController(testRepository);
            testRepository.TestCourses.Clear();
            await testRepository.AddCourse(LevelEnum.Advanced);


            //Act
            courseController.DeleteCourse(1);

            //Assert
            Assert.AreEqual(testRepository.TestCourses.Count, 0);

        }                     
    }
}