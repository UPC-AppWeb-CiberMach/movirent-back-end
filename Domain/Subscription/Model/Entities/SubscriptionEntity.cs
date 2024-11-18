
using Domain.Subscription.Model.Commands;

namespace Domain.Subscription.Model.Entities;
public partial class SubscriptionEntity 
{
    public int Id { get; }
    
    private string _name;
    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 50)
                throw new ArgumentException("El nombre no puede estar vacío y debe tener menos de 50 caracteres.");
            _name = value;
        }
    }

    private string _description;
    public string Description
    {
        get => _description;
        set
        {
            if (value.Length > 200)
                throw new ArgumentException("La descripción debe tener menos de 200 caracteres.");
            _description = value;
        }
    }

    private int _stars;
    public int Stars
    {
        get => _stars;
        set
        {
            if (value < 1 || value > 5)
                throw new ArgumentException("Las estrellas deben estar entre 1 y 5.");
            _stars = value;
        }
    }

    private double _price;
    public double Price
    {
        get => _price;
        set
        {
            if (value <= 0)
                throw new ArgumentException("El precio debe ser mayor a 0.");
            _price = value;
        }
    }
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
        Stars = 1; // Valor mínimo válido por defecto
        Price = 1; // Valor mínimo válido por defecto
    }
}
