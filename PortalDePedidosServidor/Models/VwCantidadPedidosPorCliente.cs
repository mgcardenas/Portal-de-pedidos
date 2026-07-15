using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class VwCantidadPedidosPorCliente
{
    public string? NroCliente { get; set; }

    public string? Nombre { get; set; }

    public int? PedidosRealizados { get; set; }
}
