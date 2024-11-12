using Domain.IAM.Model.Commands;
using Domain.Profile.Model.Commands;

namespace Domain.IAM.Model.Entities;

public partial class UserProfile
{
    public int id { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string completeName { get; set; }
    public string phone { get; set; }
    public string dni { get; set; }
    public string photo { get; set; }
    public string address { get; set; }
    
    public UserProfile(CreateUserCommand command)
    {
        email = command.email;
        password = command.password;
        completeName = command.completeName;
        phone = command.phone;
        dni = command.dni;
        photo = command.photo;
        address = command.address;
    }
    
    public UserProfile() 
    {
        email = string.Empty; 
        password = string.Empty;
        completeName = string.Empty;
        phone = string.Empty;
        dni = string.Empty;
        photo = string.Empty;
        address = string.Empty;
    }
    
    public void UpdateUserInfo(UpdateUserCommand command)
    {
        email = command.email;
        password = command.password;
        completeName = command.completeName;
        phone = command.phone;
        dni = command.dni;
        photo = command.photo;
        address = command.address;
    }
}

