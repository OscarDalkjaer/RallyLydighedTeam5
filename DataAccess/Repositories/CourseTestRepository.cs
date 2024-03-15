using BusinessLogic.Models;
using BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task DeleteCourse(int courseId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Course>> GetAllCourses()
        {
            throw new NotImplementedException();
        }

        public async Task<Course?> GetCourse(int courseId)
        {
            Course? course = TestCourses.SingleOrDefault(c => c.CourseId == courseId);
            return await Task.FromResult(course);

        }

        public Task UpdateCourse(Course course)
        {
            throw new NotImplementedException();
        }

       
    }
}
