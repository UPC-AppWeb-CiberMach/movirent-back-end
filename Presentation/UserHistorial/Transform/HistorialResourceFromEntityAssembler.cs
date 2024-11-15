using Domain.UserHistorial.Model.Entities;
using Presentation.UserHistorial.Resources;

namespace Presentation.UserHistorial.Transform;

public static class HistorialResourceFromEntityAssembler
{
    public static HistorialResource ToResourceFromEntity(HistorialEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "La entidad de historial no puede ser nula.");
        }

        if (entity.ScooterId <= 0)
        {
            throw new ArgumentException("El ID del scooter debe ser válido.");
        }

        if (entity.UserId <= 0)
        {
            throw new ArgumentException("El ID del usuario debe ser válido.");
        }

        if (entity.EndTime <= entity.StartTime)
        {
            throw new ArgumentException("La hora de finalización debe ser posterior a la hora de inicio.");
        }

        return new HistorialResource(
            entity.Id,
            entity.ScooterId,
            entity.UserId,
            entity.StartTime,
            entity.EndTime,
            entity.Price,
            entity.Time,
            entity.CreatedDate
        );
    }
}