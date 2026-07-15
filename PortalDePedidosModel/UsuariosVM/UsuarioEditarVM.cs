using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.UsuariosVM
{
    public class UsuarioEditarVM
    {
        public short IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string NroClienteJDE { get; set; }
        //este faltaba
        public string RazonSocial { get; set; }
        public string FechaUltimoIngreso { get; set; }

        [Required(ErrorMessage = "El Mail es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string MailUsuario { get; set; }
        //El rol no esta contemplado en la pantalla vieja pero es buena idea dejarlo en la nueva, ver en UsuarioAlta si hay duda
        [Required(ErrorMessage = "Seleccione un Rol de Cuenta.")]
        [NoCero(ErrorMessage = "Seleccione un Rol de Cuenta.")]
        public int? IdRol { get; set; }
        
        //tabla usuarios:
        public bool HabilitadoPedidos { get; set; }
        //Estos no estaban los agregue
        public bool HabilitadoParaIngresar { get; set; }
        public bool HabilitadoCampoDeCargaOC { get; set; }
        //Lo hacemos de esta manera asi es mas facil sincronizar los campos con el Formulario
        //Y usamos clases Enumerables para asegurarnos de recibir los mismos datos en el Servidor
        public AreaDeVenta? AreaVenta { get; set; }
        [NoCero(ErrorMessage = "Seleccione una Opcion.")]
        public FleteEnviadoPor? FleteEnviadoPor { get; set; }
        [NoCero(ErrorMessage = "Seleccione una Opcion.")]
        public FleteAbonadoEn? FleteAbonadoEn { get; set; }
        //public int ConfigFlete { get; set; } //dependiendo de qué se seleccione en flete enviado por y flete abonado en puede ser de 1 a 4 los valores que toma este.
        public string? CodZona { get; set; } //destino por defecto
        [Required(ErrorMessage = "Seleccione una moneda.")]
        [NoCero(ErrorMessage = "Seleccione una moneda.")]
        public string Moneda { get; set; }

    }
    
}
