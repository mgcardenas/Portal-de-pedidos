using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.RecibosVM
{
    public class FiltroRecibos
    {
        public int CodCliente { get; set; }
        public DateTime FechaDesde { get; set; } = DateTime.Now.AddYears(-1);
        public DateTime FechaHasta { get; set; } = DateTime.Now;
        public string? NroRecibo { get; set; }
    }
}
