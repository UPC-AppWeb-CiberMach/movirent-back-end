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
            var historialsAux = await historialQueryService.Handle(query);
            if (historialsAux == null || !historialsAux.Any())
            {
                return NotFound("No se encontraron registros de historial.");
            }

            var resources = historialsAux
                .Select(HistorialResourceFromEntityAssembler.ToResourceFromEntity)
                .ToList();
            return Ok(resources);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno: {ex.Message}");
        }
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(HistorialEntity), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetById(int id)
    {
        if (id <= 0)
        {
            return BadRequest("El ID debe ser un número positivo.");
        }

        var query = new GetHistorialByIdQuery(id);
        var historial = await historialQueryService.Handle(query);
        if (historial == null)
            return NotFound("Historial no encontrado.");
        var resource = HistorialResourceFromEntityAssembler.ToResourceFromEntity(historial);
        return Ok(resource);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] CreateHistorialResource createHistorialResource)
    {
        if (createHistorialResource == null)
        {
            return BadRequest("El recurso de historial no puede ser nulo.");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest("Datos del recurso no válidos.");
        }

        var command = CreateHistorialCommandFromResourceAssembler.ToCommandFromResource(createHistorialResource);
        try
        {
            var result = await historialCommandService.Handle(command);
            return CreatedAtAction(nameof(GetById), new { id = result }, new { data = result });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al crear el historial: {ex.Message}");
        }
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(int id)
    {
        if (id <= 0)
        {
            return BadRequest("El ID debe ser un número positivo.");
        }

        var command = new DeleteHistorialCommand(id);
        try
        {
            var result = await historialCommandService.Handle(command);
            return result ? NoContent() : NotFound("Historial no encontrado para eliminar.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al eliminar el historial: {ex.Message}");
        }
    }
}
