using System.ComponentModel.DataAnnotations;
using Presentation.UserHistorial.Validation;
namespace Presentation.UserHistorial.Resources;

public record CreateHistoryResource(
    [Required] Guid ScooterId,
    [Required] Guid UserId,
    [Required] DateTime StartTime,
    [Required, CompareDates("StartTime", ErrorMessage = "La fecha de finalización debe ser posterior a la fecha de inicio.")]
    DateTime EndTime,
    [Required] int Price,
    [Required] int Time
);