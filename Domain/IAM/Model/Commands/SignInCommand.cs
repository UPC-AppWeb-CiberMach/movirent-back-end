namespace Domain.IAM.Model.Commands;

public record SignInCommand(string email, string Password);