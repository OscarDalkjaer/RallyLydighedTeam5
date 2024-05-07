using BusinessLogic.Models;

namespace API.ViewModels;

public class GetAllCoursesViewModel
{
    public List<GetCourseViewModel> Courses { get; }

    public GetAllCoursesViewModel(IEnumerable<Course> courses)
    {
        Courses = courses
            .Select(c => new GetCourseViewModel(c.CourseId, c.Level, c.ExerciseList))
            .ToList();
    }
}