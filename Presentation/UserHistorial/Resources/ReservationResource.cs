namespace Presentation.Reservation.Resources;

public record ReservationResource(
    int Id,
    int ScooterId,
    int UserId,
    DateTime StartTime,
    DateTime EndTime,
    DateTime CreatedDate);