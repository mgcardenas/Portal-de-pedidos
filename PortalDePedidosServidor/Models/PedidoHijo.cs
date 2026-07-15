using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class PedidoHijo
{
    public int IdPedidoHijo { get; set; }

    public string CodArticulo { get; set; } = null!;

    public int IdPedido { get; set; }

    public int Cantidad { get; set; }

    public int RegistroAnulado { get; set; }

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;
}
