using System.Net.Mime;
using Domain.Suscription.Model.Queries;
using Domain.Suscription.Services;
using Domain.Suscription.Model.Commands;
using Microsoft.AspNetCore.Mvc;
using Presentation.Suscription.Resources;
using Presentation.Suscription.Transform;

namespace Presentation.Suscription.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class SuscriptionController (ISuscriptionQueryService suscriptionQueryService, 
    ISuscriptionCommandService suscriptionCommandService): ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllSuscriptions()
    {
        var query = new GetAllSuscriptionsQuery();
        var suscription = await suscriptionQueryService.Handle(query);
        var suscriptionResource = suscription.Select(SuscriptionResourceFromEntityAssembler.ToResourceFromEntity);
        return StatusCode(200, suscriptionResource);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetSuscriptionById(int id)
    {
        var query = new GetSuscriptionByIdQuery(id);
        var suscription = await suscriptionQueryService.Handle(query);
        var suscriptionResource = SuscriptionResourceFromEntityAssembler.ToResourceFromEntity(suscription);
        if (suscriptionResource == null)
        {
            return StatusCode(404, "Suscription not found");
        }
        return StatusCode(200, suscriptionResource);
    }
    
}