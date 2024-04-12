using API.ViewModels;
using BusinessLogic.Models;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JudgeController : ControllerBase
    {
        private readonly IJudgeRepository _judgeRepository;

        public JudgeController(IJudgeRepository judgeRepository)
        {
            _judgeRepository = judgeRepository;
        }

        [HttpPost]
        public async Task AddJudge([FromBody] AddJudgeViewModel addJudgeViewModel)
        {
            if (addJudgeViewModel != null) 
            {
                Judge judge = new Judge(addJudgeViewModel.FirstName, addJudgeViewModel.LastName);
                await _judgeRepository.AddJudge(judge);
            }
            
        }


        [HttpGet("{judgeId}", Name = "GetJudge")]
        public async Task<GetJudgeViewModel> GetJudge(int judgeId)
        {
            Judge judge = await _judgeRepository.GetJudge(judgeId);
            GetJudgeViewModel viewModel = new GetJudgeViewModel(judge);
            return viewModel;
        }

        [HttpGet(Name = "GetAllJudges")]
        public async Task<IEnumerable<GetJudgeViewModel>> GetAllJudges()
        {
            IEnumerable<Judge> judges= await _judgeRepository.GetAllJudges();
            IEnumerable<GetJudgeViewModel> judgesVM = judges.Select(x => new GetJudgeViewModel(x));
            return judgesVM;
                        
        }

        [HttpPut]
        public async Task UpdateJudge(Judge updatedJudge)
        {
            await _judgeRepository.UpdateJudge(updatedJudge);
        }
    }
}
