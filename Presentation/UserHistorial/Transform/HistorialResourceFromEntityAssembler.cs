using Domain.UserHistorial.Model.Entities;
using Presentation.UserHistorial.Resources;

namespace Presentation.UserHistorial.Transform;

public static class HistorialResourceFromEntityAssembler
{
    public static HistorialResource ToResourceFromEntity(HistorialEntity entity) =>
        new HistorialResource(
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