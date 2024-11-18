using System.Net.Mime;
using Domain.Subscription.Model.Queries;
using Domain.Subscription.Services;
using Microsoft.AspNetCore.Mvc;
using Presentation.Subscription.Resources;
using Presentation.Subscription.Transform;

namespace Presentation.Subscription.Controllers;
/// <summary>
/// Controlador de suscripciones
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class SubscriptionController (ISubscriptionQueryService subscriptionQueryService, 
    ISubscriptionCommandService subscriptionCommandService): ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllSubscriptions()
    {
        var query = new GetAllSubscriptionsQuery();
        var subscriptions = await subscriptionQueryService.Handle(query);
        var subscriptionsResource = subscriptions.Select(SubscriptionResourceFromEntityAssembler.ToResourceFromEntity);
        return StatusCode(200, subscriptionsResource);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateSubscription([FromBody] CreateSubscriptionResource subscriptionResource)
    {
        // Validar que el recurso no sea nulo
        if (subscriptionResource == null)
        {
            return BadRequest("El recurso de suscripción no puede ser nulo.");
        }

        // Validar los campos individuales
        if (string.IsNullOrWhiteSpace(subscriptionResource.Name))
        {
            return BadRequest("El nombre de la suscripción es obligatorio.");
        }
        
        if (subscriptionResource.Stars < 1 || subscriptionResource.Stars > 5)
        {
            return BadRequest("La cantidad de estrellas debe estar entre 1 y 5.");
        }

        if (subscriptionResource.Price <= 0)
        {
            return BadRequest("El precio debe ser mayor a 0.");
        }

        var command = CreateSubscriptionCommandFromResourceAssembler.ToCommandFromResource(subscriptionResource);
        var subscriptionId = await subscriptionCommandService.Handle(command);
        return StatusCode(201, subscriptionId);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetSubscriptionById(int id)
    {
        // Validar que el ID sea válido
        if (id <= 0)
        {
            return BadRequest("El ID debe ser un número positivo.");
        }

        var query = new GetSubscriptionByIdQuery(id);
        var subscription = await subscriptionQueryService.Handle(query);
        if (subscription == null)
        {
            return NotFound("Suscripción no encontrada.");
        }

        var subscriptionResource = SubscriptionResourceFromEntityAssembler.ToResourceFromEntity(subscription);
        return StatusCode(200, subscriptionResource);
    }
}