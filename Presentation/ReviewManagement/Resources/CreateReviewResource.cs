using System.ComponentModel.DataAnnotations;

namespace Presentation.Review.Resources;

public record CreateReviewResource(
    [Required(ErrorMessage = "El comentario es obligatorio.")]
    [StringLength(200, ErrorMessage = "El comentario no puede exceder los 200 caracteres.")]
    string Comment,
    
    [Required(ErrorMessage = "La cantidad de estrellas es obligatoria.")]
    [Range(1, 5, ErrorMessage = "La cantidad de estrellas debe estar entre 1 y 5.")]
    int StarNumb
);