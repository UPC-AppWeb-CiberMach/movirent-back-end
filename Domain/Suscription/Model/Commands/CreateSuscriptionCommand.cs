namespace Domain.Suscription.Model.Commands;

public record CreateSuscriptionCommand(string Name, string Description, int Stars, double Price);