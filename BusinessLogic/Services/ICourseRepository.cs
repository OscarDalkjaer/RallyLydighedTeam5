using BusinessLogic.Models;

namespace BusinessLogic.Services
{
    public interface ICourseRepository
    {
        Task<Course?> AddCourse(Course course);
        Task<Course?> GetCourse(int courseId);
        public Task<IEnumerable<Course>> GetAllCourses();
        Task<Course?> UpdateCourse(Course course);
        Task DeleteCourse(int courseId);
    }
}
