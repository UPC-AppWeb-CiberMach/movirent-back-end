using System.ComponentModel.DataAnnotations;
using Domain.Shared.Model.Entities;

namespace Domain.Scooter.Model.Entities;
public class Scooter : ModelBase
{
    public int Id { get; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Brand { get; set; }
    [Required]
    public string Model { get; set; }
    [Required]
    public string Image { get; set; }
    [Required]
    public double PricePerHour { get; set; }
    [Required]
    public string District { get; set; }
    [Required]
    public string Phone { get; set; }
    
}
