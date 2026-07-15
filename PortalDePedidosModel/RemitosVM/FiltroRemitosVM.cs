using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.RemitosVM
{
    public partial class FiltroRemitosVM
    {
        public int CodCliente { get; set; }
        public DateOnly FechaDesde { get; set; } = DateOnly.FromDateTime(DateTime.Now.AddYears(-1));
        public DateOnly FechaHasta { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public string? NroRemito { get; set; }
    }
}
