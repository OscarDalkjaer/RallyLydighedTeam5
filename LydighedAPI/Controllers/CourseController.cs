using API.ViewModels;
using BusinessLogic.Models;
using BusinessLogic.Services;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        public CourseController (ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpPost ]
        public async Task AddCourse([FromBody] AddCourseViewModel addCourseViewModel)
        {
            if(addCourseViewModel != null) 
            {
                await _courseRepository.AddCourse(new Course(addCourseViewModel.Level));
            }
            
        }

        [HttpGet ("{courseId}", Name="GetCourse")]
        public async Task<GetCourseViewModel> GetCourse(int courseId) 
        {
            Course course = await _courseRepository.GetCourse(courseId);
            GetCourseViewModel getCourseViewModel = new GetCourseViewModel(course.CourseId, course.Level);  
            return getCourseViewModel;

        }


        [HttpGet (Name ="GetALlCourses")]
        public async Task<IEnumerable<GetCourseViewModel>> GetAllCourses()
        {
            IEnumerable<Course> courses = await _courseRepository.GetAllCourses();
            IEnumerable<GetCourseViewModel> getCourseViewModels = courses.Select(c => new GetCourseViewModel(c.CourseId, c.Level));
            return getCourseViewModels;
      
        }

        [HttpPut(Name = "UpdateCourse")]
        public async Task UpdateCourse([FromBody]UpdateCourseViewModel updateCourseViewModel)
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
