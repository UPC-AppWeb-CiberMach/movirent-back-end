namespace Domain.UserHistorial.Model.Entities;

public class HistoryEntity 
{
    public long Id { get; set; }
    public Guid ClientId { get; set; }
    public Guid ScooterId { get; set; }
    //hola
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Price { get; set; }
    public int Time { get; set; }
}