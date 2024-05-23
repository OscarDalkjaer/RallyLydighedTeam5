﻿using API.ViewModels;
using BusinessLogic.Models;
using BusinessLogic.Services;
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
    public async Task <IActionResult> AddJudge([FromBody] AddJudgeRequestViewModel addJudgeRequestViewModel)
    {
       if (addJudgeRequestViewModel == null) return BadRequest("ViewModel was null");       
       
        Judge judge = new Judge(addJudgeRequestViewModel.FirstName, addJudgeRequestViewModel.LastName);
        await _judgeRepository.AddJudge(judge);

        AddJudgeResponseViewModel addJudgeResponseViewModel = new AddJudgeResponseViewModel(
            judge.FirstName,
            judge.LastName,
            judge.JudgeId
            );

        return Ok(addJudgeResponseViewModel);
    }


    [HttpGet("{judgeId}", Name = "GetJudge")]
    public async Task<IActionResult> GetJudge(int judgeId)
    {
        if (judgeId <= 0) return BadRequest("JudgeId must be larger than zero");

        Judge? judge = await _judgeRepository.GetJudge(judgeId);

        if (judge == null) return NotFound($"Judge with Id {judgeId} does not exist");

        GetJudgeViewModel viewModel = new GetJudgeViewModel(judge.JudgeId, judge.FirstName, judge.LastName);
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

    [HttpGet("byFirstName/{firstName}", Name = "GetJudgesFromFirstName")]
    public async Task<IActionResult> GetJudgesFromFirstName(string firstName) 
    {
        IEnumerable<Judge> judges = await _judgeRepository.GetJudgesFromFirstName(firstName);
        GetAllJudgesViewModel getAllJudgesViewModel = new GetAllJudgesViewModel(judges);

        return getAllJudgesViewModel.Judges.Count is 0
            ? NoContent()
            : Ok(getAllJudgesViewModel);
    }

    [HttpGet("byLastName/{lastName}", Name = "GetJudgesFromLastName")]
    public async Task<IActionResult> GetJudgesFromLastName(string lastName)
    {
        IEnumerable<Judge> judges = await _judgeRepository.GetJudgesFromFirstName(lastName);
        GetAllJudgesViewModel getAllJudgesViewModel = new GetAllJudgesViewModel(judges);

        return getAllJudgesViewModel.Judges.Count is 0
            ? NoContent()
            : Ok(getAllJudgesViewModel);
    }



    [HttpPut]
    public async Task<IActionResult> UpdateJudge([FromBody]UpdateJudgeRequestViewModel updatedJudgeRequestViewModel)
    {
        if (updatedJudgeRequestViewModel is null) return BadRequest("ViewModel is null");

        Judge judge = new Judge(
            firstName: updatedJudgeRequestViewModel.FirstName,
            lastName: updatedJudgeRequestViewModel.LastName,
            judgeId: updatedJudgeRequestViewModel.UpdatedJudgeId);
        await _judgeRepository.UpdateJudge(judge);

        UpdateJudgeResponseViewModel updateJudgeResponseViewModel = new UpdateJudgeResponseViewModel(
            judge.FirstName,
            judge.LastName,
            judge.JudgeId);

        return Ok(updateJudgeResponseViewModel);
    }


    [HttpDelete]
    public async Task <IActionResult> DeleteJudge(int judgeId)
    {
        if (judgeId <= 0) return BadRequest("JudgeId must be larger than zero");

        await _judgeRepository.DeleteJudge(judgeId);

        return Ok();
    }
}
