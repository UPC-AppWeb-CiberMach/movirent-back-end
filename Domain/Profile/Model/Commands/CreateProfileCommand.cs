namespace Domain.Profile.Model.Commands;

public record CreateProfileCommand(string FirstName, string LastName, string Dni, int Age, int Phone, string Address);

// Scooter Management