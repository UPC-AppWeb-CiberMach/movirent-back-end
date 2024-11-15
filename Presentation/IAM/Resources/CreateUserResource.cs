using System.ComponentModel.DataAnnotations;

namespace Presentation.IAM.Resources
{
    public class CreateUserResource
    {
        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico es inválido.")]
        public string email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres.")]
        public string password { get; set; }

        [Required(ErrorMessage = "El nombre completo es obligatorio.")]
        public string completeName { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [Phone(ErrorMessage = "El formato del teléfono es inválido.")]
        public string phone { get; set; }

        [Required(ErrorMessage = "El DNI es obligatorio.")]
        [StringLength(8, ErrorMessage = "El DNI debe tener 8 caracteres.", MinimumLength = 8)]
        public string dni { get; set; }

        public string photo { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria.")]
        public string address { get; set; }
    }
}