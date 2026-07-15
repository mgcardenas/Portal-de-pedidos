using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.AuditoriasVM
{
    public class AuditoriasVM
    {
        public int id { get; set; }
        public int idUsuario { get; set; }
        public int idOperacion { get; set; }
        public DateTime timestamps { get; set; }
    }
}
