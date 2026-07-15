using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.IngresoPedidosVM
{
    public class InfoClienteVM
    {
        public int nroJDE { get; set; }
        public string nombre { get; set; }
        public string cuit { get; set; }
        public string prov { get; set; }
        public string localidad { get; set; }
        public string direccion { get; set; }
        public string cp { get; set; }
        public string limiteCredito { get; set; }
        public string representante { get; set; }
        public string? areaVenta { get; set; }
        public string ABAC01 { get; set; }
    }
}
