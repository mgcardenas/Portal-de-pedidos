using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class RptFacHijo
{
    public int IdRptFacHijo { get; set; }

    public int? NroInterno { get; set; }

    public int? NroArticulo { get; set; }

    public string? ItemArticulo { get; set; }

    public string? DetalleArticulo { get; set; }

    public string? Desc1Art { get; set; }

    public string? Desc2Art { get; set; }

    public string? Extra1Art { get; set; }

    public string? Extra2Art { get; set; }

    public string? CantArt { get; set; }

    public string? UnidadArt { get; set; }

    public string? PrecioUnitArt { get; set; }

    public string? SubtotalArt { get; set; }

    public string? ImporteArt { get; set; }

    public string? Secuencia { get; set; }

    public string? IdentifArt { get; set; }

    public DateTime? FechaCreacionRegistro { get; set; }
}
