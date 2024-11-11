using System.Data;
using Domain.UserHistorial.Model.Commands;
using Domain.UserHistorial.Model.Entities;
using Domain.UserHistorial.Repositories;
using Domain.UserHistorial.Services;
using Domain.Shared;

namespace Application.UserHistorial.CommandServices;

public class HistorialCommandService : IHistorialCommandService
{
    private readonly IHistorialRepository _historialRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public HistorialCommandService(IHistorialRepository historialRepository, IUnitOfWork unitOfWork)
    {
        _historialRepository = historialRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateHistorialCommand command)
    {
        var userHaveActiveHistorial = await _historialRepository.CheckUserActiveHistorialAsync(command.UserId);
        if(userHaveActiveHistorial != null) throw new DuplicateNameException("User already have active reservation");
        //Fix: Add check for scooter availability
        var vehicleIsReserved = await _historialRepository.CheckScooterAvailableAsync(command.ScooterId);
        if(vehicleIsReserved != null) throw new DuplicateNameException("Scooter is already reserved");
        var reservation = new HistorialEntity
        {
            ScooterId = command.ScooterId,
            UserId = command.UserId,
            StartTime = command.StartTime,
            EndTime = command.EndTime,
            Price = command.Price,
            Time = command.Time
        };

        await _historialRepository.AddAsync(reservation);
        await _unitOfWork.CompleteAsync();
        return reservation.Id;
    }

    public async Task<bool> Handle(DeleteHistorialCommand command)
    {
        var reserve = await _historialRepository.GetByIdAsync(command.Id);
        await _historialRepository.RemoveAsync(reserve);
        await _unitOfWork.CompleteAsync();
        return true;
    }
}