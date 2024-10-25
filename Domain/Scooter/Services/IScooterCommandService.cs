using Domain.Scooter.Model.Commands;

namespace Domain.Scooter.Services;

public interface IScooterCommandService
{
    Task<int> Handle(CreateScooterCommand command);
    Task<bool> Handle(UpdateScooterCommand command);
    Task<bool> Handle(DeleteScooterCommand command);
}