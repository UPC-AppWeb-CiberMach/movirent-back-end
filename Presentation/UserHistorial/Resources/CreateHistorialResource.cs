using System.ComponentModel.DataAnnotations;

namespace Presentation.Historial.Resources;

public record CreateHistorialResource(
    [Required] 
    int ScooterId, 
    [Required] 
    int UserId, 
    [Required] 
    DateTime StartTime, 
    [Required] 
    DateTime EndTime);