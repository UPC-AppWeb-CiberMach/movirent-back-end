using System.ComponentModel.DataAnnotations;

namespace Presentation.IAM.Resources;

public record CreateUserResource(
    [Required]
    [MinLength(3)]
    [MaxLength(50)]
    string email, 
    [Required]
    [MinLength(8)]
    [MaxLength(20)]
    string password, 
    [Required]
    [MinLength(4)]
    [MaxLength(50)]
    string completeName, 
    [Required]
    [MinLength(9)]
    [MaxLength(9)]
    string phone, 
    [Required]
    [MinLength(8)]
    [MaxLength(8)]
    string dni, 
    [Required]
    [MinLength(4)]
    [MaxLength(60)]
    string photo, 
    [Required]
    [MinLength(4)]
    [MaxLength(60)]
    string address);

