using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestApiJobTitle.Common.Interfaces.Repositories;
using TestApiJobTitle.Common.Interfaces.Services;
using TestApiJobTitle.Common.Models;
using TestApiJobTitle.Common.Models.JobTitle;

namespace TestApiJobTitle.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class JobTitleController : ControllerBase
{
    private readonly IJobTitleService _jobTitleService;

    public JobTitleController(IJobTitleService jobTitleService)
    {
        _jobTitleService = jobTitleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PagingModel model)
    {
        var result = await _jobTitleService.GetJobTitlesAsync(model);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var result = await _jobTitleService.GetJobTitleByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] JobTitleCreateModel model)
    {
        var createdId = await _jobTitleService.CreateJobTitleAsync(model);

        return CreatedAtAction(nameof(GetById), routeValues: new {id = createdId}, createdId);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody] JobTitleUpdateModel model)
    {
        await _jobTitleService.UpdateJobTitleAsync(id, model);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await _jobTitleService.DeleteJobTitleAsync(id);
        
        return NoContent();
    }
}