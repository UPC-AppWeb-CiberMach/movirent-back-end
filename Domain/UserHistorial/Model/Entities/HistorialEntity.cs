using Domain.Shared.Model.Entities;

namespace Domain.UserHistorial.Model.Entities;

public class HistorialEntity : ModelBase
{
    public int ScooterId { get; set; }
    public int UserId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int Price { get; set; }
    public int Time { get; set; }
}