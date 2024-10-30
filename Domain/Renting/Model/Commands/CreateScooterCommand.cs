namespace Domain.Renting.Model.Commands;

public record CreateScooterCommand(string Name, string Brand, string Model, string Image, double PricePerHour, string District, string Phone);