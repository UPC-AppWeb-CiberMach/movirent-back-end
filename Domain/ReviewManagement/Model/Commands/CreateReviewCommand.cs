namespace Domain.Review.Model.Commands;

public record CreateReviewCommand(string Comment, int StarNumb);