using API.ViewModels;
using BusinessLogic.Models;
using BusinessLogic.Services;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        public CourseController (ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpPost]
        public void AddCourse(LevelEnum level)
        {
            _courseRepository.AddCourse(level);
        }

        [HttpGet]
        public async Task<GetCourseViewModel> GetCourse(int courseId)
        {
            Course course = await _courseRepository.GetCourse(courseId);
            GetCourseViewModel courseViewModel = new GetCourseViewModel(course.CourseId, course.Level);
            return courseViewModel;
        }

    }
}
