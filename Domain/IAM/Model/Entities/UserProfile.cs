using Domain.IAM.Model.Commands;
using Domain.Profile.Model.Commands;

namespace Domain.IAM.Model.Entities;

public partial class UserProfile
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string CompleteName { get; set; }
    public string Phone { get; set; }
    public string Dni { get; set; }
    public string Photo { get; set; }
    public string Address { get; set; }
    public string Rol { get; set; }
    
    public UserProfile(SingUpCommand command)
    {
        Email = command.email;
        Password = command.password;
        CompleteName = command.completeName;
        Phone = command.phone;
        Dni = command.dni;
        Photo = command.photo;
        Address = command.address;
        Rol = command.rol;
    }
    
    public UserProfile() 
    {
        Email = string.Empty; 
        Password = string.Empty;
        CompleteName = string.Empty;
        Phone = string.Empty;
        Dni = string.Empty;
        Photo = string.Empty;
        Address = string.Empty;
    }
    
    public void UpdateUserInfo(UpdateUserCommand command)
    {
        Email = command.email;
        Password = command.password;
        CompleteName = command.completeName;
        Phone = command.phone;
        Dni = command.dni;
        Photo = command.photo;
        Address = command.address;
    }
}

