using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosModel
{
    public class Contacto
    {
        public int Id { get; set; }
        public string NombreApellido { get; set; }
        public string Email { get; set; }
        public string Observacion { get; set; }

        public Contacto(int id, string nombreApellido, string email, string observacion)
        {
            Id = id;
            NombreApellido = nombreApellido;
            Email = email;
            Observacion = observacion;
        }
    }
}