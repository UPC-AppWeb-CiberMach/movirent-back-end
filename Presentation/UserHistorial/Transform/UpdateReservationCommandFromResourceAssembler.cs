using Domain.Reservation.Model.Commands;
using Presentation.Reservation.Resources;

namespace Presentation.Reservation.Transform;

public static class UpdateReservationCommandFromResourceAssembler
{
    public static UpdateReservationCommand ToCommandFromResource(int id, UpdateReservationResource resource)
    {
        return new UpdateReservationCommand(
            id,
            resource.StartTime,
            resource.EndTime);
    }
}