using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.ModelsDataWhereHouse;

public partial class TiposProducto
{
    public string CodTipoArticulo { get; set; } = null!;

    public string TipoArticulo { get; set; } = null!;

    public string? TipoArticuloAgrupado { get; set; }
}
