using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.RemitosVM
{
    public class FiltroRemitoEstadistica
    {
        public int CodCliente { get; set; }
        public DateTime FechaDesde { get; set; } 
        public DateTime FechaHasta { get; set; } 
    }
}
