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
            AddCourseViewModel addCourseViewModel = new AddCourseViewModel(LevelEnum.Champion);
            
            //Act
            await courseController.AddCourse(addCourseViewModel);
            int count2 = testRepository.TestCourses.Count();


            //Assert
            Assert.AreEqual(count1, count2-1);
        }

        [TestMethod]
        public async Task TestGetCourse()
        {
            //Arrange
            CourseTestRepository testRepository = new CourseTestRepository();
            testRepository.TestCourses.Clear();
            await testRepository.AddCourse(new Course(LevelEnum.Advanced));
            CourseController courseController = new CourseController(testRepository);

            //Act
            GetCourseViewModel getCourseViewModel = await courseController.GetCourse(1);

            //Assert
            Assert.AreEqual(LevelEnum.Advanced, getCourseViewModel.Level);
            Assert.AreEqual(1, getCourseViewModel.CourseId);
        }

        [TestMethod]
        public async Task TestGetAllCourses()
        {
            //Arrange
            CourseTestRepository testRepository = new CourseTestRepository();
            testRepository.TestCourses.Clear();
            await testRepository.AddCourse(new Course(LevelEnum.Advanced));
            await testRepository.AddCourse(new Course(LevelEnum.Beginner));
            CourseController courseController = new CourseController(testRepository);

            //Act            
            IEnumerable<GetCourseViewModel> courseViewModels = await courseController.GetAllCourses();
            List<GetCourseViewModel> courseViewModelList = courseViewModels.ToList();
            
            //Assert
            Assert.AreEqual(courseViewModelList[0].CourseId, 1);
            Assert.AreEqual(courseViewModelList[1].CourseId, 2);
            Assert.AreEqual(courseViewModelList[0].Level, LevelEnum.Advanced);
            Assert.AreEqual(courseViewModelList[1].Level, LevelEnum.Beginner);            
        }

        [TestMethod]
        public async Task TestUpdateCourse()
        {
            //Arrange
            CourseTestRepository testRepository = new CourseTestRepository();
            CourseController courseController = new CourseController(testRepository);
            testRepository.TestCourses.Clear();
            Course course = new Course(LevelEnum.Beginner);
            course.CourseId = 1;
            testRepository.AddCourse(course);
            UpdateCourseViewModel updatedCourseViewModel = new UpdateCourseViewModel(1, LevelEnum.Advanced);
        

            //Act
            await courseController.UpdateCourse(updatedCourseViewModel);

            //Assert
            Assert.AreEqual(testRepository.TestCourses[0].Level, LevelEnum.Advanced);
        }

        [TestMethod]
        public async Task TestDeleteCourse ()
        {
            //Arrange
            CourseTestRepository testRepository = new CourseTestRepository();
            CourseController courseController = new CourseController(testRepository);
            testRepository.TestCourses.Clear();
            //await testRepository.AddCourse(LevelEnum.Advanced);


            //Act
            courseController.DeleteCourse(1);

            //Assert
            Assert.AreEqual(testRepository.TestCourses.Count, 0);

        }                     
    }
}