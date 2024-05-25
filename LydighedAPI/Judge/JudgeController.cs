using API.ViewModels;
using Core.Domain.Entities;
using Core.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

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
    public async Task<ActionResult<AddJudgeResponse>> AddJudge([FromBody] AddJudgeRequest addJudgeRequest)
    {
        if (addJudgeRequest == null) return BadRequest("ViewModel was null");

        Judge judge = new Judge(addJudgeRequest.FirstName, addJudgeRequest.LastName);
        await _judgeRepository.AddJudge(judge);

        AddJudgeResponse addJudgeResponseViewModel = new AddJudgeResponse
        {
            JudgeId = judge.JudgeId,
            FirstName = judge.FirstName,
            LastName = judge.LastName
        };

        return Ok(addJudgeResponseViewModel);
    }

    [HttpGet("{judgeId}", Name = "GetJudge")]
    public async Task<ActionResult<GetJudgeResponse>> GetJudge(int judgeId)
    {
        if (judgeId <= 0) return BadRequest("JudgeId must be larger than zero");

        Judge? judge = await _judgeRepository.GetJudge(judgeId);
        if (judge == null) return NotFound($"JudgeDataAccessModel with Id {judgeId} does not exist");

        GetJudgeResponse viewModel = GetJudgeResponse.ConvertFromJudge(judge);
        return Ok(viewModel);
    }

    [HttpGet(Name = "GetAllJudges")]
    public async Task<ActionResult<GetAllJudgesResponse>> GetAllJudges()
    {
        IEnumerable<Judge> judges = await _judgeRepository.GetAllJudges();
        GetAllJudgesResponse getAllJudgesViewModel = GetAllJudgesResponse.ConverFromJudges(judges);

        return getAllJudgesViewModel.IsEmpty()
            ? NoContent()
            : Ok(getAllJudgesViewModel);
    }

    [HttpGet("byFirstName/{firstName}", Name = "GetJudgesFromFirstName")]
    public async Task<ActionResult<GetAllJudgesResponse>> GetJudgesFromFirstName(string firstName)
    {
        IEnumerable<Judge> judges = await _judgeRepository.GetJudgesFromFirstName(firstName);
        GetAllJudgesResponse getAllJudgesResponse = GetAllJudgesResponse.ConverFromJudges(judges);

        return getAllJudgesResponse.Judges.Count is 0
            ? NoContent()
            : Ok(getAllJudgesResponse);
    }

    [HttpGet("byLastName/{lastName}", Name = "GetJudgesFromLastName")]
    public async Task<IActionResult> GetJudgesFromLastName(string lastName)
    {
        IEnumerable<Judge> judges = await _judgeRepository.GetJudgesFromFirstName(lastName);
        GetAllJudgesResponse getAllJudgesResponse = GetAllJudgesResponse.ConverFromJudges(judges);

        return getAllJudgesResponse.IsEmpty()
            ? NoContent()
            : Ok(getAllJudgesResponse);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateJudge([FromBody] UpdateJudgeRequest updatedJudgeRequest)
    {
        if (updatedJudgeRequest is null) return BadRequest("ViewModel is null");
        Judge judge = updatedJudgeRequest.ConvertToJudge();

        await _judgeRepository.UpdateJudge(judge);

        UpdateJudgeResponse updateJudgeResponse = UpdateJudgeResponse.ConvertToJudgeCourseResponse(judge);
        return Ok(updateJudgeResponse);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteJudge(int judgeId)
    {
        if (judgeId <= 0) return BadRequest("JudgeId must be larger than zero");

        await _judgeRepository.DeleteJudge(judgeId);

        return Ok();
    }
}
