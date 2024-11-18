using Domain.UserHistorial.Model.Commands;
using Presentation.UserHistorial.Resources;

namespace Presentation.UserHistorial.Transform;

public static class DeleteHistoryCommandFromResourceAssembler
{
    public static DeleteHistoryCommand ToCommandFromResource(DeleteHistoryResource resource)
    {
        return new DeleteHistoryCommand(resource.Id);
    }
}