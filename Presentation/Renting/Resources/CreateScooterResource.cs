using System.ComponentModel.DataAnnotations;

namespace Presentation.Renting.Resources
{
    public class CreateScooterResource
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La marca es obligatoria.")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "El modelo es obligatorio.")]
        public string Model { get; set; }

        [Required(ErrorMessage = "El precio por hora es obligatorio.")]
        [Range(1, double.MaxValue, ErrorMessage = "El precio por hora debe ser mayor a 0.")]
        public double PricePerHour { get; set; }

        [Required(ErrorMessage = "El distrito es obligatorio.")]
        public string District { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [Phone(ErrorMessage = "El formato del teléfono es inválido.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "La imagen es obligatoria.")]
        public string Image { get; set; }
    }
}