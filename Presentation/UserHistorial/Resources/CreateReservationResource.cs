using System.ComponentModel.DataAnnotations;

namespace Presentation.Reservation.Resources;

public record CreateReservationResource(
    [Required] 
    int ScooterId, 
    [Required] 
    int UserId, 
    [Required] 
    DateTime StartTime, 
    [Required] 
    DateTime EndTime);