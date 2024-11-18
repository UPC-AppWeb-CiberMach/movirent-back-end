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
        if(!ModelState.IsValid)
        {
            return StatusCode(400, "Invalid data");
        }
        var command = CreateScooterCommandFromResourceAssembler.ToCommandFromResource(scooterResource);
        var scooterId = await scooterCommandService.Handle(command);
        return StatusCode(201, scooterId);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetScooterById(int id)
    {
        var query = new GetScooterByIdQuery(id);
        var scooter = await scooterQueryService.Handle(query);
        var scooterResource = ScooterResourceFromEntityAssembler.ToResourceFromEntity(scooter);
        if (scooterResource == null)
        {
            return StatusCode(404, "Renting not found");
        }
        return StatusCode(200, scooterResource);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateScooter(int id, [FromBody] UpdateScooterResource scooterResource)
    {
        var command = UpdateScooterCommandFromResourceAssembler.ToCommandFromResource(id, scooterResource);
        await scooterCommandService.Handle(command);
        return StatusCode(200, "Renting updated");
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteScooter(int id)
    {
        var command = new DeleteScooterCommand(id);
        await scooterCommandService.Handle(command);
        return StatusCode(200,"Renting deleted");
    }
    
}