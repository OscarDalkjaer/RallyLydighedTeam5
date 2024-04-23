using BusinessLogic.Models;
using BusinessLogic.Services;
using DataAccessDbContext;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseContext _context;
        public CourseRepository(CourseContext context)
        {
            _context = context;
        }

        public async Task AddCourse(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
        }

        public async Task<Course?> GetCourse(int courseId)
        {
            return await _context.Courses.FirstOrDefaultAsync(c => c.CourseId == courseId);
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task UpdateCourse(Course course)
        {
            Course? courseToUpdate = await _context.Courses
                .SingleOrDefaultAsync(c => c.CourseId == course.CourseId);

            if (courseToUpdate != null)
            {
                courseToUpdate.Level = course.Level;
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteCourse(int courseId)
        {
            Course? course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseId == courseId);
            
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
        }
    }
}
