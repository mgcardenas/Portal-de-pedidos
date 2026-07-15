using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.LoginVM
{
    public class SolicitudContrasenaVM
    {
        public int IdUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string Ip { get; set; }
        public DateTime FechaUltimaSolicitud { get; set; }
        public int Conteo { get; set; } = 0;
    }
}
