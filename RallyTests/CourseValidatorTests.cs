using API.Controllers;
using BusinessLogic.Models;
using DataAccess.Repositories;
using DataAccessDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTests
{
    [TestClass]
    public class CourseValidatorTests
    {
        private readonly CourseValidator _validator;
        private readonly InstanceCreator _instanceCreator;
        private readonly CourseVisualizer _visualizer;

        public CourseValidatorTests()
        {
            _validator = new CourseValidator();
            _instanceCreator = new InstanceCreator();
            _visualizer = new CourseVisualizer();
        }



        [TestMethod]
        public void TestValidateLengthOfExerciseListTrue()
        {
            // Arrange
            Course course = _instanceCreator.CreateBeginnerCourse();

            // Act
            bool result = _validator.ValidateLengthOfExerciseList(course);

            // Assert
            Assert.IsTrue(result);
        }



        [TestMethod]
        public void TestValidateLenghtOfExerciseListFalse()
        {
            // Arrange
            Course course = new Course(LevelEnum.Expert);

            Exercise nullExercise = new Exercise(1, "", "", DefaultHandlingPositionEnum.Left, false, false, null, null);
            for (int i = 1; i <= 7; i++)
            {
                course.ExerciseList.Add(nullExercise);
            }

            // Act
            bool result = _validator.ValidateLengthOfExerciseList(course);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestValidateRightHandlingOnlyBetweenTwoChangesOfPositions() 
        {
            //Arrange
            Course course = _instanceCreator.CreateBeginnerCourse();
            DefaultHandlingPositionEnum startPosition = DefaultHandlingPositionEnum.Left;  
            List<(int, int, string, bool)> visualizedCourse = _visualizer.VisualiseCourse(course, startPosition );
            List<(int, int, string, bool)> rightHandledexerises = _visualizer.VisualiseRightHandledExercises(visualizedCourse);

            //Act
            bool result = _validator.ValidateRightHandlingOnlyBetweenTwoChangesOfPositions(rightHandledexerises, course);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestValidateMaxNumberOfRepeatedRightHandledExercisesExpertTrue() 
        {
            //Arrange
            Course course = _instanceCreator.CreateExpertCourseWithTwoRightHandledExercises();
            DefaultHandlingPositionEnum startPosition = DefaultHandlingPositionEnum.Left;
            List<(int, int, string, bool)> visualizedCourse = _visualizer.VisualiseCourse(course, startPosition);
            List<(int, int, string, bool)> rightHandledexerises = _visualizer.VisualiseRightHandledExercises(visualizedCourse);

            //Act
            bool result = _validator.ValidateMaxNumberOfRepeatedRightHandledExercises(rightHandledexerises, course, startPosition);

            //Assert
            Assert.IsTrue(result);
        }







    }
}
