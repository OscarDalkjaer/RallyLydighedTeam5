using BusinessLogic.Models;
using BusinessLogic.Services;
using DataAccessDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class JudgeRepository : IJudgeRepository
    {
        private readonly CourseContext _context;

        public JudgeRepository(CourseContext context)
        {
            _context = context;
        }


        public async Task AddJudge(Judge judge)
        {
            if (judge != null)
            {
                _context.Judges.Add(judge);
            }
            _context.SaveChanges();
        }

        public async Task<Judge?> GetJudge(int judgeId)
        {
            return  await _context.Judges.FirstOrDefaultAsync(j => j.JudgeId == judgeId);
        }

        public async Task<IEnumerable<Judge>> GetAllJudges()
        {
            return await _context.Judges.ToListAsync();
        }


        public async Task UpdateJudge(Judge updatedJudge)
        {
            Judge? judge = _context.Judges.FirstOrDefault(j => j.JudgeId == updatedJudge.JudgeId);
            if (judge != null)
            {
                judge.FirstName = updatedJudge.FirstName;
                judge.LastName = updatedJudge.LastName;
              //  _context.Judges.Update(judge);
                await _context.SaveChangesAsync();
            }
        }

        public Task DeleteJudge(int judgeId)
        {
            Judge judgeToDelete = _context.Judges.FirstOrDefault(j => j.JudgeId==judgeId);
            _context.Judges.Remove(judgeToDelete);
            return Task.CompletedTask;

        }

       


    }
}