using Core.Domain.Entities;

namespace API.ViewModels;

public class GetAllJudgesResponse
{
    public required List<GetJudgeResponse> Judges { get; init; }

    public static GetAllJudgesResponse ConverFromJudges(IEnumerable<Judge> judges)
    {
        return new GetAllJudgesResponse
        {
            Judges = judges
                .Select(judge => GetJudgeResponse.ConvertFromJudge(judge))
                .ToList()
        };
    }
}
