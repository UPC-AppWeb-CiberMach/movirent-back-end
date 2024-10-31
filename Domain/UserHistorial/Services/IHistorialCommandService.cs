using Domain.UserHistorial.Model.Commands;

namespace Domain.UserHistorial.Services;

public interface IHistorialCommandService
{
    Task<int> Handle(CreateHistorialCommand command);
    Task<bool> Handle(DeleteHistorialCommand command);
}