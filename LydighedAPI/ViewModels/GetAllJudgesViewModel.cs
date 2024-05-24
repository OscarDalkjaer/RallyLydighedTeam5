using Core.Domain.Entities;

namespace API.ViewModels
{
    public class GetAllJudgesResponse
    {
        public required List<GetJudgeViewModel> Judges { get; init; }

        public static GetAllJudgesResponse ConverFromJudges(IEnumerable<Judge> judges)
        {
            return new GetAllJudgesResponse
            {
                Judges = judges
                    .Select(judge => GetJudgeViewModel.ConvertFromJudge(judge))
                    .ToList()
            };
        }
    }
}
