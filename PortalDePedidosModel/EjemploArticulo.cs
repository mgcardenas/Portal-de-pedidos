using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosModel
{
    public class EjemploArticulo
    {

        public int CodArticulo { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }

        public EjemploArticulo( int codArticulo, string descripcion, string categoria)
        {
            CodArticulo = codArticulo;
            Descripcion = descripcion;
            Categoria = categoria;
        }
    }
}
