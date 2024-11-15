using Domain.IAM.Model.Commands;
using Presentation.IAM.Resources;

namespace Presentation.IAM.Transform;

public class UpdateUserCommandFromResourceAssembler
{
    public static UpdateUserCommand ToCommandFromResource(int id, UpdateUserResource resource)
    {
        if (id <= 0)
        {
            throw new ArgumentException("El ID del usuario debe ser un número positivo.");
        }

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

        return new UpdateUserCommand(id, resource.email,
            resource.password, resource.completeName, resource.phone,
            resource.dni, resource.photo, resource.address);
    }
}