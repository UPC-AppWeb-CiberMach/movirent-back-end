using Domain.IAM.Model.Commands;
using Presentation.IAM.Resources;

namespace Presentation.IAM.Transform;

public static class CreateUserCommandFromResourceAssembler
{
    public static CreateUserCommand ToCommandFromResource(CreateUserResource resource)
    {
        if (string.IsNullOrWhiteSpace(resource.email) || 
            string.IsNullOrWhiteSpace(resource.password) || 
            string.IsNullOrWhiteSpace(resource.completeName) || 
            string.IsNullOrWhiteSpace(resource.phone) || 
            string.IsNullOrWhiteSpace(resource.dni) || 
            string.IsNullOrWhiteSpace(resource.address))
        {
            throw new ArgumentException("Todos los campos obligatorios deben estar llenos.");
        }

        if (resource.password.Length < 8)
        {
            throw new ArgumentException("La contraseña debe tener al menos 8 caracteres.");
        }

        return new CreateUserCommand(resource.email,
            resource.password, resource.completeName, resource.phone,
            resource.dni, resource.photo, resource.address);
    }
}