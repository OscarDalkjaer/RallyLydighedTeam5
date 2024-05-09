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
}
