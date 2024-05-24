using System.Net;
using Core.Domain.Entities;

namespace API.ViewModels;

public class GetAllCoursesResponse
{
    public required List<GetCourseViewModel> Courses { get; init; }

    public static GetAllCoursesResponse ConvertFromCourses(IEnumerable<Course> courses)
    {
        return new GetAllCoursesResponse
        {
            Courses = courses
                .Select(course => GetCourseViewModel.ConvertFromCourse(course))
                .ToList()
        };
    }
}