using PortalDePedidosShared.RemitosVM;
using PortalDePedidosShared.UsuariosVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.EstadisticasVM
{
    public class EstadisticaContainer
    {
        public UsuarioVM? cliente { get; set; }

        public void ReiniciarEstadisticaContainer()
        {
            cliente = null;
        }
    }
}
