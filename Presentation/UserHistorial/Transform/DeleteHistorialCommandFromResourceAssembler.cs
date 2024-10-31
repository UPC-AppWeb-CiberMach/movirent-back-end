using Domain.Historial.Model.Commands;
using Presentation.Historial.Resources;

namespace Presentation.Historial.Transform;

public static class DeleteHistorialCommandFromResourceAssembler
{
    public static DeleteHistorialCommand ToCommandFromResource(DeleteHistorialResource resource)
    {
        return new DeleteHistorialCommand(resource.Id);
    }
}