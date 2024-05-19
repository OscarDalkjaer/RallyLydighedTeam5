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
        private readonly IExerciseRepository? _exerciseRepository;

        public CourseController(ICourseRepository courseRepository, IExerciseRepository exerciseRepository)
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

            //AddCourseResponseViewModel addCourseResponsViewModel = new AddCourseResponseViewModel(
            //    addetCourse.CourseId, addetCourse.Level, addetCourse.ExerciseList.ToList());

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

            List<Exercise>? exercisesFromExerciseNumbers = await _exerciseRepository
                .GetExercisesFromNumbers(updateCourseRequestViewModel.ExerciseNumbers);

            //List<Exercise> exerciseList = updateCourseRequestViewModel.UpdateExerciseVMList.Select(x =>
            //    new Exercise(x.UpdateExerciseViewModelId, x.Number, x.Name, x.Description, x.DefaultHandlingPosition,
            //x.Stationary, x.WithCone, x.TypeOfJump, x.Level)).ToList();
                        
            Course courseToUpdate = new Course(
                updateCourseRequestViewModel.CourseId, 
                updateCourseRequestViewModel.Level
                );

            foreach (Exercise exercise in exercisesFromExerciseNumbers)
            {
                courseToUpdate.ExerciseList.Add(exercise);                
            }

            Course? updatedCourse = await _courseRepository.UpdateCourse(courseToUpdate);
            if (updatedCourse != null) 
            {
                List<UpdateExerciseResponseViewModel> updateExerciseVMList = updatedCourse.ExerciseList.Select(x =>
                 new UpdateExerciseResponseViewModel(x.ExerciseId, x.Number, x.Name, x.Description)).ToList();
           
                UpdateCourseResponseViewModel updateCourseResponseViewModel = new UpdateCourseResponseViewModel(
                updatedCourse.CourseId,
                updatedCourse.Level,
                updateExerciseVMList);

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
