using Domain.Historial.Model.Commands;
using Presentation.Historial.Resources;

namespace Presentation.Historial.Transform;

public static class CreateHistorialCommandFromResourceAssembler
{
    public static CreateHistorialCommand ToCommandFromResource(CreateHistorialResource resource)
    {
        return new CreateHistorialCommand(
            resource.UserId,
            resource.ScooterId,
            resource.StartTime,
            resource.EndTime);
    }
}