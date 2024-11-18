using Domain.UserHistorial.Model.Commands;
using Domain.UserHistorial.Model.Entities;
using Domain.UserHistorial.Model.Queries;
using Domain.UserHistorial.Services;
using Presentation.UserHistorial.Resources;
using Presentation.UserHistorial.Transform;

namespace Presentation.UserHistorial.Controllers;
using Microsoft.AspNetCore.Mvc;


[Route("api/v1/[controller]")]
[ApiController]
public class HistoryController(
    IHistoryQueryService historyQueryService,
    IHistoryCommandService historyCommandService): ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<HistoryEntity>), 200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    [Produces("application/json")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var query = new GetAllHistoryQuery();
            var result = await historyQueryService.Handle(query);
            if (result == null || !result.Any())
            {
                return NotFound();
            }

            var resources = result
                .Select(HistoryResourceFromEntityAssembler.ToResourceFromEntity)
                .ToList();
            return Ok(resources);
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }

    [HttpGet("{id:long}")]
    [ProducesResponseType(typeof(HistoryEntity), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(long id)
    {
        var query = new GetHistoryByIdQuery(id);
        var result = await historyQueryService.Handle(query);
        if (result == null)
        {
            return NotFound();
        }
        var resource = HistoryResourceFromEntityAssembler.ToResourceFromEntity;
        return Ok(resource);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] CreateHistoryResource createHistoryResource)
    {
        if (!ModelState.IsValid) return BadRequest("Invalid resource data. ");
        var command = CreateHistoryCommandFromResourceAssembler.ToCommandFromResource(createHistoryResource);
        var result = await historyCommandService.Handle(command);

        return CreatedAtAction(nameof(GetById), new { id = result }, new { data = result });
    }

    [HttpPut("{id:long}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(long id)
    {
        var command = new DeleteHistoryCommand(id);
        var result = await historyCommandService.Handle(command);
        return result ? NoContent() : NotFound();
    }
}