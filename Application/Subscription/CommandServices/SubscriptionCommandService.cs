using Domain.Subscription.Model.Commands;
using Domain.Subscription.Model.Entities;
using Domain.Subscription.Repositories;
using Domain.Subscription.Services;
using Domain.Shared;

namespace Application.Subscription.CommandServices;

public class SubscriptionCommandService : ISubscriptionCommandService
{
    private readonly ISubscriptionRepository _subscriptionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SubscriptionCommandService(ISubscriptionRepository subscriptionRepository, IUnitOfWork unitOfWork)
    {
        _subscriptionRepository = subscriptionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateSubscriptionCommand command)
    {
        var subscription = new SubscriptionEntity(command);
        
        await _subscriptionRepository.AddAsync(subscription);
        await _unitOfWork.CompleteAsync();
        return subscription.Id;
    }
    
}