using API.Controllers;
using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTests
{
    [TestClass]
    public class CourseVisualiserTests
    {
        CourseVisualizer courseVisualizer = new CourseVisualizer();


        [TestMethod]
        public void TestVisualiseCourse()
        {
            //Arrange
            
            HandlingPositionEnum startPosition = HandlingPositionEnum.Left;
            Course course = new Course(LevelEnum.Beginner);
           
            course.ExerciseList.Add(new Exercise(2, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(3, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(4, 1, "", "", HandlingPositionEnum.ChangeOfPosition, false, false, null, null));
            course.ExerciseList.Add(new Exercise(5, 1, "", "", HandlingPositionEnum.ChangeOfPosition, false, false, null, null));
            course.ExerciseList.Add(new Exercise(6, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(7, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(8, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(9, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(10, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
            course.ExerciseList.Add(new Exercise(11, 1, "", "", HandlingPositionEnum.Optional, false, false, null, null));
           

            //Act
            List<(int, string, bool)> newList = courseVisualizer.VisualiseCourse(course, startPosition);
            

            //Assert
            Assert.IsFalse (newList[2].Item3);
            Assert.IsTrue(newList[3].Item3);
            Assert.IsTrue(newList[4].Item3);
        }
    }
}
