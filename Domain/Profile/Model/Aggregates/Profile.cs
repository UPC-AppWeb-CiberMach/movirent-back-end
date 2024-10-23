using Domain.Profile.Model.Commands;

namespace Domain.Profile.Model.Aggregates;
//completeName, dni, age, phone, email, password, role, photo, address
public partial class Profile
{
    public int Id { get; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Dni { get; set; }
    public int Age { get; set; }
    public int Phone { get; set; }
    public string Address { get; set; }
}

public partial class Profile
{
    public Profile()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Dni = string.Empty;
        Address = string.Empty;
        Age = 0;
        Phone = 0;
    }

    public Profile(CreateProfileCommand command)
    {
        FirstName = command.FirstName;
        LastName = command.LastName;
        Dni = command.Dni;
        Age = command.Age;
        Phone = command.Phone;
        Address = command.Address;
    }
}
//scooter