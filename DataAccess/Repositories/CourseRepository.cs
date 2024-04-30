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

        public async Task<Course?> AddCourse(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<Course?> GetCourse(int courseId)
        {
            return await _context.Courses
                .Include(x => x.ExerciseList)
                .FirstOrDefaultAsync(c => c.CourseId == courseId);
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course?> UpdateCourse(Course course)
        {
            Course? courseToUpdate = await _context.Courses
                .SingleOrDefaultAsync(c => c.CourseId == course.CourseId);

            if (courseToUpdate != null)
            {
                courseToUpdate.Level = course.Level;
                courseToUpdate.ExerciseList = course.ExerciseList;
                int UpdateSucces = await _context.SaveChangesAsync();
                if (UpdateSucces > 0) 
                {
                    Course updatedCourse = courseToUpdate;
                    return updatedCourse;
                }

                return null;
                                
            }
            return null;
            

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
