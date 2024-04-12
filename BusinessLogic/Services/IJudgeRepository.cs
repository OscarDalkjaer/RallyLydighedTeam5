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
        public Task AddJudge(string firstName, string lastName);
        public Task<Judge> GetJudge(int judgeId);
        public Task<IEnumerable<Judge>> GetAllJudges();
        public Task UpdateJudge(int judgeId);
        public Task DeleteJudge(int judgeId);
        
    }
}
