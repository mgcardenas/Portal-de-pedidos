using PortalDePedidosShared.UsuariosVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.RecibosVM
{
    public class ReciboContainer
    {
        public UsuarioVM? cliente { get; set; } = null;

        public ReciboContainer() { }

        public void ReiniciarReciboContainer()
        {
            cliente = null;
        }
    }
}
