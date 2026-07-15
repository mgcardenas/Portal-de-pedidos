using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.ContactosVM
{
    public class ContactoVM
    {
        public int idContacto { get; set; }
        public string nombreContacto { get; set; }
        public string mailContacto { get; set; }
        public string observacionContacto { get; set; }
        public bool registroAnulado { get; set; }
    }
}
