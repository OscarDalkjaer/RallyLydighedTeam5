using API.ViewModels;
using BusinessLogic.Models;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly CourseBuilder _courseBuilder;

        public CourseController(ICourseRepository courseRepository, CourseBuilder courseBuilder)
        {
            _courseRepository = courseRepository;
            _courseBuilder = courseBuilder;
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] AddCourseRequestViewModel addCourseViewModel)
        {
            if (addCourseViewModel == null) return BadRequest("viewModel was null");

            Course course = new Course(addCourseViewModel.Level);

            //Course course = await _courseBuilder.BuildCourseWithExercises(addCourseViewModel.Level);
            
            Course? addetCourse = await _courseRepository.AddCourse(course);
            if (addetCourse == null) 
            {
                return BadRequest("Course was not addet to database");
            }

            AddCourseResponsViewModel addCourseResponsViewModel = new AddCourseResponsViewModel(
                addetCourse.CourseId, addetCourse.Level, addetCourse.ExerciseList.ToList());

            return Ok(addCourseResponsViewModel);
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

        [HttpPut]
        public async Task<IActionResult> UpdateCourse([FromBody] UpdateCourseRequestViewModel updateCourseRequestViewModel)
        {
            if (updateCourseRequestViewModel is null) return BadRequest("ViewModel was null");

            List<Exercise> ExerciseList = updateCourseRequestViewModel.ExerciseVMList.Select(x =>
                new Exercise(x.ExerciseId, x.Number, x.Type)).ToList();
                        

            Course courseToUpdate = new Course(
                updateCourseRequestViewModel.CourseId, 
                updateCourseRequestViewModel.Level,
                ExerciseList);

            Course? updatedCourse = await _courseRepository.UpdateCourse(courseToUpdate);

            List<ExerciseViewModel> ExerciseVMList = updatedCourse.ExerciseList.Select(x =>
            new ExerciseViewModel(x.ExerciseId, x.Number, x.Type)).ToList();

            if(updatedCourse != null) 
            {
                UpdateCourseResponseViewModel updateCourseResponseViewModel = new UpdateCourseResponseViewModel(
                updatedCourse.CourseId,
                updatedCourse.Level,
                ExerciseVMList);

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
