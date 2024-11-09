using ApiBackend.Core.src.Application.DTO;
using ApiBackend.Core.src.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiBackend.API.src.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PollsController : ControllerBase
{
    private readonly IPollService _pollService;

    public PollsController(IPollService pollService)
    {
        _pollService = pollService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PollDto>>> getPolls()
    {
        var polls = await _pollService.GetAllPollAsync();
        return Ok(polls);
    }

    [HttpPost]
    public async Task<ActionResult<PollDto>> CreatePoll([FromBody] CreatePollDto createPollDto)
    {
        var poll = await _pollService.CreatePollAsync(createPollDto);
        return CreatedAtAction(nameof(getPolls), new { id = poll.Id}, poll);
    }

}

