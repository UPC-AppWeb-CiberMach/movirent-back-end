using System.ComponentModel.DataAnnotations;

namespace Presentation.Renting.Resources;


public record CreateScooterResource( 
    [Required]
    string Name, 
    [Required]
    string Brand, 
    [Required]
    string Model, 
    [Required]
    double PricePerHour, 
    [Required]
    string District, 
    [Required]
    [MinLength(9)]
    [MaxLength(9)]
    string Phone, 
    [Required]
    string Image);