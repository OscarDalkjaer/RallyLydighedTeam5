using BusinessLogic.Models;
using BusinessLogic.Services;
using DataAccessDbContext;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class JudgeRepository : IJudgeRepository
{
    private readonly CourseContext _context;

    public JudgeRepository(CourseContext context)
    {
        _context = context;
    }


    public async Task AddJudge(Judge judge)
    {         
        _context.Judges.Add(judge);        
        await _context.SaveChangesAsync();
       
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
        Judge? judge = await _context.Judges
            .FirstOrDefaultAsync(j => j.JudgeId == updatedJudge.JudgeId);
        if (judge != null)
        {
            judge.FirstName = updatedJudge.FirstName;
            judge.LastName = updatedJudge.LastName;
            await _context.SaveChangesAsync();
        }
    }


    public async Task DeleteJudge(int judgeId)
    {
        Judge? judgeToDelete = await _context.Judges.FirstOrDefaultAsync(j => j.JudgeId==judgeId);
        if (judgeToDelete != null) 
        {
            _context.Judges.Remove(judgeToDelete);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<int?> GetMaxJudgeId()
    {
        return await _context.Judges.MaxAsync(x => x.JudgeId);
    }

    //public async Task<int?> GetMaxJudgeId()
    //{
    //    
    //}
}