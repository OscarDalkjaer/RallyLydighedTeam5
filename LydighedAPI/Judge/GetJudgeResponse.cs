using Core.Domain.Entities;

namespace API.ViewModels;

public class GetJudgeResponse
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required int? JudgeId { get; init; }

    public static GetJudgeResponse ConvertFromJudge(Judge judge)
    {
        return new GetJudgeResponse
        {

            JudgeId = judge.JudgeId,
            FirstName = judge.FirstName,
            LastName = judge.LastName
        };

    }
}