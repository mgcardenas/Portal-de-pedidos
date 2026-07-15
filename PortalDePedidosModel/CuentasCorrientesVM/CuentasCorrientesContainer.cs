using PortalDePedidosShared.CuentasCorrientesVM;
using PortalDePedidosShared.UsuariosVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.CuentasCorrientesVM
{
    public class CuentasCorrientesContainer
    {
        public CuentaCorrienteVM? cuentaCorrienteVM { get; set; }
        public UsuarioVM? cliente { get; set; }

        public void ReiniciarCuentasCorrientes()
        {
            cuentaCorrienteVM = null;
            cliente = null;
        }
    }
}
