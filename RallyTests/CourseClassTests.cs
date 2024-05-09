using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTests
{
    [TestClass]
    public class CourseClassTests
    {
        [TestMethod]
        public async Task TestGetMinLengthOfExerciseList()
        {
            //Assert
            Course course = new Course(LevelEnum.Champion);

            //Act
            int max = course.GetMinLengthOfExerciseList(course.Level);

            //Assert
            Assert.AreEqual(18, max);
        }




        [TestMethod]
        public async Task TestGetMaxLengthOfExerciseList() 
        {
            //Assert
            Course course = new Course(LevelEnum.Champion);

            //Act
            int max = course.GetMaxLengthOfExerciseList(course.Level);

            //Assert
            Assert.AreEqual(20, max);
        }
    }
}
