using API.ViewModels;
using Core.Application.UpdateCourse;
using Core.Domain.Entities;
using Core.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseRepository _courseRepository;
    private readonly CourseUpdateService? _courseUpdateService;

    public CourseController(ICourseRepository courseRepository, CourseUpdateService? courseUpdateService)
    {
        _courseRepository = courseRepository;
        _courseUpdateService = courseUpdateService;
    }

    [HttpPost]
    public async Task<ActionResult<AddCourseResponse>> AddCourse([FromBody] AddCourseRequest addCourseRequest)
    {
        if (addCourseRequest == null) return BadRequest("viewModel was null");
        Course course = new Course(addCourseRequest.Level);

        Course? addetCourse = await _courseRepository.AddCourse(course);
        if (addetCourse == null) return BadRequest("Course was not addet to database");

        AddCourseResponse addCourseResponse = AddCourseResponse.ConvertCourseToAddCourseResponseViewModel(addetCourse);
        return Ok(addCourseResponse);
    }

    [HttpGet("{courseId}", Name = "GetCourse")]
    public async Task<ActionResult<GetCourseResponse>> GetCourse(int courseId)
    {
        if (courseId <= 0) return BadRequest("CourseId must be larger than zero");

        Course? course = await _courseRepository.GetCourse(courseId);

        if (course == null) return NotFound($"Course with id {courseId} does not exists");
        
        GetCourseResponse getCourseResponse = GetCourseResponse.ConvertFromCourse(course);
        return Ok(getCourseResponse);
    }

    [HttpGet(Name = "GetAllCourses")]
    public async Task<ActionResult<GetAllCoursesResponse>> GetAllCourses()
    {
        IEnumerable<Course> courses = await _courseRepository.GetAllCourses();
        GetAllCoursesResponse getAllCoursesResponse = GetAllCoursesResponse.ConvertFromCourses(courses);

        return getAllCoursesResponse.IsEmpty()
            ? NoContent()
            : Ok(getAllCoursesResponse);
    }

    [HttpGet("ByTheme/{theme}", Name = "GetAllCoursesWithSpecifiedTheme")]
    public async Task<ActionResult<GetAllCoursesResponse>> GetAllCoursesWithSpecifiedTheme(ThemeEnum theme)
    {
        IEnumerable<Course> courses = await _courseRepository.GetAllCoursesWithSpecifiedTheme(theme);
        GetAllCoursesResponse getAllCoursesResponse = GetAllCoursesResponse.ConvertFromCourses(courses);

        return getAllCoursesResponse.IsEmpty()
            ? NoContent()
            : Ok(getAllCoursesResponse);
    }

    [HttpGet("ByExerciseCount/{rangeLow}, {rangeHigh}", Name = "GetAllCoursesWithSpecifiedRangeOfExerciseCount")]
    public async Task<ActionResult<GetAllCoursesResponse>> GetAllCoursesWithSpecifiedRangeOfExerciseCount(int rangeLow, int rangeHigh)
    {
        IEnumerable<Course> courses = await _courseRepository.GetAllCoursesWithSpecifiedRangeOfExerciseCount(rangeLow, rangeHigh);
        GetAllCoursesResponse getAllCoursesResponse = GetAllCoursesResponse.ConvertFromCourses(courses);

        return getAllCoursesResponse.IsEmpty()
            ? NoContent()
            : Ok(getAllCoursesResponse);
    }

    [HttpPut]
    public async Task<ActionResult<UpdateCourseResponse>> UpdateCourse([FromBody] UpdateCourseRequest courseUpdateRequest)
    {
        if (courseUpdateRequest is null) return BadRequest("ViewModel was null");

        Course courseToUpdate = await _courseUpdateService!.IsCourseReadyForUpdate(
            courseUpdateRequest.CourseId,
            courseUpdateRequest.Level,
            courseUpdateRequest.ExerciseNumbers,
            courseUpdateRequest.IsStartPositionLeftHandled,
            courseUpdateRequest.JudgeId,
            courseUpdateRequest.EventId,
            courseUpdateRequest.Theme);

        try
        {
            await _courseRepository.UpdateCourse(courseToUpdate);
            UpdateCourseResponse updateCourseResponse = UpdateCourseResponse.ConvertToUpdateCourseResponse(courseToUpdate);
            return Ok(updateCourseResponse);
        }
        catch
        {
            return BadRequest(courseToUpdate);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCourse(int courseId)
    {
        if (courseId <= 0) return BadRequest("CourseId must be larger than zero");
        await _courseRepository.DeleteCourse(courseId);

        return Ok();
    }
}
