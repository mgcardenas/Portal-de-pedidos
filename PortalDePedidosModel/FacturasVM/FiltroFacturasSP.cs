using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.FacturasVM
{
    public partial class FiltroFacturasSP
    {
        public int CodCliente { get; set; }
        public DateOnly FechaDesde { get; set; } = DateOnly.FromDateTime(DateTime.Now.AddYears(-1));
        public DateOnly FechaHasta { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    }
}