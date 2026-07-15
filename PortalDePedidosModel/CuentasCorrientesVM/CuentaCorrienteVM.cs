using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.CuentasCorrientesVM
{
    public partial class CuentaCorrienteVM
    {
        public string tipoDocumento { get; set; }
        public string nro_Factura { get; set; }
        public string nro_remito { get; set; }
        public DateTime fechaFactura { get; set; }
        public DateTime fechaVencimiento { get; set; }
        public string moneda { get; set; }
        public double importeBruto { get; set; }
        public double importeBrutoME { get; set; }
        public double importePendiente { get; set; }
        public double importePendienteME { get; set; }
        public int nro_cliente { get; set; }
        public string? nombre_cliente { get; set; }
        public string? estado { get; set; }
        public string? factura_vencida { get; set; }
        public int? dias_de_mora { get; set; }
        public string? DescripcionTipoDocumento { get; set; }
    }
}
