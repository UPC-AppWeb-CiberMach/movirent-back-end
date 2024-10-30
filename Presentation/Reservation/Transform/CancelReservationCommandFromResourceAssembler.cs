using Domain.Reservation.Model.Commands;
using Presentation.Reservation.Resources;

namespace Presentation.Reservation.Transform;

public static class CancelReservationCommandFromResourceAssembler
{
    public static CancelReservationCommand ToCommandFromResource(CancelReservationResource resource)
    {
        return new CancelReservationCommand(resource.Id);
    }
}