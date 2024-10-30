namespace Domain.Reservation.Model.Commands;

public record UpdateReservationCommand(int Id, DateTime StartTime, DateTime EndTime);