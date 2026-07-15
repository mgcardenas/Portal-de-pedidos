using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.UsuariosVM
{
    public class UsuarioAltaVM
    {
        public short IdUsuario { get; set; }
        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        public string NombreUsuario { get; set; }
        public string nroJDE { get; set; } = "";

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{8,}$",
        ErrorMessage = "La contraseña debe tener al menos 8 caracteres y contener al menos una letra mayúscula, un número y un símbolo.")]
        public string Contrasena { get; set; }

        [Required(ErrorMessage = "La confirmación de contraseña es obligatoria.")]
        [DataType(DataType.Password)]
        [Compare("Contrasena", ErrorMessage = "La contraseña y la confirmación de la contraseña no coinciden.")]
        public string RepetirContrasena { get; set; }

        [Required(ErrorMessage = "El Nro de Cliente de JDE es obligatorio.")]
        [NoCero(ErrorMessage = "Ingrese un Nro de Cliente valido")]
        public int? NroClienteJDE { get; set; } = 0;

        [Required(ErrorMessage = "El Mail es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string? MailUsuario { get; set; }

        [Required(ErrorMessage = "Seleccione un Rol de Cuenta.")]
        [NoCero(ErrorMessage = "Seleccione un Rol de Cuenta.")]
        public int? IdRol { get; set; }
        [Required(ErrorMessage = "Seleccione una moneda.")]
        [NoCero(ErrorMessage = "Seleccione una moneda.")]
        public string Moneda { get; set; }

        public UsuarioAltaVM() 
        {
        }
    }

    public class NoCero : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int intValue && intValue == 0)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
