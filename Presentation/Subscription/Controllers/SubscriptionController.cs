using System.Net.Mime;
using Domain.Subscription.Model.Queries;
using Domain.Subscription.Services;
using Microsoft.AspNetCore.Mvc;
using Presentation.Subscription.Resources;
using Presentation.Subscription.Transform;

namespace Presentation.Subscription.Controllers;

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
        if(!ModelState.IsValid)
        {
            return StatusCode(400, "Invalid data");
        }
        var command = CreateSubscriptionCommandFromResourceAssembler.ToCommandFromResource(subscriptionResource);
        var subscriptionId = await subscriptionCommandService.Handle(command);
        return StatusCode(201, subscriptionId);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetSubscriptionById(int id)
    {
        var query = new GetSubscriptionByIdQuery(id);
        var subscription = await subscriptionQueryService.Handle(query);
        var subscriptionResource = SubscriptionResourceFromEntityAssembler.ToResourceFromEntity(subscription);
        if (subscriptionResource == null)
        {
            return StatusCode(404, "Renting not found");
        }
        return StatusCode(200, subscriptionResource);
    }
    
}