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
        public async Task AddCourse(LevelEnum level)
        {
            await _courseRepository.AddCourse(level);
        }

        [HttpDelete]
        public void DeleteCourse(int courseId)
        {
            _courseRepository.DeleteCourse(courseId);
        }

        [HttpGet]
        public async Task<IEnumerable<GetCourseViewModel>> GetAllCourses()
        {

            IEnumerable<Course> courses = await _courseRepository.GetAllCourses();
            List <Course> courseList = courses.ToList();
            List <GetCourseViewModel> getCourseViewModels = new List<GetCourseViewModel>();
            foreach (Course course in courseList)
            {
                GetCourseViewModel GCVW = new GetCourseViewModel(course.CourseId, course.Level);
                getCourseViewModels.Add(GCVW);
            }
            IEnumerable<GetCourseViewModel> courseC = getCourseViewModels;
            return courseC;
        }

        [HttpGet]
        public async Task<GetCourseViewModel> GetCourse(int courseId)
        {
            Course course = await _courseRepository.GetCourse(courseId);
            GetCourseViewModel courseViewModel = new GetCourseViewModel(course.CourseId, course.Level);
            return courseViewModel;
        }

        [HttpPut]
        public async Task UpdateCourse(Course course)
        {
            await _courseRepository.UpdateCourse(course);   
        }
    }
}
