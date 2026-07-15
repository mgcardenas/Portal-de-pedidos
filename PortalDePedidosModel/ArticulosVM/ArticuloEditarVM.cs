using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.ArticulosVM
{
    public class ArticuloEditarVM
    {
        public int? IdItemPreorden { get; set; }

        public int CodCortoArticulo { get; set; }

        public string CodItem { get; set; }

        public string NombreItem { get; set; }

        public string Descripcion2 { get; set; }
        public string? UrlImagen { get; set; }
        public string GrupoArticulo { get; set; }
        public string UM_Principal { get; set; }
        public string CodEAN { get; set; }
        public string? CodPlanta { get; set; }
        public short? AlmacenItem { get; set; }

        public bool ArticuloEnBaseDeDatos { get; set; }
    }
}
