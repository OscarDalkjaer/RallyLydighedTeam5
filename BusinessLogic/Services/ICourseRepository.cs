using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface ICourseRepository
    {
        Task AddCourse(Course course);
        Task<Course?> GetCourse(int courseId);
        public Task<IEnumerable<Course>> GetAllCourses();
        Task UpdateCourse(Course course);
        Task DeleteCourse(int courseId);
    }
}
