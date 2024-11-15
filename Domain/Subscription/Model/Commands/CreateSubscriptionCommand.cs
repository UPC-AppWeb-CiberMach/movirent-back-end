namespace Domain.Subscription.Model.Commands;

public record CreateSubscriptionCommand
{
    public string Name { get; }
    public string Description { get; }
    public int Stars { get; }
    public double Price { get; }

    public CreateSubscriptionCommand(string name, string description, int stars, double price)
    {
        // Validación para Name
        if (string.IsNullOrWhiteSpace(name) || name.Length > 50)
        {
            throw new ArgumentException("El nombre de la suscripción no puede estar vacío y debe tener menos de 50 caracteres.");
        }
        Name = name;

        // Validación para Description
        if (description.Length > 200)
        {
            throw new ArgumentException("La descripción debe tener menos de 200 caracteres.");
        }
        Description = description;

        // Validación para Stars
        if (stars < 1 || stars > 5)
        {
            throw new ArgumentException("La cantidad de estrellas debe estar entre 1 y 5.");
        }
        Stars = stars;

        // Validación para Price
        if (price <= 0)
        {
            throw new ArgumentException("El precio debe ser mayor a 0.");
        }
        Price = price;
    }
}