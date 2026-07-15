using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.SeguimientoPedidosVM
{
    public partial class SeguimientoPedidoVM
    {
        public int? CodCliente { get; set; }

        public string Tipo_doc { get; set; } = null!;

        public int Nro_doc { get; set; }

        public DateTime? Fecha_orden { get; set; }

        public string? CodArticulo { get; set; }

        public decimal? Cant_enviada { get; set; }

        public long CodTransportista { get; set; }

        public string? Transportista { get; set; }

        public string? Estado { get; set; }
        public long? Nro_doc_edi { get; set; }
        public string? Nro_remito { get; set; }
        public DateOnly? Fecha_entrega { get; set; }
    }
}
