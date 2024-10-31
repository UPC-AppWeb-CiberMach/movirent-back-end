using System.ComponentModel.DataAnnotations;

namespace Presentation.UserHistorial.Resources;

public record CreateHistorialResource(
    [Required] 
    int ScooterId, 
    [Required] 
    int UserId, 
    [Required] 
    DateTime StartTime, 
    [Required] 
    DateTime EndTime,
    [Required]
    int Price, 
    [Required] 
    int Time
    );