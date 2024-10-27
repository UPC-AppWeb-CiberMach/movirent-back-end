namespace Domain.Suscription.Model.Commands;

public record CreateSuscriptionCommand(string Name, string Brand, string Model, string Image, double PricePerHour, string District, string Phone);