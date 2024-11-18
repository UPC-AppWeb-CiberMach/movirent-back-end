using System.Net.Mime;
using Domain.Renting.Model.Queries;
using Domain.Renting.Services;
using Domain.Scooter.Model.Commands;
using Microsoft.AspNetCore.Mvc;
using Presentation.Renting.Resources;
using Presentation.Renting.Transform;

namespace Presentation.Renting.Controllers;

/// <summary>
/// Gets all Scooter
/// </summary>
/// <param name="ScooterQueryService"></param>
/// <param name="ScooterCommandService"></param>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ScooterController (IScooterQueryService scooterQueryService, 
    IScooterCommandService scooterCommandService): ControllerBase
{
    /// <summary>
    /// Get all Scooters
    /// </summary>
    /// <returns>Returns a list of Scooter</returns>
    /// <response code="200">successful return</response>
    /// <response code="404">No found</response>
    /// <response code="500">An error occurred on the server</response>
    [HttpGet]
    public async Task<IActionResult> GetAllScooters()
    {
        var query = new GetAllScootersQuery();
        var scooters = await scooterQueryService.Handle(query);
        var scootersResource = scooters.Select(ScooterResourceFromEntityAssembler.ToResourceFromEntity);
        return StatusCode(200, scootersResource);
    }
    
    /// <summary>
    /// Creates a new Scooter
    /// </summary>
    /// <returns>Returns new created Scooter.</returns>
    /// <response code="200">successful return</response>
    /// <response code="404">No found</response>
    /// <response code="500">An error occurred on the server</response>
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
    
    /// <summary>
    /// Gets a Scooter By Id
    /// </summary>
    /// <returns>Returns the Scooter if found by ID.</returns>
    /// <response code="200">successful return</response>
    /// <response code="404">No found</response>
    /// <response code="500">An error occurred on the server</response>
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
    
    /// <summary>
    /// Updates an existing Scooter by ID.
    /// </summary>
    /// <response code="200">successful return</response>
    /// <response code="404">No found</response>
    /// <response code="500">An error occurred on the server</response>
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateScooter(int id, [FromBody] UpdateScooterResource scooterResource)
    {
        var command = UpdateScooterCommandFromResourceAssembler.ToCommandFromResource(id, scooterResource);
        await scooterCommandService.Handle(command);
        return StatusCode(200, "Renting updated");
    }
    
    /// <summary>
    /// Deletes a Scooter by ID.
    /// </summary>
    /// <response code="200">successful return</response>
    /// <response code="404">No found</response>
    /// <response code="500">An error occurred on the server</response>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteScooter(int id)
    {
        var command = new DeleteScooterCommand(id);
        await scooterCommandService.Handle(command);
        return StatusCode(200,"Renting deleted");
    }
}