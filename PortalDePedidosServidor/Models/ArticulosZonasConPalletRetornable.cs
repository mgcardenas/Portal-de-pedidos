using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class ArticulosZonasConPalletRetornable
{
    public int CodCortoArticulo { get; set; }

    public string CodArticulo { get; set; } = null!;

    public string Zona { get; set; } = null!;
}
