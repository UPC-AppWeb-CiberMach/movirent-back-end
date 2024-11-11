using Domain.UserHistorial.Model.Commands;
using Presentation.UserHistorial.Resources;

namespace Presentation.UserHistorial.Transform;

public static class DeleteHistorialCommandFromResourceAssembler
{
    public static DeleteHistorialCommand ToCommandFromResource(DeleteHistorialResource resource)
    {
        return new DeleteHistorialCommand(resource.Id);
    }
}