using System.ComponentModel.DataAnnotations;
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
        if (string.IsNullOrWhiteSpace(command.email))
        {
            throw new ArgumentException("El correo electrónico es obligatorio.");
        }

        if (!new EmailAddressAttribute().IsValid(command.email))
        {
            throw new ArgumentException("El formato del correo electrónico es inválido.");
        }

        if (string.IsNullOrWhiteSpace(command.password) || command.password.Length < 8)
        {
            throw new ArgumentException("La contraseña debe tener al menos 8 caracteres.");
        }

        if (string.IsNullOrWhiteSpace(command.completeName))
        {
            throw new ArgumentException("El nombre completo es obligatorio.");
        }

        if (string.IsNullOrWhiteSpace(command.phone))
        {
            throw new ArgumentException("El teléfono es obligatorio.");
        }

        if (command.dni.Length != 8)
        {
            throw new ArgumentException("El DNI debe tener exactamente 8 caracteres.");
        }

        if (string.IsNullOrWhiteSpace(command.address))
        {
            throw new ArgumentException("La dirección es obligatoria.");
        }

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
        if (string.IsNullOrWhiteSpace(command.email))
        {
            throw new ArgumentException("El correo electrónico es obligatorio.");
        }

        if (!new EmailAddressAttribute().IsValid(command.email))
        {
            throw new ArgumentException("El formato del correo electrónico es inválido.");
        }

        if (string.IsNullOrWhiteSpace(command.password) || command.password.Length < 8)
        {
            throw new ArgumentException("La contraseña debe tener al menos 8 caracteres.");
        }

        if (string.IsNullOrWhiteSpace(command.completeName))
        {
            throw new ArgumentException("El nombre completo es obligatorio.");
        }

        if (string.IsNullOrWhiteSpace(command.phone))
        {
            throw new ArgumentException("El teléfono es obligatorio.");
        }

        if (command.dni.Length != 8)
        {
            throw new ArgumentException("El DNI debe tener exactamente 8 caracteres.");
        }

        if (string.IsNullOrWhiteSpace(command.address))
        {
            throw new ArgumentException("La dirección es obligatoria.");
        }
    }
}
