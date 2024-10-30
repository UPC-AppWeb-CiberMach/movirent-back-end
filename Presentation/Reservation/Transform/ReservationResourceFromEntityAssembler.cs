using Domain.Reservation.Model.Entities;
using Presentation.Reservation.Resources;

namespace Presentation.Reservation.Transform;

public static class ReservationResourceFromEntityAssembler
{
    public static ReservationResource ToResourceFromEntity(ReservationEntity entity) =>
        new ReservationResource(
            entity.Id,
            entity.ScooterId,
            entity.UserId,
            entity.StartTime,
            entity.EndTime,
            entity.CreatedDate
        );
}