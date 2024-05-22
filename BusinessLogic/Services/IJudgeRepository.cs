﻿using BusinessLogic.Models;

namespace BusinessLogic.Services
{
    public interface IJudgeRepository
    {
        Task AddJudge(Judge judge);
        Task<Judge?> GetJudge(int judgeId);
        Task<IEnumerable<Judge>> GetAllJudges();
        Task UpdateJudge(Judge updatedJudge);
        Task DeleteJudge(int judgeId);
      
    }
}
