using PortalDePedidosShared.UsuariosVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.FacturasVM
{
    public class FacturasContainer
    {
        public FacturasSP? facturasSP { get; set; }
        public UsuarioVM? cliente { get; set; }

        public void ReiniciarFacturas()
        {
            facturasSP = null;
            cliente = null;
        }
    }
}
