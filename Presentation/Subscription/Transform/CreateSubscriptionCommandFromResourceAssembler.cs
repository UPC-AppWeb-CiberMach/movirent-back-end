using Domain.Subscription.Model.Commands;
using Presentation.Subscription.Resources;

namespace Presentation.Subscription.Transform;

public static class CreateSubscriptionCommandFromResourceAssembler
{
    public static CreateSubscriptionCommand ToCommandFromResource(CreateSubscriptionResource resource)
    {
        return new CreateSubscriptionCommand( resource.Name,
            resource.Description, resource.Stars, resource.Price);
    }
    
    
}