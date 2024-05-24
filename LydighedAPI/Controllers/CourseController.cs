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
        public async Task<IActionResult> AddCourse([FromBody] AddCourseRequest addCourseViewModel)
        {
            if (addCourseViewModel == null) return BadRequest("viewModel was null");

            Course course = new Course(addCourseViewModel.Level);
            Course? addetCourse = await _courseRepository.AddCourse(course);
            if (addetCourse == null) 
            {
                return BadRequest("Course was not addet to database");
            }

            AddCourseResponse addCourseResponseViewModel = AddCourseResponse
                .ConvertCourseToAddCourseResponseViewModel(addetCourse);  

            return Ok(addCourseResponseViewModel);
        }


        [HttpGet("{courseId}", Name = "GetCourse")]
        public async Task<IActionResult> GetCourse(int courseId)
        {
            if (courseId <= 0) return BadRequest("CourseId must be larger than zero");

            Course? course = await _courseRepository.GetCourse(courseId);

            if (course == null) return NotFound($"Course with id {courseId} does not exists");

            GetCourseViewModel getCourseViewModel = GetCourseViewModel.ConvertFromCourse(course);

            return Ok(getCourseViewModel);
        }

        [HttpGet(Name = "GetAllCourses")]
        public async Task<IActionResult> GetAllCourses()
        {
            IEnumerable<Course> courses = await _courseRepository.GetAllCourses();
            GetAllCoursesResponse getAllCoursesViewModel = GetAllCoursesResponse.ConvertFromCourses(courses);

            return getAllCoursesViewModel.Courses.Count is 0
                ? NoContent()
                : Ok(getAllCoursesViewModel);
        }

        [HttpGet("ByTheme/{theme}", Name = "GetAllCoursesWithSpecifiedTheme")]
        public async Task<IActionResult> GetAllCoursesWithSpecifiedTheme(ThemeEnum theme)
        {
            IEnumerable<Course> courses = await _courseRepository.GetAllCoursesWithSpecifiedTheme(theme);
            GetAllCoursesResponse getAllCoursesViewModel = GetAllCoursesResponse.ConvertFromCourses(courses);

            return getAllCoursesViewModel.Courses.Count is 0
                ? NoContent()
                : Ok(getAllCoursesViewModel);
        }


        [HttpGet("ByExerciseCount/{rangeLow}, {rangeHigh}", Name = "GetAllCoursesWithSpecifiedRangeOfExerciseCount")]
        public async Task<IActionResult> GetAllCoursesWithSpecifiedRangeOfExerciseCount(int rangeLow, int rangeHigh)
        {
            IEnumerable<Course> courses = await _courseRepository.GetAllCoursesWithSpecifiedRangeOfExerciseCount(rangeLow, rangeHigh);
            GetAllCoursesResponse getAllCoursesViewModel = GetAllCoursesResponse.ConvertFromCourses(courses);

            return getAllCoursesViewModel.Courses.Count is 0
                ? NoContent()
                : Ok(getAllCoursesViewModel);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCourse([FromBody] UpdateCourseRequest updateCourseRequestViewModel)
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
                List<UpdateExerciseResponse> updateExerciseVMList = updatedCourse.ExerciseList.Select(x =>
                 new UpdateExerciseResponse(x.ExerciseId, x.Number, x.Name, x.Description)).ToList();

                UpdateCourseResponse updateCourseResponseViewModel = new UpdateCourseResponse
                {
                    CourseId = updatedCourse.CourseId,
                    Level = updatedCourse.Level,
                    UpdateExerciseVMList = updateExerciseVMList,
                    StatusStrings = updatedCourse.StatusStrings,
                    Judge = updatedCourse.Judge,
                    Event = updatedCourse.Event,
                    Theme = updatedCourse.Theme,
                    IsStartPositionLeftHandled = updatedCourse.IsStartPositionLeftHandled
                };
                
                
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
