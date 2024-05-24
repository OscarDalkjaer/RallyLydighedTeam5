using Core.Domain.Entities;

namespace API.ViewModels;

public class GetCourseResponse
{
    public required LevelEnum Level { get; init; }
    public required int CourseId { get; init; }
    public required List<GetExerciseResponse> GetExerciseViewModels { get; init; }

    public static GetCourseResponse ConvertFromCourse(Course course)
    {
        return new GetCourseResponse
        {
            CourseId = course.CourseId,
            Level = course.Level,
            GetExerciseViewModels = course.ExerciseList
                .Select(exercise => GetExerciseResponse.ConvertFromExercise(exercise))
                .ToList()
        };
    }
}