using Core.Domain.Entities;

namespace API.ViewModels;

public class GetCourseViewModel
{
    public required LevelEnum Level { get; init; }
    public required int CourseId { get; init; }
    public required List<GetExerciseResponse> GetExerciseViewModels { get; init; }

    public static GetCourseViewModel ConvertFromCourse(Course course)
    {
        return new GetCourseViewModel
        {
            CourseId = course.CourseId,
            Level = course.Level,
            GetExerciseViewModels = course.ExerciseList
                .Select(exercise => GetExerciseResponse.ConvertFromExercise(exercise))
                .ToList()
        };
    }
}