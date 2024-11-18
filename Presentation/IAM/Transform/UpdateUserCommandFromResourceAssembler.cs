using Domain.IAM.Model.Commands;
using Presentation.IAM.Resources;

namespace Presentation.IAM.Transform;

public class UpdateUserCommandFromResourceAssembler
{
    public static UpdateUserCommand ToCommandFromResource(int id, UpdateUserResource resource)
    {
        return new UpdateUserCommand(id, resource.email,
            resource.password, resource.completeName, resource.phone,
            resource.dni, resource.photo, resource.address);
    }
}