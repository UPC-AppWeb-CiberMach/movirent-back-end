using Domain.Historial.Model.Entities;
using Presentation.Historial.Resources;

namespace Presentation.Historial.Transform;

public static class HistorialResourceFromEntityAssembler
{
    public static HistorialResource ToResourceFromEntity(HistorialEntity entity) =>
        new HistorialResource(
            entity.Id,
            entity.ScooterId,
            entity.UserId,
            entity.StartTime,
            entity.EndTime,
            entity.CreatedDate
        );
}