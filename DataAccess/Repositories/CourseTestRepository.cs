using BusinessLogic.Models;
using BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CourseTestRepository : ICourseRepository

    {
        public List<Course> TestCourses { get; } = new List<Course>();
        

        public async Task AddCourse(LevelEnum level)
        {
            int courseId = TestCourses.Count + 1;
            Course course = new Course(level);
            course.CourseId = courseId;
            TestCourses.Add(course);
            await Task.CompletedTask;
        }

        public async Task<Course?> GetCourse(int courseId)
        {
            Course? course = TestCourses.SingleOrDefault(c => c.CourseId == courseId);
            return await Task.FromResult(course);

        }

         public async Task<IEnumerable<Course>> GetAllCourses()
        {
            return TestCourses;
        }

        public async Task UpdateCourse (Course course)
        {
            Course? courseToUpdate = TestCourses.SingleOrDefault(c => c.CourseId == course.CourseId);
                if (courseToUpdate != null) 
            {
                courseToUpdate.Level = course.Level;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteCourse(int courseId)
        {
            Course? course = TestCourses.FirstOrDefault(c => c.CourseId == courseId);
            TestCourses.Remove(course);
        }
    }
}
