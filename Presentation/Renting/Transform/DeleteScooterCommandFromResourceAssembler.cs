using Domain.Scooter.Model.Commands;
using Presentation.Renting.Resources;

namespace Presentation.Renting.Transform;

public class DeleteScooterCommandFromResourceAssembler
{
    public static DeleteScooterCommand ToCommandFromResource(DeleteScooterResource resource)
    {
        return new DeleteScooterCommand(resource.Id);
    }
}