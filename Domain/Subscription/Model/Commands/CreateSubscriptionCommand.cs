namespace Domain.Subscription.Model.Commands;

public record CreateSubscriptionCommand(string Name, string Description, int Stars, double Price);