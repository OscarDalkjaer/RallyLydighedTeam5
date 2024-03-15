using API.Controllers;
using BusinessLogic.Services;
using DataAccess.Repositories;
using BusinessLogic.Models;

namespace RallyTests
{
    [TestClass]
    public class CourseRepositoryTests
    {
        [TestMethod]
        public async Task TestAddCourse()
        {
            //Arrange
            CourseTestRepository testRepository = new CourseTestRepository();
            CourseController courseController = new CourseController(testRepository);
            int count1 = testRepository.TestCourses.Count();
            
            //Act
            await testRepository.AddCourse(LevelEnum.Beginner);
            int count2 = testRepository.TestCourses.Count();


            //Assert
            Assert.AreEqual(count1, count2-1);
        }
    }
}