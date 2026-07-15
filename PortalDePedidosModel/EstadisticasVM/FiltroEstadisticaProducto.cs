using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.EstadisticasVM
{
    public class FiltroEstadisticaProducto
    {
        public string CodCliente { get; set; }
        public TipoEstadisticaProducto TipoProducto { get; set; } = TipoEstadisticaProducto.Adhesivos;
        public DateTime fechaDesde { get; set; }
        public DateTime fechaHasta { get; set; } = DateTime.Now;

        public FiltroEstadisticaProducto() 
        {
            fechaDesde = CalcularFechaDesde();
        }
        public DateTime CalcularFechaDesde()
        {
            var fechaDesde = DateTime.Now.AddYears(-2).Year + "-01-01";
            return DateTime.Parse(fechaDesde);
        }
    }
}
