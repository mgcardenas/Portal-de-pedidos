using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.ComprasAnticipadasPendientesVM
{
    public class ComprasAnticipadasVM
    {
        public int? CodCliente { get; set; }

        public int NroDoc { get; set; }
        public string? NroFactura { get; set; }

        public int? NroLinea { get; set; }

        public string? FechaOrden { get; set; }

        public string? CodArticulo { get; set; }

        public string? Desc1 { get; set; }

        public string? CantPedida { get; set; }
        public double? CantPedidaNum { get; set; }

        public string? CantEntregada { get; set; }
        public double? CantEntregadaNum { get; set; }

        public string? CantPendiente { get; set; }
        public double? CantPendienteNum { get; set; }
        public string? Ceco { get; set; }

        public string? CodRuta { get; set; }

        public string? Zona { get; set; }

        public string CodTipoFlete { get; set; }

        public string CiaDoc { get; set; } = null!;

        public string TipoDoc { get; set; } = null!;

        public string? Um { get; set; }

        public decimal? PrecioUnitario { get; set; }

        public string? Moneda { get; set; }
        public string? CantSgSinProcesar { get; set; }
        public double? CantSgSinProcesarNum { get; set; }
        public bool LlevaPalletRetornable { get; set; } = false;
        public bool Seleccionado { get; set; } = false;
    }
}
