using System.Data;
using Domain.Historial.Model.Commands;
using Domain.Historial.Model.Entities;
using Domain.Historial.Repositories;
using Domain.Historial.Services;
using Domain.Shared;

namespace Application.Historial.CommandServices;

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
            EndTime = command.EndTime
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