
using Domain.Subscription.Model.Commands;

namespace Domain.Subscription.Model.Entities;
public partial class SubscriptionEntity 
{
    public int Id { get; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Stars { get; set; }
    public double Price { get; set; }
    
}

public partial class SubscriptionEntity
{
    public SubscriptionEntity(CreateSubscriptionCommand command)
    {
        Name = command.Name;
        Description = command.Description;
        Stars = command.Stars;
        Price = command.Price;
    }

    public SubscriptionEntity()
    {
        Name = string.Empty;
        Description = string.Empty;
        Stars = 0;
        Price = 0;
    }
}

public partial class SubscriptionEntity
{
}


