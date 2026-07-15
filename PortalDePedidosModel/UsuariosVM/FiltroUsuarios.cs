using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.UsuariosVM
{
    public class FiltroUsuarios
    {
        public string? nombreUsuario { get; set; }
        public int? nroUsuarioJDE { get; set; }
        public bool cargarDatosCliente { get; set; }
    }
}
