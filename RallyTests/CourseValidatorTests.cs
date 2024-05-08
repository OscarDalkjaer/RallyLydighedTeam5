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
            
            Exercise nullExercise = new Exercise(1, 0, null);
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
            
            Exercise nullExercise = new Exercise(1, 0, null);
            for (int i = 1; i <= 7; i++)
            {
                course.ExerciseList.Add(nullExercise);
            }

            // Act
            bool result = _validator.ValidateLengthOfExerciseList(course);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
