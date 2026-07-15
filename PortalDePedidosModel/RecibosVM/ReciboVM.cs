using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.RecibosVM
{
    public class ReciboVM
    {
        public string? NroRecibo { get; set; }

        public DateTime FechaCobro { get; set; }

        public int CodCliente { get; set; }

        public string Moneda { get; set; } = null!;

        public double ImporteCobro { get; set; }

        public double ImporteCobroMe { get; set; }

        public string? NombreArchivo { get; set; } = "";
    }
}
