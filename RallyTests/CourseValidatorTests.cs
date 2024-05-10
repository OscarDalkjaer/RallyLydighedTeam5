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

        public CourseValidatorTests() 
        {
            _validator = new CourseValidator(); 
        }

        

        [TestMethod]
        public void TestValidateLengthOfExerciseListTrue() 
        {
            // Arrange
            Course course = new Course(LevelEnum.Expert);
            
            Exercise nullExercise = new Exercise(1,"", "", HandlingPositionEnum.Optional, false, false, null, null);
            for(int i = 1;  i <= 16; i++) 
            {
                course.ExerciseList.Add(nullExercise);
            }

            // Act
            bool result = _validator.ValidateLengthOfExerciseList(course);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(16, course.ExerciseList.Count());
        }

        [TestMethod]
        public void TestValidateLenghtOfExerciseListFalse()
        {
            // Arrange
            Course course = new Course(LevelEnum.Expert);
            
            Exercise nullExercise = new Exercise(1, "", "", HandlingPositionEnum.Left, false, false, null, null);
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
        public async Task TestCreatePropertyListsofExercisesAccordingToHandlingPosition()
        {
            // Arrange
            Course course = new Course(LevelEnum.Beginner);

            course.ExerciseList.Add(new Exercise(2, 1, "", "", HandlingPositionEnum.Left, false, false, null, null));
            course.ExerciseList.Add(new Exercise(3, 1, "", "", HandlingPositionEnum.Right, false, false, null, null));
            course.ExerciseList.Add(new Exercise(4, 1, "", "", HandlingPositionEnum.Left, false, false, null, null));
            course.ExerciseList.Add(new Exercise(5, 1, "", "", HandlingPositionEnum.Left, false, false, null, null));
            course.ExerciseList.Add(new Exercise(6, 1, "", "", HandlingPositionEnum.Right, false, false, null, null));
            course.ExerciseList.Add(new Exercise(7, 1, "", "", HandlingPositionEnum.Left, false, false, null, null));
            course.ExerciseList.Add(new Exercise(8, 1, "", "", HandlingPositionEnum.Left, false, false, null, null));
            course.ExerciseList.Add(new Exercise(9, 1, "", "", HandlingPositionEnum.Left, false, false, null, null));
            course.ExerciseList.Add(new Exercise(10, 1, "", "", HandlingPositionEnum.Left, false, false, null, null));
            course.ExerciseList.Add(new Exercise(11, 1, "", "", HandlingPositionEnum.Right, false, false, null, null));

            List<Exercise> exerciseList = course.AssignListNumbers();
            StartPositionEnum startPosition = StartPositionEnum.Left;

            ValidationResults validationResults = new ValidationResults();


            //Act
            await _validator.CreatePropertyListsofExercisesAccordingToHandlingPosition(startPosition, exerciseList, validationResults);
            int numberOfLeftHandledExercises = validationResults.ExerciseIdOnLefttHandledExercises.Count;
            int numberOfRightHandledExercises = validationResults.ExerciseIdOnRightHandledExercises.Count;
           

            //Assert
            Assert.AreEqual(numberOfLeftHandledExercises, 7);
            Assert.AreEqual(numberOfRightHandledExercises, 3);
        }

        [TestMethod]
        public async Task TestValidateRightPositionOnlyBetweenTwoChangesOfPosition()
        {
            //Arrange
            Course course = new Course(LevelEnum.Beginner);

            course.ExerciseList.Add(new Exercise(2, 1, "", "", HandlingPositionEnum.Left, false, false, null, null));
            course.ExerciseList.Add(new Exercise(3, 1, "", "", HandlingPositionEnum.Right, false, false, null, null));
            course.ExerciseList.Add(new Exercise(4, 1, "", "", HandlingPositionEnum.Left, false, false, null, null));
            course.ExerciseList.Add(new Exercise(5, 1, "", "", HandlingPositionEnum.Left, false, false, null, null));
            course.ExerciseList.Add(new Exercise(6, 1, "", "", HandlingPositionEnum.Right, false, false, null, null));
            course.ExerciseList.Add(new Exercise(7, 1, "", "", HandlingPositionEnum.Left, false, false, null, null));
            course.ExerciseList.Add(new Exercise(8, 1, "", "", HandlingPositionEnum.Left, false, false, null, null));
            course.ExerciseList.Add(new Exercise(9, 1, "", "", HandlingPositionEnum.Left, false, false, null, null));
            course.ExerciseList.Add(new Exercise(10, 1, "", "", HandlingPositionEnum.Left, false, false, null, null));
            course.ExerciseList.Add(new Exercise(11, 1, "", "", HandlingPositionEnum.Right, false, false, null, null));

            List<Exercise> exerciseList = course.AssignListNumbers();
            StartPositionEnum startPosition = StartPositionEnum.Left;

            CourseValidator courseValidator = new CourseValidator();
            ValidationResults validationResults = new ValidationResults();

            await courseValidator.CreatePropertyListsofExercisesAccordingToHandlingPosition(startPosition, exerciseList, validationResults);

            //Act
            bool validation = await courseValidator.ValidateRightPositionOnlyBetweenTwoChangesOfPosition(course, startPosition);

            //Assert
            Assert.AreEqual(false, validation);

        }



    }
}
