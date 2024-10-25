namespace Presentation.Scooter.Resources;


public record CreateScooterResource(int Id, string Name, string Brand, string Model, double PricePerHour, string District, string Phone, string Image);