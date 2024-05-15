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

        public CourseValidatorTests()
        {
            _validator = new CourseValidator();
        }



        [TestMethod]
        public void TestValidateLengthOfExerciseListTrue()
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
            course.ExerciseList.Add(new Exercise(1, 1, "", "", HandlingPositionEnum.Right, false, false, null, null));
            course.ExerciseList.Add(new Exercise(1, 1, "", "", HandlingPositionEnum.Right, false, false, null, null));

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
        public void TestValidateRighthandledExercises()
        {
            //Arrange
            Course course = new Course(LevelEnum.Beginner);
            CourseVisualizer courseVisualizer = new CourseVisualizer();
            List<(int, string, bool)> visualisedCourse = courseVisualizer.VisualiseCourse(course, HandlingPositionEnum.Left);
           
            List<(int, string, bool)> exercisesWithRightHandling = visualisedCourse.Where(item => !item.Item3).ToList();


            


        }








    }
}
