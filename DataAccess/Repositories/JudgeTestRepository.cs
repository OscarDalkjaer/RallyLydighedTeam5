using BusinessLogic.Models;
using BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class JudgeTestRepository : IJudgeRepository
    {
        public List<Judge> TestJudges = new List<Judge>();

        public async Task AddJudge(string firstName, string lastName)
        {
            int count = TestJudges.Count;
            int judgeId = count + 1;
            TestJudges.Add(new Judge(firstName, lastName, judgeId));
        }

        public Task DeleteJudge(int judgeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Judge>> GetAllJudges()
        {
            throw new NotImplementedException();
        }

        public Task<Judge> GetJudge(int judgeId)
        {
            if(judgeId != 0) 
            {
                 return Task.FromResult(TestJudges.FirstOrDefault(j => j.JudgeId == judgeId));
            }
            else 
            {
                return null;
            }
        }

        public Task UpdateJudge(int judgeId)
        {
            throw new NotImplementedException();
        }
    }
}
