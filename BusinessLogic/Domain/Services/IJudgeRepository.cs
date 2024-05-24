using Core.Domain.Entities;

namespace Core.Domain.Services
{
    public interface IJudgeRepository
    {
        Task AddJudge(Judge judge);
        Task<Judge?> GetJudge(int judgeId);
        Task<IEnumerable<Judge>> GetAllJudges();
        Task UpdateJudge(Judge updatedJudge);
        Task DeleteJudge(int judgeId);

        Task<List<Judge>> GetJudgesFromFirstName(string firstName);
        Task<List<Judge>> GetJudgesFromLastName(string lastName);
    }
}
