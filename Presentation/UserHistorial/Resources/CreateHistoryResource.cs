using System.ComponentModel.DataAnnotations;

namespace Presentation.UserHistorial.Resources;

public record CreateHistoryResource(
    [Required] 
    Guid ClientId, 
    [Required] 
    Guid ScooterId, 
    [Required] 
    DateTime StartDate, 
    [Required] 
    DateTime EndDate,
    [Required]
    decimal Price, 
    [Required] 
    int Time
);