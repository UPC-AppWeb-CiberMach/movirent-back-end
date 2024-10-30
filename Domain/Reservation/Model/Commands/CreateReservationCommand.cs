namespace Domain.Reservation.Model.Commands;

public record CreateReservationCommand(int ScooterId, int UserId, DateTime StartTime, DateTime EndTime);