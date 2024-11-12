using Domain.IAM.Model.Commands;
using Presentation.IAM.Resources;

namespace Presentation.IAM.Transform;

public class DeleteUserCommandFromResourceAssembler
{
    public static DeleteUserCommand ToCommandFromResource(DeleteUserResource resource)
    {
        return new DeleteUserCommand(resource.id);
    }
}