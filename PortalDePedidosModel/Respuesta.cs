using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosModel
{
    public class Respuesta <T>
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
        public T Data { get; set; }

        public Respuesta()
        {
            this.Exito = false;
            this.Mensaje = "";
        }
    }
}
