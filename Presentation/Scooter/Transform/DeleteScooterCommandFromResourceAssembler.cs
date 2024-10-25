using Domain.Scooter.Model.Commands;
using Presentation.Scooter.Resources;

namespace Presentation.Scooter.Transform;

public class DeleteScooterCommandFromResourceAssembler
{
    public static DeleteScooterCommand ToCommandFromResource(DeleteScooterResource resource)
    {
        return new DeleteScooterCommand(resource.Id);
    }
}