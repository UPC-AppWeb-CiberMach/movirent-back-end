namespace Presentation.Historial.Resources;

public record HistorialResource(
    int Id,
    int ScooterId,
    int UserId,
    DateTime StartTime,
    DateTime EndTime,
    DateTime CreatedDate);