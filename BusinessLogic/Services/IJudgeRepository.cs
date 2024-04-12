using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IJudgeRepository
    {
        public Task AddJudge(Judge judge);
        public Task<Judge> GetJudge(int judgeId);
        public Task<IEnumerable<Judge>> GetAllJudges();
        public Task UpdateJudge(Judge updatedJudge);
        public Task DeleteJudge(int judgeId);
        
    }
}
