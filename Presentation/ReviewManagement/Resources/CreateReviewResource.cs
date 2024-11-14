using System.ComponentModel.DataAnnotations;

namespace Presentation.Review.Resources;


public record CreateReviewResource( 
    [Required]
    string Comment, 
    [Required]
    int StarNumb);