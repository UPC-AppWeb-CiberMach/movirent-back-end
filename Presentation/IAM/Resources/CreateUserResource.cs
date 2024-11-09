namespace Presentation.IAM.Resources;

public record CreateUserResource(string email, string password, string completeName, string phone, string dni, string photo, string address);

