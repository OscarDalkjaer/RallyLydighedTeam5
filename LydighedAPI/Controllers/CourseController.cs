using API.ViewModels;
using BusinessLogic.Models;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] AddCourseViewModel addCourseViewModel)
        {
            if (addCourseViewModel == null) return BadRequest("viewModel was null");

            Course course = new Course(addCourseViewModel.Level);
            await _courseRepository.AddCourse(course);

            return Ok();
        }

        [HttpGet("{courseId}", Name = "GetCourse")]
        public async Task<IActionResult> GetCourse(int courseId)
        {
            if (courseId <= 0) return BadRequest("CourseId must be larger than zero");

            Course? course = await _courseRepository.GetCourse(courseId);

            if (course == null) return NotFound($"Course with id {courseId} does not exists");

            GetCourseViewModel getCourseViewModel = new GetCourseViewModel(course.CourseId, course.Level);
            return Ok(getCourseViewModel);
        }


        [HttpGet(Name = "GetAllCourses")]
        public async Task<IActionResult> GetAllCourses()
        {
            IEnumerable<Course> courses = await _courseRepository.GetAllCourses();
            GetAllCoursesViewModel getAllCoursesViewModel = new GetAllCoursesViewModel(courses);

            return getAllCoursesViewModel.Courses.Count is 0
                ? NoContent()
                : Ok(getAllCoursesViewModel);
        }

        [HttpPut(Name = "UpdateCourse")]
        public async Task UpdateCourse([FromBody] UpdateCourseViewModel updateCourseViewModel)
        {
            Course updateCourse = new Course(updateCourseViewModel.UpdatedCourseId,
                updateCourseViewModel.Level);

            await _courseRepository.UpdateCourse(updateCourse);
        }


        [HttpDelete]
        public async Task DeleteCourse(int courseId)
        {
            await _courseRepository.DeleteCourse(courseId);
        }




        //[HttpGet]
        //public async Task<GetCourseViewModel> GetCourse(int courseId)
        //{
        //    Course course = await _courseRepository.GetCourse(courseId);
        //    GetCourseViewModel courseViewModel = new GetCourseViewModel(course.CourseId, course.Level);
        //    return courseViewModel;
        //}


    }
}
