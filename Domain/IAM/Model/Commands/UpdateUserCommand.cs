namespace Domain.IAM.Model.Commands;

public record UpdateUserCommand(int id, string email, string password, string completeName, string phone, string dni, string photo, string address);
