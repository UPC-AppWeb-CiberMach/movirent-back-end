using System.Net.Mime;
using Domain.Renting.Model.Queries;
using Domain.Renting.Services;
using Domain.Scooter.Model.Commands;
using Microsoft.AspNetCore.Mvc;
using Presentation.Renting.Resources;
using Presentation.Renting.Transform;

namespace Presentation.Renting.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ScooterController (IScooterQueryService scooterQueryService, 
    IScooterCommandService scooterCommandService): ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllScooters()
    {
        var query = new GetAllScootersQuery();
        var scooters = await scooterQueryService.Handle(query);
        var scootersResource = scooters.Select(ScooterResourceFromEntityAssembler.ToResourceFromEntity);
        return StatusCode(200, scootersResource);
    }

    [HttpPost]
    public async Task<IActionResult> CreateScooter([FromBody] CreateScooterResource scooterResource)
    {
        if (scooterResource == null)
        {
            return BadRequest("El recurso no puede ser nulo.");
        }

        if (string.IsNullOrWhiteSpace(scooterResource.Model) || 
            string.IsNullOrWhiteSpace(scooterResource.Brand) ||
            scooterResource.PricePerHour <= 0)
        {
            return BadRequest("Los campos obligatorios deben tener valores válidos.");
        }

        var command = CreateScooterCommandFromResourceAssembler.ToCommandFromResource(scooterResource);
        var scooterId = await scooterCommandService.Handle(command);
        return StatusCode(201, scooterId);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetScooterById(int id)
    {
        if (id <= 0)
        {
            return BadRequest("El ID debe ser un número positivo.");
        }

        var query = new GetScooterByIdQuery(id);
        var scooter = await scooterQueryService.Handle(query);
        if (scooter == null)
        {
            return NotFound("Scooter no encontrado.");
        }

        var scooterResource = ScooterResourceFromEntityAssembler.ToResourceFromEntity(scooter);
        return StatusCode(200, scooterResource);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateScooter(int id, [FromBody] UpdateScooterResource scooterResource)
    {
        if (id <= 0)
        {
            return BadRequest("El ID debe ser un número positivo.");
        }

        if (scooterResource == null)
        {
            return BadRequest("El recurso no puede ser nulo.");
        }

        var command = UpdateScooterCommandFromResourceAssembler.ToCommandFromResource(id, scooterResource);
        await scooterCommandService.Handle(command);
        return StatusCode(200, "Scooter actualizado con éxito.");
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteScooter(int id)
    {
        if (id <= 0)
        {
            return BadRequest("El ID debe ser un número positivo.");
        }

        var command = new DeleteScooterCommand(id);
        await scooterCommandService.Handle(command);
        return StatusCode(200, "Scooter eliminado con éxito.");
    }
}