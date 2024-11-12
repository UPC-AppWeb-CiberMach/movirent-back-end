using Domain.UserHistorial.Model.Commands;
using Presentation.UserHistorial.Resources;

namespace Presentation.UserHistorial.Transform;

public static class CreateHistoryCommandFromResourceAssembler
{
    public static CreateHistoryCommand ToCommandFromResource(CreateHistoryResource resource)
    {
        return new CreateHistoryCommand(
            resource.ClientId,
            resource.ScooterId,
            resource.StartDate,
            resource.EndDate,
            resource.Price,
            resource.Time
        );
    }
}