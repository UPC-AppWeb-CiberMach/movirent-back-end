using Domain.Subscription.Model.Entities;
using Domain.Subscription.Model.Queries;

namespace Domain.Subscription.Services;

public interface ISubscriptionQueryService
{
    Task<IEnumerable<SubscriptionEntity>> Handle(GetAllSubscriptionsQuery query);
    Task<SubscriptionEntity?> Handle(GetSubscriptionByIdQuery query);
}