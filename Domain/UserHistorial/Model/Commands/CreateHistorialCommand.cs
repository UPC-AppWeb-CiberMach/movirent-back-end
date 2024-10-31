namespace Domain.Historial.Model.Commands;

public record CreateHistorialCommand(int ScooterId, int UserId, DateTime StartTime, DateTime EndTime);