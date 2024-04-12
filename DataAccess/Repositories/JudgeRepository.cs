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


       public async Task AddJudge(string firstName, string lastName)

        {
           
            if (firstName != null && lastName != null) 
            {
                _context.Judges.Add(new Judge(firstName, lastName));
            }
            _context.SaveChanges();
        }

        public async Task<Judge> GetJudge(int judgeId)
        {
           return _context.Judges.FirstOrDefault(j => j.JudgeId == judgeId);

        }

        public async Task<IEnumerable<Judge>> GetAllJudges()
        {
           return await _context.Judges.ToListAsync();
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
