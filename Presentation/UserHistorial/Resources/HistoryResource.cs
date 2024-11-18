namespace Presentation.UserHistorial.Resources;

public record HistoryResource(
    long Id,
    Guid ClientId,
    Guid ScooterId,
    DateTime StartDate,
    DateTime EndDate,
    decimal Price,
    int Time);