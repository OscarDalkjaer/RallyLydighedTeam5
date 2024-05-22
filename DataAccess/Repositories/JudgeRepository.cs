using BusinessLogic.Models;
using BusinessLogic.Services;
using DataAccess.DataAccessModels;
using DataAccessDbContext;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class JudgeRepository : BusinessLogic.Services.IJudgeRepository
{
    private readonly CourseContext _context;

    public JudgeRepository(CourseContext context)
    {
        _context = context;
    }


    public async Task AddJudge(Judge judge)
    {
        JudgeDataAccessModel judgeDataAccessModel = new JudgeDataAccessModel(judge.FirstName, judge.LastName, judge.JudgeId);   
        _context.JudgeDataAccessModels.Add(judgeDataAccessModel);        
        await _context.SaveChangesAsync();       
    }


    public async Task<Judge?> GetJudge(int judgeId)
    {
        JudgeDataAccessModel? accessModel = await _context.JudgeDataAccessModels.FirstOrDefaultAsync(j => j.JudgeDataAccessModelId == judgeId);
        Judge? judge = FromAccessModelToJudge(accessModel);
        return judge;
    }


    public async Task<IEnumerable<Judge>> GetAllJudges()
    {
        List<JudgeDataAccessModel> dataAccessModels = await _context.JudgeDataAccessModels.ToListAsync();
        List<Judge> judges = dataAccessModels.Select(x=>new Judge(x.FirstName, x.LastName, x.JudgeDataAccessModelId)).ToList();
        return judges;
    }


    public async Task UpdateJudge(Judge updatedJudge)
    {
        JudgeDataAccessModel? dataAccessModel = await _context.JudgeDataAccessModels.SingleOrDefaultAsync(j => 
            j.JudgeDataAccessModelId == updatedJudge.JudgeId);

        if (dataAccessModel != null) 
        {
            dataAccessModel.FirstName = updatedJudge.FirstName;
            dataAccessModel.LastName = updatedJudge.LastName;
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteJudge(int judgeId)
    {
        JudgeDataAccessModel? dataAccessModelToDelete = await _context.JudgeDataAccessModels.FirstOrDefaultAsync(j => j.JudgeDataAccessModelId == judgeId);
       
        if (dataAccessModelToDelete != null) 
        {
            _context.JudgeDataAccessModels.Remove(dataAccessModelToDelete);
            await _context.SaveChangesAsync();
        }
    }

    public Judge FromAccessModelToJudge(JudgeDataAccessModel judgeDataAccessModel)
    {
        return new Judge(
            judgeDataAccessModel.FirstName,
            judgeDataAccessModel.LastName,
            judgeDataAccessModel.JudgeDataAccessModelId
            );
    }
}