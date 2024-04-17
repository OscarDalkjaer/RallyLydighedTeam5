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

        public async Task AddJudge(Judge judge)
        {
            int count = TestJudges.Count;
            int judgeId = count + 1;
            TestJudges.Add(new Judge(judge.FirstName, judge.LastName, judgeId));
        }

        public async Task<Judge> GetJudge(int judgeId)
        {
            if (judgeId != 0)
            {
                Judge judge = TestJudges.FirstOrDefault(j => j.JudgeId == judgeId);
                return await Task.FromResult(judge);
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<Judge>> GetAllJudges()
        {
            IEnumerable<Judge> judges = TestJudges;
            return judges;
        }

        public async Task UpdateJudge(Judge updatedJudge)
        {
            Judge judgeToUpdate = TestJudges.FirstOrDefault(j => j.JudgeId==updatedJudge.JudgeId);
            judgeToUpdate.FirstName = updatedJudge.FirstName;
            judgeToUpdate.LastName = updatedJudge.LastName;
            await Task.CompletedTask;
            
        }
        public Task DeleteJudge(int judgeId)
        {
            Judge judgeToDelete = TestJudges.FirstOrDefault(j => j.JudgeId == judgeId);
            if(judgeToDelete != null) 
            {
                TestJudges.Remove(judgeToDelete);
            }
            return Task.CompletedTask;
        }

        

        

        
    }
}
