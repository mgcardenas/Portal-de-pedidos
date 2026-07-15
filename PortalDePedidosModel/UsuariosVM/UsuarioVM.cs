using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.UsuariosVM
{
    public class UsuarioVM
    {
        public int id { get; set; }
        public string nombreUsuario { get; set; }
        public string razonSocial { get; set; } = "";
        public string nroUsuarioJDE { get; set; }
        public string mail { get; set; }
        public DateTime fechaUltimaVisita { get; set; }
        public bool envioFactura { get; set; }
        public bool envioRecibo { get; set; }
        public int areaDeVenta { get; set; }
        public string codZona { get; set; }
        public string moneda { get; set; }
    }
}
