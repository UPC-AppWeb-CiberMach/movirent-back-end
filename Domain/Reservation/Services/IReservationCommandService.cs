using Domain.Reservation.Model.Commands;

namespace Domain.Reservation.Services;

public interface IReservationCommandService
{
    Task<int> Handle(CreateReservationCommand command);
    Task<bool> Handle(CancelReservationCommand command);
    Task<bool> Handle(UpdateReservationCommand command);
}