using Domain.Reservation.Model.Entities;
using Domain.Shared;

namespace Domain.Reservation.Repositories;

public interface IReservationRepository : IBaseRepository<ReservationEntity>
{
    Task<ReservationEntity?> CheckScooterAvailableAsync(int id);
    Task<ReservationEntity?> CheckUserActiveReservationAsync(int id);
}