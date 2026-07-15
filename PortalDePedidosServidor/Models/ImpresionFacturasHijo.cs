using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class ImpresionFacturasHijo
{
    public int IdArticulo { get; set; }

    public int IdFactura { get; set; }

    public string? CodArticulo { get; set; }

    public string? DescArticulo { get; set; }

    public string? DescArticulo2 { get; set; }

    public float? CantArticulo { get; set; }

    public string? UmArticulo { get; set; }

    public float? PrecioUniArticulo { get; set; }
}
