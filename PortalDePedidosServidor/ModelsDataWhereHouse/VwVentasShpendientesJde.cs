using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.ModelsDataWhereHouse;

public partial class VwVentasShpendientesJde
{
    public double? CodCliente { get; set; }

    public string CiaDoc { get; set; } = null!;

    public string TipoDoc { get; set; } = null!;

    public double NroDoc { get; set; }

    public double NroLinea { get; set; }

    public string? FechaOrden { get; set; }

    public string? CodArticulo { get; set; }

    public string? Desc1 { get; set; }

    public double? CantPedida { get; set; }

    public double? CantEntregada { get; set; }

    public double? CantPendiente { get; set; }

    public string? Ceco { get; set; }

    public string? CodRuta { get; set; }

    public string? Zona { get; set; }

    public string? CodTipoFlete { get; set; }

    public string? Um { get; set; }

    public double? PrecioUnitario { get; set; }

    public string? Moneda { get; set; }

    public double? CantSgSinProcesar { get; set; }

    public string NroFacturaLegal { get; set; } = null!;
}
