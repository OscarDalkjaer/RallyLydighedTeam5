using BusinessLogic.Models;
using BusinessLogic.Services;
using DataAccessDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseContext _context;
        public CourseRepository (CourseContext context)
        {
            _context = context;
        }

       
        public async Task AddCourse(LevelEnum level)
        {
            if (level == null)
            {
                throw new ArgumentNullException();
            }

            else
            {
                _context.Courses.Add(new Course(level));
                
            }
            await _context.SaveChangesAsync();
        }

        //public Task DeleteCourse(int courseId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<Course>> GetAllCourses()
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<Course?> GetCourse(int courseId)
        //{
        //    if (courseId != null)
        //    {
        //        return _context.Courses.FirstOrDefault(c => c.CourseId == courseId);
        //    }
        //    else return null;
        //}

        //public Task UpdateCourse(Course course)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
