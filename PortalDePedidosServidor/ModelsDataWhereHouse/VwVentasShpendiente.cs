using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.ModelsDataWhereHouse;

public partial class VwVentasShpendiente
{
    public int? CodCliente { get; set; }

    public int NroDoc { get; set; }

    public int? NroLinea { get; set; }

    public string? FechaOrden { get; set; }

    public string? CodArticulo { get; set; }

    public string? Desc1 { get; set; }

    public decimal? CantPedida { get; set; }

    public double? CantEntregada { get; set; }

    public double? CantPendiente { get; set; }

    public string? Ceco { get; set; }

    public string? CodRuta { get; set; }

    public string? Zona { get; set; }

    public byte CodTipoFlete { get; set; }

    public string CiaDoc { get; set; } = null!;

    public string TipoDoc { get; set; } = null!;

    public string? Um { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public string? Moneda { get; set; }
}
