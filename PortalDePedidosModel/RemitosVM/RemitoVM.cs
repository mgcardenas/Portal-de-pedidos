using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.RemitosVM
{
    public partial class RemitoVM
    {
        public int CodCliente { get; set; }

        public DateTime FechaEnvio { get; set; }

        public string NroRemito { get; set; }
        public string? NombreArchivo { get; set; } = "";
    }
}
