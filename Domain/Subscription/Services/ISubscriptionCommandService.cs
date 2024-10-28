using Domain.Subscription.Model.Commands;

namespace Domain.Subscription.Services;

public interface ISubscriptionCommandService
{
    Task<int> Handle(CreateSubscriptionCommand command);
}