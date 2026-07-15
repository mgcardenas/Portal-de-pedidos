using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.CuentasCorrientesVM
{
    public partial class FiltroCuentasCorrientesVM
    {
        public int NroCliente { get; set; }
        public DateOnly FechaDesde { get; set; } = DateOnly.FromDateTime(DateTime.Now.AddYears(-1));
        public DateOnly FechaHasta { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
