using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.SeguimientoPedidosVM
{
    public partial class FiltroSeguimientoPedidos {
        public int? CodCliente { get; set; }
        public DateTime FechaDesde { get; set; } = DateTime.Now.AddYears(-1);
        public DateTime FechaHasta { get; set; } = DateTime.Now;
        public string? Estado { get; set; } = "0";
}
}
