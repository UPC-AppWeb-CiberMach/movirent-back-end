namespace Domain.IAM.Model.Commands;

public record CreateUserCommand(string email, string password, string
    completeName, string phone, string dni, string photo, string address);
    