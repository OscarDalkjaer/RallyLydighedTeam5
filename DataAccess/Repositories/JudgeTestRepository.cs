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

        public async Task<Judge> GetJudge(int judgeId)
        {
            if (judgeId != 0)
            {
                return (TestJudges.FirstOrDefault(j => j.JudgeId == judgeId));
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
        public Task DeleteJudge(int judgeId)
        {
            throw new NotImplementedException();
        }

        

        

        public Task UpdateJudge(int judgeId)
        {
            throw new NotImplementedException();
        }
    }
}
