namespace Domain.Review.Model.Commands;

public record CreateReviewCommand(string Name, string Brand, string Model, string Image, double PricePerHour, string District, string Phone);