using Core.Domain.Entities;

namespace API.ViewModels;

public class UpdateJudgeRequest
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required int UpdatedJudgeId { get; init; }

    public Judge ConvertToJudge()
    {
        return new Judge(FirstName, LastName, UpdatedJudgeId);
    }
}
