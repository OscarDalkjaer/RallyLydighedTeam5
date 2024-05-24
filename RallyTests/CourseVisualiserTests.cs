using API.Controllers;
using Core.Application.UpdateCourse;
using Core.Domain.Entities;
using Core.Domain.Entities;
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
            
           Course course = _instanceCreator.CreateBeginnerCourse();
           
            //Act
            List<(int, int, string, bool)> newList = _courseVisualizer.VisualiseCourse(course);
            

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
            List<(int, int, string, bool)> visualisedCourse = _courseVisualizer.VisualiseCourse(course);

            //Act
            List<(int, int, string, bool)> rightHandledExercises = _courseVisualizer.VisualiseRightHandledExercises(visualisedCourse);

            //Assert
            foreach (var item in rightHandledExercises) 
            {
                Assert.IsFalse (item.Item4);
            }         
        }

        [TestMethod]
        public void TestVisualiseLevelDistributionOfTheExercises()
        {
            //Arrange
            Course course = _instanceCreator.CreateChampionCourseWithThreeRightHandledExercises();
            int countOfBeginnerLevelExercises = course.ExerciseList.Count(x => x.Level == LevelEnum.Beginner);
            int countOfAdvancedLevelExercises = course.ExerciseList.Count(x => x.Level == LevelEnum.Advanced);
            int countOfExpertLevelExercises = course.ExerciseList.Count(x => x.Level == LevelEnum.Expert);
            int countOfChampionLevelExercises = course.ExerciseList.Count(x => x.Level == LevelEnum.Champion);
            int countOfOpeClassLevelExercises = course.ExerciseList.Count(x => x.Level == LevelEnum.OpenClass);

            //Act
            (int, int, int, int, int) distributionVisualised = _courseVisualizer.VisualiseLevelDistributionOfTheExercises(course);


            //Asset
            Assert.AreEqual(countOfBeginnerLevelExercises, distributionVisualised.Item1);
            Assert.AreEqual(countOfAdvancedLevelExercises, distributionVisualised.Item2);
            Assert.AreEqual(countOfExpertLevelExercises, distributionVisualised.Item3);
            Assert.AreEqual(countOfChampionLevelExercises, distributionVisualised.Item4);
            Assert.AreEqual(countOfOpeClassLevelExercises, distributionVisualised.Item5);         
        }

        [TestMethod]
        public void TestVisualiseJumpPropertyForExercise() 
        {
            //Arrange
            Course course = _instanceCreator.CreateExpertCourseWithTwoRightHandledExercises();

            //Act
            List<(int, int, string, JumpEnum?)> visualisedJumpExercises = _courseVisualizer.VisualiseJumpPropertyForExercise(course);

            //Assert
            Assert.AreEqual(visualisedJumpExercises[0].Item4, JumpEnum.SingleJump);
            Assert.AreEqual(visualisedJumpExercises[1].Item4, JumpEnum.DoubleJump);
            Assert.AreEqual(visualisedJumpExercises[2].Item4, null);
        }


            
           
            
        
    }
}
