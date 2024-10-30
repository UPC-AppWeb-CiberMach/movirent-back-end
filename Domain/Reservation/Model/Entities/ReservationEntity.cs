using Domain.Shared.Model.Entities;

namespace Domain.Reservation.Model.Entities;

public class ReservationEntity : ModelBase
{
    public int ScooterId { get; set; }
    public int UserId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}