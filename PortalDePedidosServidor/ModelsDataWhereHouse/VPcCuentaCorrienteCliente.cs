using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.ModelsDataWhereHouse;

public partial class VPcCuentaCorrienteCliente
{
    public string NroFactura { get; set; } = null!;

    public DateOnly FechaFactura { get; set; }

    public DateOnly FechaVencimiento { get; set; }

    public string Moneda { get; set; } = null!;

    public double ImporteBruto { get; set; }

    public double ImporteBrutoMe { get; set; }

    public double ImportePendiente { get; set; }

    public double ImportePendienteMe { get; set; }

    public int NroCliente { get; set; }

    public string? NombreCliente { get; set; }

    public string? Estado { get; set; }

    public string FacturaVencida { get; set; } = null!;

    public string EstadoPago { get; set; } = null!;

    public string TipoDocumento { get; set; } = null!;

    public string? NroRemito { get; set; }

    public int? DiasDeMora { get; set; }

    public string? DescripcionTipoDocumento { get; set; }
}
