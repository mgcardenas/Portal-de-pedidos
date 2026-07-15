using PortalDePedidosShared.UsuariosVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.IngresoPedidosVM
{
    public class InformacionFinalPedido
    {
        public int idPedido { get; set; } 
        public int cantidadPalletRetornables { get; set; }
        public List<ArticuloIngresoPedidoVM> articulos { get; set; }
        public List<DatosPedidoVM> pedidos { get; set; } = new();
        public double pesoTotal { get; set; }
        public UsuarioVM cliente { get; set; }
    }
}
