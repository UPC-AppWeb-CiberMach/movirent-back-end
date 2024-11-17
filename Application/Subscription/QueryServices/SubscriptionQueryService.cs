using Domain.Subscription.Model.Entities;
using Domain.Subscription.Model.Queries;
using Domain.Subscription.Repositories;
using Domain.Subscription.Services;

namespace Application.Subscription.QueryServices;

/// <summary>
/// Servicio de consultas de suscripciones
/// </summary>
public class SubscriptionQueryService : ISubscriptionQueryService
{
    private readonly ISubscriptionRepository _subscriptionRepository;

    public SubscriptionQueryService(ISubscriptionRepository subscriptionRepository)
    {
        _subscriptionRepository = subscriptionRepository;
    }
    

    public async Task<SubscriptionEntity?> Handle(GetSubscriptionByIdQuery query)
    {
        return await _subscriptionRepository.GetByIdAsync(query.Id);
    }

    public async Task<IEnumerable<SubscriptionEntity>> Handle(GetAllSubscriptionsQuery query)
    {
        return await _subscriptionRepository.GetAllAsync();
    }
}