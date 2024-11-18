using Domain.UserHistorial.Model.Commands;

namespace Domain.UserHistorial.Services;

public interface IHistoryCommandService
{
    Task<long> Handle(CreateHistoryCommand command);
    Task<bool> Handle(DeleteHistoryCommand command);
}