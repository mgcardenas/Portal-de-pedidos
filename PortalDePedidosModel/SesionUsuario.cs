using PortalDePedidosShared.UsuariosVM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosModel
{
    public class SesionUsuario
    {
        public int Id { get; set; }
        public string NroUsuarioJDE { get; set; }
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public string Rol { get; set; }
        public List<Permisos> Permisos { get; set; }      
        public DateTime Expiracion { get; set; }
        public bool ContrasenaExpirada { get; set; } = false;
        public string Contrasena { get; set; } = "";
        public bool TieneDeuda { get; set; } = false;
        public string Token { get; set; } = "";
        public string CodRubroCliente { get; set; } = "";

        public SesionUsuario() 
        {
            NroUsuarioJDE = string.Empty;   
            NombreUsuario = string.Empty;
            Correo = string.Empty;  
            Rol = string.Empty;
            Expiracion = DateTime.MinValue;
            Permisos = new List<Permisos>();
        }
    }
}
