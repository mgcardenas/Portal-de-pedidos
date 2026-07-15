using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class RptRemHijo
{
    public int IdRptRemHijo { get; set; }

    public int? NroPedido { get; set; }

    public int? NroArticulo { get; set; }

    public string? ItemArticulo { get; set; }

    public string? DetalleArticulo { get; set; }

    public string? Desc1Art { get; set; }

    public string? CantArt { get; set; }

    public string? UnidadArt { get; set; }

    public string? Secuencia { get; set; }
}
