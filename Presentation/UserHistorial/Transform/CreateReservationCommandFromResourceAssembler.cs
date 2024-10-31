using Domain.Reservation.Model.Commands;
using Presentation.Reservation.Resources;

namespace Presentation.Reservation.Transform;

public static class CreateReservationCommandFromResourceAssembler
{
    public static CreateReservationCommand ToCommandFromResource(CreateReservationResource resource)
    {
        return new CreateReservationCommand(
            resource.UserId,
            resource.ScooterId,
            resource.StartTime,
            resource.EndTime);
    }
}