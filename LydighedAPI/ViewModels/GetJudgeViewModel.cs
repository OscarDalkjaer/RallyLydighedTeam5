using Core.Domain.Entities;

namespace API.ViewModels
{
    public class GetJudgeViewModel
    {
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required int? JudgeId { get; init; }

        public static GetJudgeViewModel ConvertFromJudge(Judge judge)
        {
            return new GetJudgeViewModel
            {

                JudgeId = judge.JudgeId,
                FirstName = judge.FirstName,
                LastName = judge.LastName
            };

        }
    }
}