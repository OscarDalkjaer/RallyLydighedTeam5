namespace API.ViewModels;

public class UpdateJudgeResponse
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required int? UpdatedJudgeId { get;  init; }
}
