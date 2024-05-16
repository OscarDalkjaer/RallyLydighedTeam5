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
        private readonly InstanceCreator _instanceCreator;
        private readonly CourseVisualizer _courseVisualizer;

        public CourseVisualiserTests() 
        {
            _instanceCreator = new InstanceCreator();
            _courseVisualizer = new CourseVisualizer();
        }


        [TestMethod]
        public void TestVisualiseCourse()
        {
            //Arrange
            
            DefaultHandlingPositionEnum startPosition = DefaultHandlingPositionEnum.Left;
            Course course = _instanceCreator.CreateBeginnerCourse();
           
            //Act
            List<(int, int, string, bool)> newList = _courseVisualizer.VisualiseCourse(course, startPosition);
            

            //Assert
            Assert.IsFalse (newList[2].Item4);
            Assert.IsTrue(newList[3].Item4);
            Assert.IsTrue(newList[4].Item4);
        }


        [TestMethod]
        public void TestVisualiseRighthandledExercises()
        {
            //Arrange
            Course course = _instanceCreator.CreateBeginnerCourse();
            CourseVisualizer courseVisualizer = new CourseVisualizer();
            List<(int, int, string, bool)> visualisedCourse = courseVisualizer.VisualiseCourse(course, DefaultHandlingPositionEnum.Left);

            //Act
            List<(int, int, string, bool)> rightHandledExercises = courseVisualizer.VisualiseRightHandledExercises(visualisedCourse);

            //Assert
            foreach (var item in rightHandledExercises) 
            {
                Assert.IsFalse (item.Item4);
            }         

        }
    }
}
