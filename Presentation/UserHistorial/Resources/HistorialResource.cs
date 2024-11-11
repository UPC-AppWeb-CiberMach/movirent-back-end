namespace Presentation.UserHistorial.Resources;

public record HistorialResource(
    int Id,
    int ScooterId,
    int UserId,
    DateTime StartTime,
    DateTime EndTime,
    int Price,
    int Time,
    DateTime CreatedDate);