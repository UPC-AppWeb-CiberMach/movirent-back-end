
using Domain.IAM.Model.Commands;
using Presentation.IAM.Resources;

namespace Presentation.IAM.Transform;

public class DeleteUserCommandFromResourceAssembler
{
    public static DeleteUserCommand ToCommandFromResource(DeleteUserResource resource)
    {
        if (resource == null)
        {
            throw new ArgumentNullException(nameof(resource), "El recurso no puede ser nulo.");
        }

        if (resource.id <= 0)
        {
            throw new ArgumentException("El ID debe ser un número positivo.");
        }

        return new DeleteUserCommand(resource.id);
    }
}