using Core.Domain.Entities;

namespace Core.Domain.Services
{
    public interface ICourseRepository
    {
        Task<Course?> AddCourse(Course course);
        Task<Course?> GetCourse(int courseId);
        Task<IEnumerable<Course>> GetAllCourses();
        Task<Course?> UpdateCourse(Course course);
        Task DeleteCourse(int courseId);
        Task<List<Course>> GetAllCoursesWithSpecifiedTheme(ThemeEnum theme);
        Task<IEnumerable<Course>> GetAllCoursesWithSpecifiedRangeOfExerciseCount(int rangeLow, int rangeHigh);
    }
}
