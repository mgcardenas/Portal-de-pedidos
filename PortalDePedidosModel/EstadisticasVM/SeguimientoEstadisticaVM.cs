using PortalDePedidosShared.IngresoPedidosVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.EstadisticasVM
{
    public class SeguimientoEstadisticaVM
    {
        public int? CodCliente { get; set; }

        public int NroDoc { get; set; }

        public int Mes { get; set; }
        public int Anio { get; set; }

        public ArticuloIngresoPedidoVM? Articulo { get; set; }

        public decimal? CantEnviada { get; set; }
    }
}
