using Domain.Subscription.Model.Entities;
using Presentation.Subscription.Resources;

namespace Presentation.Subscription.Transform;

public class SubscriptionResourceFromEntityAssembler
{
    public static SubscriptionResource ToResourceFromEntity(SubscriptionEntity entity) =>
        new(entity.Id, entity.Name,
             entity.Description, entity.Stars, entity.Price);
}