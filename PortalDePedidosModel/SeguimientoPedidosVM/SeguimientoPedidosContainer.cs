using PortalDePedidosShared.UsuariosVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.SeguimientoPedidosVM
{
    public class SeguimientoPedidosContainer
    {
        public SeguimientoPedidoVM? seguimientoPedidoVM { get; set; }
        public UsuarioVM? cliente { get; set; }

        public void ReinicarSeguimiento()
        {
            seguimientoPedidoVM = null;
            cliente = null; 
        }
    }
}
