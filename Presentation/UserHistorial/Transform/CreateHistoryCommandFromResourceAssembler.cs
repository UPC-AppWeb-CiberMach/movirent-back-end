using Domain.UserHistorial.Model.Commands;
using Presentation.UserHistorial.Resources;

namespace Presentation.UserHistorial.Transform;

public static class CreateHistoryCommandFromResourceAssembler
{
    public static CreateHistoryCommand ToCommandFromResource(CreateHistoryResource resource)
    {
        return new CreateHistoryCommand(
            resource.UserId,
            resource.ScooterId,
            resource.StartTime,
            resource.EndTime,
            resource.Price,
            resource.Time
        );
    }
}