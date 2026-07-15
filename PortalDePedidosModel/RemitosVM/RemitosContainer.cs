using PortalDePedidosShared.RemitosVM;
using PortalDePedidosShared.UsuariosVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.RemitosVM
{
    public class RemitosContainer
    {
        public RemitoVM? remitosVM { get; set; }
        public UsuarioVM? cliente { get; set; }

        public void ReiniciarRemitosContainer()
        {
            cliente = null;
            remitosVM = null;
        }
    }
}
