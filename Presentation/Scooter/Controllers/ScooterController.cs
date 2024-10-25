using Application.Scooter.CommandServices;
using Application.Scooter.QueryServices;
using Domain.Scooter.Model.Commands;
using Domain.Scooter.Model.Queries;
using Microsoft.AspNetCore.Mvc;
using Presentation.Scooter.Resources;
using Presentation.Scooter.Transform;

namespace Presentation.Scooter.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ScooterController (ScooterQueryService scooterQueryService, 
    ScooterCommandService scooterCommandService): ControllerBase
{
    [HttpGet]

    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllScootersQuery();
        var scooters = await scooterQueryService.Handle(query);
        
        if (!scooters.Any()) 
            return NotFound();
        
        var resources = scooters.Select(ScooterResourceFromEntityAssembler.ToResourceFromEntity)
            .ToList();
        
        return Ok(resources);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetScooterByIdQuery(id);
        var tutorial = await scooterQueryService.Handle(query);

        if (tutorial == null)
            return NotFound();

        var resource = ScooterResourceFromEntityAssembler.ToResourceFromEntity(tutorial);

        return Ok(resource);
    }

    // POST: api/scooter
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateScooterResource createScooterResource)
    {
        if (createScooterResource == null)
            return BadRequest("Invalid resource data.");

        var command = CreateScooterCommandFromResourceAssembler
            .ToCommandFromResource(createScooterResource);

        var result = await scooterCommandService.Handle(command);

        return CreatedAtAction(nameof(GetById), new { id = result }, new { data = result });
    }

    // PUT: api/scooter/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateScooterResource updateScooterResource)
    {
        if (updateScooterResource == null)
            return BadRequest("Invalid resource data.");

        var command = UpdateScooterCommandFromResourceAssembler
            .ToCommandFromResource(id, updateScooterResource);

        var result = await scooterCommandService.Handle(command);

        return result ? NoContent() : NotFound();
    }

    // DELETE: api/scooter/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteScooterCommand(id);
        var result = await scooterCommandService.Handle(command);

        return result ? NoContent() : NotFound();
    }
    
}