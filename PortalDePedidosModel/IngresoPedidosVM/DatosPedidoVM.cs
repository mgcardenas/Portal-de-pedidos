using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.IngresoPedidosVM
{
    public class DatosPedidoVM
    {
        public int IdPedido { get; set; }
        public int nroPedido { get; set; }
        public DateTime fechaDeEntrega { get; set; }
        
        public string? observaciones { get; set; }
    }
}
