namespace Domain.UserHistorial.Model.Commands;

public record DeleteHistorialCommand
{
    public int Id { get; }

    public DeleteHistorialCommand(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("El ID debe ser un número positivo.");
        }
        Id = id;
    }
}