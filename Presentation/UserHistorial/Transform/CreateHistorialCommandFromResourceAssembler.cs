using Domain.UserHistorial.Model.Commands;
using Presentation.UserHistorial.Resources;

namespace Presentation.UserHistorial.Transform;

public static class CreateHistorialCommandFromResourceAssembler
{
    public static CreateHistorialCommand ToCommandFromResource(CreateHistorialResource resource)
    {
        return new CreateHistorialCommand(
            resource.UserId,
            resource.ScooterId,
            resource.StartTime,
            resource.EndTime,
            resource.Price,
            resource.Time);
    }
}