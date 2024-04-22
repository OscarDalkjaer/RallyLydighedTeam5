using API.ViewModels;
using BusinessLogic.Models;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

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
        public async Task <IActionResult> AddJudge([FromBody] AddJudgeViewModel addJudgeViewModel)
        {
           if (addJudgeViewModel == null) return BadRequest("ViewModel was null");       
           
            Judge judge = new Judge(addJudgeViewModel.FirstName, addJudgeViewModel.LastName);
            await _judgeRepository.AddJudge(judge);

            return Ok();
        }


        [HttpGet("{judgeId}", Name = "GetJudge")]
        public async Task<IActionResult> GetJudge(int judgeId)
        {
            if (judgeId <= 0) return BadRequest("JudgeId must be larger than zero");

            Judge? judge = await _judgeRepository.GetJudge(judgeId);

            if (judge == null) return NotFound($"Judge with Id {judgeId} does not exist");

            GetJudgeViewModel viewModel = new GetJudgeViewModel(judgeId, judge.FirstName, judge.LastName);
            return Ok (viewModel);
        }


        [HttpGet(Name = "GetAllJudges")]
        public async Task<IActionResult> GetAllJudges()
        {
            IEnumerable<Judge> judges= await _judgeRepository.GetAllJudges();            
            GetAllJudgesViewModel getAllJudgesViewModel = new GetAllJudgesViewModel(judges);

            return getAllJudgesViewModel.Judges.Count is 0
                ? NoContent()
                : Ok(getAllJudgesViewModel);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateJudge([FromBody]UpdateJudgeViewModel updatedJudgeViewModel)
        {
            if (updatedJudgeViewModel is null) return BadRequest("ViewModel is null");

            Judge judge = new Judge(
                firstName: updatedJudgeViewModel.FirstName,
                lastName: updatedJudgeViewModel.LastName,
                judgeId: updatedJudgeViewModel.UpdatedJudgeId);
            await _judgeRepository.UpdateJudge(judge);

            return Ok();
        }

        [HttpDelete]
        public async Task <IActionResult> DeleteJudge(int judgeId)
        {
            if (judgeId <= 0) return BadRequest("JudgeId must be larger than zero");

            await _judgeRepository.DeleteJudge(judgeId);

            return Ok();
        }
    }
}
