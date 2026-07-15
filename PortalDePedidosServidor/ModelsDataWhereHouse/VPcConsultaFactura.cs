using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.ModelsDataWhereHouse;

public partial class VPcConsultaFactura
{
    public int? CodCliente { get; set; }

    public string TipoDoc { get; set; } = null!;

    public int NroDoc { get; set; }

    public DateOnly? Expr1 { get; set; }

    public string NroFactura { get; set; } = null!;

    public string? NombreArchivo { get; set; }

    public decimal? PrecioTotal { get; set; }

    public DateOnly? FechaFactura { get; set; }

    public DateOnly? FechaVtoFactura { get; set; }

    public string? NroRemito { get; set; }
}
