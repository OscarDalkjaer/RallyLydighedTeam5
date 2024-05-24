using Core.Domain.Entities;

namespace API.ViewModels
{
    public class GetAllJudgesViewModel
    {
        public List<GetJudgeViewModel> Judges { get; set; }

        public GetAllJudgesViewModel(IEnumerable<Judge> judges)
        {
            Judges = judges
                .Select(j => new GetJudgeViewModel(j.JudgeId, j.FirstName, j.LastName))
                .ToList();
        }
    }
}
