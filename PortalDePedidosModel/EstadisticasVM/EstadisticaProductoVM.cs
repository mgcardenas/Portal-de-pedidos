using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.EstadisticasVM
{
    public class EstadisticaProductoVM
    {
        public TipoEstadisticaProducto TipoProducto { get; set; }
        public List<EstadisticaPorMes> EstadisticasPorMes { get; set; }
    }
}
