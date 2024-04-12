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
        public async Task AddJudge(string firstName, string lastName)
        {
            //AddJudgeViewModel addJudgeViewModel = new AddJudgeViewModel(firstName, lastName);
            //await _judgeRepository.AddJudge(addJudgeViewModel);

            await _judgeRepository.AddJudge(firstName, lastName);
        }


        [HttpGet("{judgeId}", Name = "GetJudge")]
        public async Task<GetJudgeViewModel> GetJudge(int judgeId)
        {
            Task<Judge> judgeTask = _judgeRepository.GetJudge(judgeId);
            Judge judge = judgeTask.Result;
            GetJudgeViewModel viewModel = new GetJudgeViewModel(judge);
            return viewModel;
        }

        [HttpGet(Name = "GetAllJudges")]
        public async Task<IEnumerable<Judge>> GetAllJudges()
        {
            return await _judgeRepository.GetAllJudges();
        }


    }
}
