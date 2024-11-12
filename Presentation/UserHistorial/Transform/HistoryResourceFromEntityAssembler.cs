using Domain.UserHistorial.Model.Entities;
using Presentation.UserHistorial.Resources;

namespace Presentation.UserHistorial.Transform;

public static class HistoryResourceFromEntityAssembler
{
    public static HistoryResource ToResourceFromEntity(HistoryEntity entity) =>
        new HistoryResource(
            entity.Id,
            entity.ClientId,
            entity.ScooterId,
            entity.StartDate,
            entity.EndDate,
            entity.Price,
            entity.Time
        );
}