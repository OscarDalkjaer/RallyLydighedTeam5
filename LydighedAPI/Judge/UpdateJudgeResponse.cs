using Core.Domain.Entities;

namespace API.ViewModels;

public class UpdateJudgeResponse
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required int? UpdatedJudgeId { get; init; }

    public static UpdateJudgeResponse ConvertToJudgeCourseResponse(Judge judge)
    {
        return new UpdateJudgeResponse
        {
            UpdatedJudgeId = judge.JudgeId,
            FirstName = judge.FirstName,
            LastName = judge.LastName
        };
    }
}
