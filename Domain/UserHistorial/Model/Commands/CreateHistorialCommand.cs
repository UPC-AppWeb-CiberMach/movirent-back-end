namespace Domain.UserHistorial.Model.Commands;

public record CreateHistorialCommand(int ScooterId, int UserId, DateTime StartTime, DateTime EndTime, int Price, int Time);