using PortalDePedidosShared.IngresoPedidosVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.RemitosVM
{
    public class RemitoEstadisticaVM
    {
        public int? CodCliente { get; set; }

        public string TipoDoc { get; set; } 

        public int NroDoc { get; set; }

        public DateTime FechaOrden { get; set; }

        public DateTime? FechaEnvio { get; set; }

        public ArticuloIngresoPedidoVM Articulo { get; set; }

        public decimal? CantEnviada { get; set; }

        public long CodTransportista { get; set; }

        public string? Transportista { get; set; }

        public string NroRemito { get; set; }
    }
}
