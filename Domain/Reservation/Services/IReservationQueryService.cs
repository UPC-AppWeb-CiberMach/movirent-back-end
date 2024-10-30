using Domain.Reservation.Model.Entities;
using Domain.Reservation.Model.Queries;

namespace Domain.Reservation.Services;

public interface IReservationQueryService
{
    Task<IEnumerable<ReservationEntity>?> Handle(GetAllReservationsQuery query);
    Task<ReservationEntity?> Handle(GetReservationByIdQuery query);
}