using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosModel
{
    public class UsuarioLogIn
    {
        public string userName {  get; set; }
        public string password { get; set; }

        public UsuarioLogIn()
        {
            this.userName = "";
            this.password = "";
        }
    }
}
