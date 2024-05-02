using BusinessLogic.Models;
using BusinessLogic.Services;
using DataAccess.DataAccessModels;
using DataAccessDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace DataAccess.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseContext _context;
        private readonly IExerciseRepository _exerciseRepository;

        public CourseRepository(CourseContext context, IExerciseRepository exerciseRepository)
        {
            _context = context;
            _exerciseRepository = exerciseRepository;
        }

        public async Task<Course?> AddCourse(Course course)
        {
            int maxLengthOfExerciseList = course.GetMaxLengthOfExerciseList(course.Level);
            Exercise nullExercise = await  _exerciseRepository.GetNullExercise();

            CourseDataAccessModel courseDataAccessModel = new CourseDataAccessModel(
                course, maxLengthOfExerciseList);




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
            Course courseToUpdate = await _context.Courses
                .Include(x => x.Relations)
                .ThenInclude(x => x.Exercise)
                .SingleAsync(c => c.CourseId == course.CourseId);

            var exercises = _context.Exercises.Where(x => course.Relations.Select(i => i.Exercise.ExerciseId).Contains(x.ExerciseId));

            if (courseToUpdate != null)
            {
                courseToUpdate.Level = course.Level;

                var count = courseToUpdate.Relations.Count;
                for (var i = 0; i < count; i++)
                {
                    if (courseToUpdate.Relations[i].Exercise.ExerciseId != course.Relations[i].Exercise.ExerciseId)
                    {
                        var ex = exercises.First(x => x.ExerciseId == course.Relations[i].Exercise.ExerciseId);
                        courseToUpdate.Relations[i].Exercise = ex;                                          }
                }

                await _context.SaveChangesAsync();
                Course updatedCourse = courseToUpdate;
                return updatedCourse;

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
