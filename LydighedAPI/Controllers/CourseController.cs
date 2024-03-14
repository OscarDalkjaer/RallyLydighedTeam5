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
        public async void AddCourse(LevelEnum level)
        {
            await _courseRepository.AddCourse(level);
        }
        //gfdgfd
        //[HttpGet]
        //public async Task<GetCourseViewModel> GetCourse(int courseId)
        //{
        //    Course course = await _courseRepository.GetCourse(courseId);
        //    GetCourseViewModel courseViewModel = new GetCourseViewModel(course.CourseId, course.Level);
        //    return courseViewModel;
        //}

    }
}
