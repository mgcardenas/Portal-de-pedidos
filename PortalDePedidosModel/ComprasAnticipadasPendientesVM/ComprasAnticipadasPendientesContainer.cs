using PortalDePedidosShared.SeguimientoPedidosVM;
using PortalDePedidosShared.UsuariosVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.ComprasAnticipadasPendientesVM
{
    public class ComprasAnticipadasPendientesContainer
    {
        public UsuarioVM? cliente { get; set; }
        //public List<ComprasAnticipadasVM>? seleccionados { get; set; }
        //public bool EsCompraAnticipada { get; set; } = false;

        public void ReiniciarContainer()
        {
            //seleccionados = null;
            //EsCompraAnticipada = false;
            cliente = null;
        }
    }
}
