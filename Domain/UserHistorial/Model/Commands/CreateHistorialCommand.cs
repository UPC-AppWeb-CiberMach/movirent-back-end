namespace Domain.UserHistorial.Model.Commands;

public record CreateHistorialCommand
{
    public int ScooterId { get; }
    public int UserId { get; }
    public DateTime StartTime { get; }
    public DateTime EndTime { get; }
    public int Price { get; }
    public int Time { get; }

    public CreateHistorialCommand(int scooterId, int userId, DateTime startTime, DateTime endTime, int price, int time)
    {
        // Validación para ScooterId
        if (scooterId <= 0)
        {
            throw new ArgumentException("El ID del scooter debe ser mayor a 0.");
        }
        ScooterId = scooterId;

        // Validación para UserId
        if (userId <= 0)
        {
            throw new ArgumentException("El ID del usuario debe ser mayor a 0.");
        }
        UserId = userId;

        // Validación para StartTime y EndTime
        if (endTime <= startTime)
        {
            throw new ArgumentException("La hora de finalización debe ser posterior a la hora de inicio.");
        }
        StartTime = startTime;
        EndTime = endTime;

        // Validación para Price
        if (price < 0)
        {
            throw new ArgumentException("El precio no puede ser negativo.");
        }
        Price = price;

        // Validación para Time
        if (time <= 0)
        {
            throw new ArgumentException("El tiempo debe ser mayor a 0.");
        }
        Time = time;
    }
}