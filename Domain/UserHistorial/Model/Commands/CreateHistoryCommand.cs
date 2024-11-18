namespace Domain.UserHistorial.Model.Commands;

public record CreateHistoryCommand(
    Guid ClientId, 
    Guid ScooterId, 
    DateTime StartDate, 
    DateTime EndDate, 
    decimal Price, 
    int Time);