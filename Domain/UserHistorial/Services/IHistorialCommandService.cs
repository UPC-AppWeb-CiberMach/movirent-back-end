using Domain.Historial.Model.Commands;

namespace Domain.Historial.Services;

public interface IHistorialCommandService
{
    Task<int> Handle(CreateHistorialCommand command);
    Task<bool> Handle(DeleteHistorialCommand command);
}