namespace Domain.Scooter.Model.Commands;

public record UpdateScooterCommand(int Id, string Name, string Brand, string Model, string Image, double PricePerHour, string District, string Phone);