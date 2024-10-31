using Domain.Shared.Model.Entities;

namespace Domain.Historial.Model.Entities;

public class HistorialEntity : ModelBase
{
    public int ScooterId { get; set; }
    public int UserId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}