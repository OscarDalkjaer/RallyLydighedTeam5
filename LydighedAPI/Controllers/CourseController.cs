using API.ViewModels;
using Core.Application.UpdateCourse;
using Core.Domain.Entities;
using Core.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IExerciseRepository? _exerciseRepository;
        private readonly CourseUpdateService? _courseUpdateService;

        public CourseController(ICourseRepository courseRepository, IExerciseRepository exerciseRepository,
            CourseUpdateService? courseUpdateService)
        {
            _courseRepository = courseRepository;
            _exerciseRepository = exerciseRepository;
            _courseUpdateService = courseUpdateService;
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

        [HttpGet("ByTheme/{Theme}", Name = "GetAllCoursesWithSpecifiedTheme")]
        public async Task<IActionResult> GetAllCoursesWithSpecifiedTheme(ThemeEnum theme)
        {
            IEnumerable<Course> courses = await _courseRepository.GetAllCoursesWithSpecifiedTheme(theme);
            GetAllCoursesViewModel getAllCoursesViewModel = new GetAllCoursesViewModel(courses);

            return getAllCoursesViewModel.Courses.Count is 0
                ? NoContent()
                : Ok(getAllCoursesViewModel);
        }


        [HttpGet("ByExerciseCount/{rangeLow}, {rangeHigh}", Name = "GetAllCoursesWithSpecifiedRangeOfExerciseCount")]
        public async Task<IActionResult> GetAllCoursesWithSpecifiedRangeOfExerciseCount(int rangeLow, int rangeHigh)
        {
            IEnumerable<Course> courses = await _courseRepository.GetAllCoursesWithSpecifiedRangeOfExerciseCount(rangeLow, rangeHigh);
            GetAllCoursesViewModel getAllCoursesViewModel = new GetAllCoursesViewModel(courses);

            return getAllCoursesViewModel.Courses.Count is 0
                ? NoContent()
                : Ok(getAllCoursesViewModel);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCourse([FromBody] UpdateCourseRequestViewModel updateCourseRequestViewModel)
        {
            if (updateCourseRequestViewModel is null) return BadRequest("ViewModel was null");

            Course courseToUpdate = await _courseUpdateService.IsCourseReadyForUpdate(updateCourseRequestViewModel.CourseId, updateCourseRequestViewModel.Level,
              updateCourseRequestViewModel.ExerciseNumbers, updateCourseRequestViewModel.IsStartPositionLeftHandled,
              updateCourseRequestViewModel.JudgeId, updateCourseRequestViewModel.EventId, updateCourseRequestViewModel.Theme);

            Course? updatedCourse;

            try
            {
                updatedCourse = await _courseRepository.UpdateCourse(courseToUpdate);
            }
            catch
            {
                return BadRequest(courseToUpdate);
            }
            
            if (updatedCourse != null) 
            {
                List<UpdateExerciseResponseViewModel> updateExerciseVMList = updatedCourse.ExerciseList.Select(x =>
                 new UpdateExerciseResponseViewModel(x.ExerciseId, x.Number, x.Name, x.Description)).ToList();

                UpdateCourseResponseViewModel updateCourseResponseViewModel = new UpdateCourseResponseViewModel(
                updatedCourse.CourseId,
                updatedCourse.Level,
                updateExerciseVMList,
                updatedCourse.StatusStrings,
                updatedCourse.Judge,
                updatedCourse.Event
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
