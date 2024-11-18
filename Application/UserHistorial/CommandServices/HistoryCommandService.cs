using System.Data;
using Domain.UserHistorial.Model.Commands;
using Domain.UserHistorial.Model.Entities;
using Domain.UserHistorial.Repositories;
using Domain.UserHistorial.Services;
using Domain.Shared;

namespace Application.UserHistorial.CommandServices;

public class HistoryCommandService(IHistoryRepository historyRepository, IUnitOfWork unitOfWork)
    : IHistoryCommandService
{
    public async Task<long> Handle(CreateHistoryCommand command)
    {
        var existClient = await historyRepository.ExistByClientIdAsync(command.ClientId);
        if(existClient == false) throw new DuplicateNameException("User does not exist");

        var existScooter = await historyRepository.ExistByScooterIdAsync(command.ScooterId);
        if(existScooter == false) throw new DuplicateNameException("Scooter does not exist");

        var reservation = new HistoryEntity
        {
            ClientId = command.ClientId,
            ScooterId = command.ScooterId,
            StartDate = command.StartDate,
            EndDate = command.EndDate,
            Price = command.Price,
            Time = command.Time
        };

        await historyRepository.AddAsync(reservation);
        await unitOfWork.CompleteAsync();
        return reservation.Id;
    }

    public async Task<bool> Handle(DeleteHistoryCommand command)
    {
        var reserve = await historyRepository.GetByLongIdAsync(command.Id);
        if(reserve == null) throw new DataException("Reservation not found");
        await historyRepository.RemoveAsync(reserve);
        await unitOfWork.CompleteAsync();
        return true;
    }
}