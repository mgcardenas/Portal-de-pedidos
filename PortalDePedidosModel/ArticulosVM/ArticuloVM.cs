using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.ArticulosVM
{
    public class ArticuloVM
    {
        public string CodArticulo { get; set; }

        public string Descripcion { get; set; }
        public string Categoria { get; set; } = "";
        public string? SubCategoria { get; set; }
        public string? Imagen { get; set; }
    }
}
