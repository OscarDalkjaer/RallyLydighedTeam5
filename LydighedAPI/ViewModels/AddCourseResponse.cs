using Core.Domain.Entities;

namespace API.ViewModels;

public class AddCourseResponse
{
    public required int CourseId { get; set; }
    public required LevelEnum Level { get; set; }
    public required List<int> ExerciseNumbers { get; set; }

    public static AddCourseResponse ConvertCourseToAddCourseResponseViewModel(Course course)
    {
        return new AddCourseResponse
        {
            CourseId = course.CourseId,
            Level = course.Level,
            ExerciseNumbers = course.ExerciseList.Select(x => x.Number).ToList()
        };
    }


































}
