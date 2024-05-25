using Core.Domain.Entities;

namespace API.ViewModels;

public class UpdateCourseResponse
{
    public required int CourseId { get; init; }
    public required LevelEnum Level { get; init; }
    public required List<UpdateExerciseResponse> UpdateExerciseVMList { get; init; }
    public required List<string> StatusStrings { get; init; }
    public required Event? Event { get; init; }
    public required Judge? Judge { get; init; }
    public required ThemeEnum? Theme { get; init; }
    public required bool? IsStartPositionLeftHandled { get; init; }

    public static UpdateCourseResponse ConvertToUpdateCourseResponse(Course updatedCourse)
    {
        return new UpdateCourseResponse
        {
            CourseId = updatedCourse.CourseId,
            Level = updatedCourse.Level,
            StatusStrings = updatedCourse.StatusStrings,
            Judge = updatedCourse.Judge,
            Event = updatedCourse.Event,
            Theme = updatedCourse.Theme,
            IsStartPositionLeftHandled = updatedCourse.IsStartPositionLeftHandled,
            UpdateExerciseVMList = updatedCourse.ExerciseList
                        .Select(exercise => UpdateExerciseResponse.ConvertToUpdateExerciseResponse(exercise))
                        .ToList()
        };
    }
}
