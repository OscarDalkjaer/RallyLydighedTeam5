using API.ViewModels;
using BusinessLogic.Models;
using BusinessLogic.Services;
using DataAccess;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IExerciseRepository? _exerciseRepository;
      

        public CourseController(ICourseRepository courseRepository, IExerciseRepository exerciseRepository 
            )
        {
            _courseRepository = courseRepository;
            _exerciseRepository = exerciseRepository;
            
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] AddCourseRequestViewModel addCourseViewModel)
        {
                       
            if (addCourseViewModel == null) return BadRequest("viewModel was null");

            Course course = new Course(addCourseViewModel.Level);
            Course? addetCourse = await _courseRepository.AddCourse(course);
            if (addetCourse == null) 
            {
                return BadRequest("Course was not addet to database");
            }

            AddCourseResponseViewModel addCourseResponseViewModel = AddCourseResponseViewModel
                .ConvertCourseToAddCourseResponseViewModel(addetCourse);  

           

            return Ok(addCourseResponseViewModel);
        }

        [HttpGet("{courseId}", Name = "GetCourse")]
        public async Task<IActionResult> GetCourse(int courseId)
        {
            if (courseId <= 0) return BadRequest("CourseId must be larger than zero");

            Course? course = await _courseRepository.GetCourse(courseId);

            if (course == null) return NotFound($"Course with id {courseId} does not exists");

            GetCourseViewModel getCourseViewModel = new GetCourseViewModel(course.CourseId, course.Level, course.ExerciseList);
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

        [HttpPut]
        public async Task<IActionResult> UpdateCourse([FromBody] UpdateCourseRequestViewModel updateCourseRequestViewModel)
        {
            if (updateCourseRequestViewModel is null) return BadRequest("ViewModel was null");
            try 
            {
                _
            }

           
           
                        
            
            if (updateCourseRequestViewModel.JudgeId > 0)
            {
                courseToUpdate.Judge = new Judge(updateCourseRequestViewModel.JudgeId);
            }
            if (updateCourseRequestViewModel.EventId > 0)
            {
                courseToUpdate.Event = new Event(updateCourseRequestViewModel.EventId);
            }


            

           

            Course? updatedCourse = await _courseRepository.UpdateCourse(courseToUpdate);
            if (updatedCourse != null) 
            {
                List<UpdateExerciseResponseViewModel> updateExerciseVMList = updatedCourse.ExerciseList.Select(x =>
                 new UpdateExerciseResponseViewModel(x.ExerciseId, x.Number, x.Name, x.Description)).ToList();

                CourseVisualizer visualizer = new CourseVisualizer();
                CourseValidator validator = new CourseValidator();
                Status status = new Status(visualizer, validator);
                DefaultHandlingPositionEnum startPosition = new DefaultHandlingPositionEnum();

                List<(int, int, string, bool)> rightHandledExercises = status.PrepareForStatusUpdate(updatedCourse, startPosition);
                List<string> totalStatus = await status.GetStatus(updatedCourse, rightHandledExercises);

           
                UpdateCourseResponseViewModel updateCourseResponseViewModel = new UpdateCourseResponseViewModel(
                updatedCourse.CourseId,
                updatedCourse.Level,
                updateExerciseVMList,
                totalStatus
                );
                
               
               

                return Ok(updateCourseResponseViewModel);

            }

            return BadRequest("UpdatedCourse was null");
            
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCourse(int courseId)
        {
            if (courseId <= 0) return BadRequest("CourseId must be larger than zero");

            await _courseRepository.DeleteCourse(courseId);

            return Ok();
        }
    }
}
