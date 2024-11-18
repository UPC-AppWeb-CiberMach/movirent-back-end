using Domain.UserHistorial.Model.Commands;
using Domain.UserHistorial.Model.Entities;
using Domain.UserHistorial.Model.Queries;
using Domain.UserHistorial.Services;
using Presentation.UserHistorial.Resources;
using Presentation.UserHistorial.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.UserHistorial.Controllers;


/// <summary>
/// Controlador de historial
/// </summary>
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
                return NotFound("No se encontraron registros de historial.");
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
            return BadRequest("El ID debe ser un número positivo.");
        }
        var resource = HistoryResourceFromEntityAssembler.ToResourceFromEntity;
        return Ok(resource);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] CreateHistoryResource createHistoryResource)
    {
        if (createHistoryResource == null)
        {
            return BadRequest("El recurso de historial no puede ser nulo.");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest("Datos del recurso no válidos.");
        }
        if (!ModelState.IsValid) return BadRequest("Invalid resource data. ");
        var command = CreateHistoryCommandFromResourceAssembler.ToCommandFromResource(createHistoryResource);
        try
        {
            var result = await historyCommandService.Handle(command);
            return CreatedAtAction(nameof(GetById), new { id = result }, new { data = result });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al crear el historial: {ex.Message}");
        }    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(int id)
    {
        if (id <= 0)
        {
            return BadRequest("El ID debe ser un número positivo.");
        }

        var command = new DeleteHistoryCommand(id);
        try
        {
            var result = await historyCommandService.Handle(command);
            return result ? NoContent() : NotFound("Historial no encontrado para eliminar.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al eliminar el historial: {ex.Message}");
        }
    }
}