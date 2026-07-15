using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class VwPedidosEntreFecha
{
    public int Id { get; set; }

    public DateTime FechaPedido { get; set; }

    public string? An8 { get; set; }

    public string? Nombre { get; set; }

    public int TonPlt { get; set; }

    public int TonBol { get; set; }

    public int TonGra { get; set; }

    public string? ObservacionPedido { get; set; }

    public DateTime? FechaEnvio { get; set; }
}
