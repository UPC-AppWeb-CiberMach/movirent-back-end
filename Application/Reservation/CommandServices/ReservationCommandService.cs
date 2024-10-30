using System.Data;
using Domain.Reservation.Model.Commands;
using Domain.Reservation.Model.Entities;
using Domain.Reservation.Repositories;
using Domain.Reservation.Services;
using Infrastructure.Shared.Persistence.EFC.Repositories.Interfaces;

namespace Application.Reservation.CommandServices;

public class ReservationCommandService : IReservationCommandService
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public ReservationCommandService(IReservationRepository reservationRepository, IUnitOfWork unitOfWork)
    {
        _reservationRepository = reservationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateReservationCommand command)
    {
        var userHaveActiveReservation = await _reservationRepository.CheckUserActiveReservationAsync(command.UserId);
        if(userHaveActiveReservation != null) throw new DuplicateNameException("User already have active reservation");
        //Fix: Add check for scooter availability
        var vehicleIsReserved = await _reservationRepository.CheckScooterAvailableAsync(command.ScooterId);
        if(vehicleIsReserved != null) throw new DuplicateNameException("Scooter is already reserved");
        var reservation = new ReservationEntity
        {
            ScooterId = command.ScooterId,
            UserId = command.UserId,
            StartTime = command.StartTime,
            EndTime = command.EndTime
        };

        await _reservationRepository.AddAsync(reservation);
        await _unitOfWork.CompleteAsync();
        return reservation.Id;
    }

    public async Task<bool> Handle(CancelReservationCommand command)
    {
        var reserve = await _reservationRepository.GetByIdAsync(command.Id);
        await _reservationRepository.RemoveAsync(reserve);
        await _unitOfWork.CompleteAsync();
        return true;
    }
    
    public async Task<bool> Handle(UpdateReservationCommand command)
    {
        var existingReservation = await _reservationRepository.GetByIdAsync(command.Id);
        if (existingReservation == null)
        {
            return false;
        }
        existingReservation.EndTime = command.EndTime;
        existingReservation.StartTime = command.StartTime;
        await _reservationRepository.UpdateAsync(existingReservation);
        await _unitOfWork.CompleteAsync();
        return true;
    }
    
    
}