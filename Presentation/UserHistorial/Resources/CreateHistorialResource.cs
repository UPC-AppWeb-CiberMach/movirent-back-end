using System;
using System.ComponentModel.DataAnnotations;
using Presentation.UserHistorial.Validation; // Asegúrate de tener este import

namespace Presentation.UserHistorial.Resources
{
    public record CreateHistorialResource(
        [Required] int ScooterId,
        [Required] int UserId,
        [Required] DateTime StartTime,
        [Required, CompareDates("StartTime", ErrorMessage = "La fecha de finalización debe ser posterior a la fecha de inicio.")]
        DateTime EndTime,
        [Required] int Price,
        [Required] int Time
    );
}