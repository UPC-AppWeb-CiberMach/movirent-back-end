using Domain.Renting.Model.Commands;
using Domain.Subscription.Model.Commands;
using Domain.Subscription.Model.Entities;
using Domain.Subscription.Model.Queries;
using Domain.Subscription.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Presentation.Subscription.Controllers;
using Presentation.Subscription.Resources;
using Presentation.Subscription.Transform;

namespace PresentationTest.Subscription;

public class SubscriptionControllerTest
{
    [Fact]
    public void GetAllSubscriptionsMustToBeWorking()
    {
        var subscriptionQueryService = new Mock<ISubscriptionQueryService>();
        var subscriptionCommandService = new Mock<ISubscriptionCommandService>();
        var query = new GetAllSubscriptionsQuery();
        var subscriptions = subscriptionQueryService.Object.Handle(query).Result;
        var subscriptionEntities = subscriptions as SubscriptionEntity[] ?? subscriptions.ToArray();
        subscriptionQueryService.Setup(x => x.Handle(query)).ReturnsAsync(subscriptionEntities);
        var controller = new SubscriptionController(subscriptionQueryService.Object, subscriptionCommandService.Object);
        var result = controller.GetAllSubscriptions().Result as ObjectResult;
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        
    }

    [Fact]
    public void AddSubscriptionMustToBeWorking()
    {
        var subscriptionQueryService = new Mock<ISubscriptionQueryService>();
        var subscriptionCommandService = new Mock<ISubscriptionCommandService>();
        var controller = new SubscriptionController(subscriptionQueryService.Object, subscriptionCommandService.Object);
        var result = controller.CreateSubscription(new CreateSubscriptionResource(
            "Test", 
            "Test", 
            5, 
            5.5)
        ).Result as ObjectResult;
        Assert.NotNull(result);
        Assert.Equal(201, result.StatusCode);
    }

    [Fact]
    public void GetSubscriptionByIdMustToBeWorking()
    {
        var subscriptionQueryService = new Mock<ISubscriptionQueryService>();
        var subscriptionCommandService = new Mock<ISubscriptionCommandService>();
        var controller = new SubscriptionController(subscriptionQueryService.Object, subscriptionCommandService.Object);
        var command = new CreateSubscriptionCommand("Test", "Test", 5, 5.5);
        var subscriptionEntity = new SubscriptionEntity(command);
        subscriptionQueryService.Setup(x => x.Handle(new GetSubscriptionByIdQuery(1)))
            .ReturnsAsync(subscriptionEntity);
        var result = controller.GetSubscriptionById(1).Result as ObjectResult;
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        
    }
}