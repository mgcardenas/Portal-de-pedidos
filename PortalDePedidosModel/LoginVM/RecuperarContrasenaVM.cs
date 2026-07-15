using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.LoginVM
{
    public class RecuperarContrasenaVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{8,}$",
        ErrorMessage = "La contraseña debe tener al menos 8 caracteres y contener al menos una letra mayúscula, un número y un símbolo.")]
        [NoIgualAtributo("ContrasenaAnterior", ErrorMessage = "La nueva contraseña no puede ser igual a la contraseña anterior.")]
        public string Contrasena { get; set; }

        [Required(ErrorMessage = "La confirmación de contraseña es obligatoria.")]
        [DataType(DataType.Password)]
        [Compare("Contrasena", ErrorMessage = "La contraseña y la confirmación de la contraseña no coinciden.")]
        public string ConfirmarContrasena { get; set; }
        public string ContrasenaAnterior { get; set; }

        public RecuperarContrasenaVM() 
        {
            Id = 0;
            Contrasena = string.Empty;
            ConfirmarContrasena = string.Empty;
        }
    }

    public class NoIgualAtributo : ValidationAttribute
    {
        private readonly string _compararCon;

        public NoIgualAtributo(string compararCon)
        {
            _compararCon = compararCon;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propiedadComparar = validationContext.ObjectType.GetProperty(_compararCon);
            if (propiedadComparar == null)
                return new ValidationResult($"La propiedad {_compararCon} no fue encontrada.");

            var valorComparar = propiedadComparar.GetValue(validationContext.ObjectInstance)?.ToString();
            var valorActual = value?.ToString();

            if (valorActual == valorComparar)
            {
                return new ValidationResult(ErrorMessage ?? $"El campo no debe ser igual a {_compararCon}.");
            }

            return ValidationResult.Success;
        }
    }
}
