namespace Domain.IAM.Model.Commands;

public record SingUpCommand(
    string email, 
    string password, 
    string completeName, 
    string phone, 
    string dni, 
    string photo, 
    string address, 
    string rol);
    