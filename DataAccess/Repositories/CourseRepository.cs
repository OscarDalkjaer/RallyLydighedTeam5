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

       
        public async Task AddCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException();
            }

            else
            {
                _context.Courses.Add(course);
                
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Course?> GetCourse(int courseId)
        {
            if (courseId != null)
            {
                return _context.Courses.FirstOrDefault(c => c.CourseId == courseId);
            }
            else return null;
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task UpdateCourse(Course course)
        {
            Course? courseToUpdate = _context.Courses.SingleOrDefault(c => c.CourseId == course.CourseId);
            if (courseToUpdate != null)
            {
                courseToUpdate.Level = course.Level;
            }
            await Task.CompletedTask;
        }
        public async Task DeleteCourse(int courseId)
        {
            Course course = _context.Courses.FirstOrDefault(c => c.CourseId == courseId);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
        } 
    }
}
