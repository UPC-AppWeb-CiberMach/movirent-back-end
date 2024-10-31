using Domain.Historial.Model.Commands;
using Domain.Historial.Model.Entities;
using Domain.Historial.Model.Queries;
using Domain.Historial.Services;
using Presentation.Historial.Resources;
using Presentation.Historial.Transform;

namespace Presentation.Historial.Controllers;
using Microsoft.AspNetCore.Mvc;


[Route("api/v1/[controller]")]
[ApiController]
public class HistoryController(
    IHistorialQueryService historialQueryService,
    IHistorialCommandService historialCommandService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<HistorialEntity>), 200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    [Produces("application/json")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var query = new GetAllHistorialsQuery();
            var historials = await historialQueryService.Handle(query);
            if (historials == null || !historials.Any())
            {
                return NotFound();
            }

            var resources = historials
                .Select(HistorialResourceFromEntityAssembler.ToResourceFromEntity)
                .ToList();
            return Ok(resources);
        }
        catch (Exception ex)
        {
            return StatusCode(500);
        }
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(HistorialEntity), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetHistorialByIdQuery(id);
        var historial = await historialQueryService.Handle(query);
        if (historial == null)
            return NotFound();
        var resource = HistorialResourceFromEntityAssembler.ToResourceFromEntity(historial);
        return Ok(resource);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] CreateHistorialResource createHistorialResource)
    {
        if (!ModelState.IsValid) return BadRequest("Invalid resource data.");
        var command = CreateHistorialCommandFromResourceAssembler.ToCommandFromResource(createHistorialResource);
        var result = await historialCommandService.Handle(command);

        return CreatedAtAction(nameof(GetById), new { id = result }, new { data = result });
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteHistorialCommand(id);
        var result = await historialCommandService.Handle(command);
        return result ? NoContent() : NotFound();
    }
    
}