using System.ComponentModel.DataAnnotations;

namespace Domain.IAM.Model.Commands
{
    public class CreateUserCommand
    {
        public string email { get; private set; }
        public string password { get; private set; }
        public string completeName { get; private set; }
        public string phone { get; private set; }
        public string dni { get; private set; }
        public string photo { get; private set; }
        public string address { get; private set; }

        public CreateUserCommand(string email, string password, string completeName, string phone, string dni, string photo, string address)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("El correo electrónico es obligatorio.");

            if (!new EmailAddressAttribute().IsValid(email))
                throw new ArgumentException("El formato del correo electrónico es inválido.");

            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
                throw new ArgumentException("La contraseña debe tener al menos 8 caracteres.");

            if (string.IsNullOrWhiteSpace(completeName))
                throw new ArgumentException("El nombre completo es obligatorio.");

            if (string.IsNullOrWhiteSpace(phone))
                throw new ArgumentException("El teléfono es obligatorio.");

            if (dni.Length != 8)
                throw new ArgumentException("El DNI debe tener exactamente 8 caracteres.");

            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("La dirección es obligatoria.");

            // Asignación de valores a las propiedades
            this.email = email;
            this.password = password;
            this.completeName = completeName;
            this.phone = phone;
            this.dni = dni;
            this.photo = photo;
            this.address = address;
        }
    }
}