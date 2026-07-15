using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.ModelsDataWhereHouse;

public partial class CuentaCorrienteCliente
{
    public string CiaDocumento { get; set; } = null!;

    public string TipoDocumento { get; set; } = null!;

    public int NroDocumento { get; set; }

    public string? SufijoDocumento { get; set; }

    public DateOnly FechaFactura { get; set; }

    public double ImporteBruto { get; set; }

    public double ImportePendiente { get; set; }

    public DateOnly FechaVencimiento { get; set; }

    public string Moneda { get; set; } = null!;

    public double TipoCambio { get; set; }

    public string EstadoPago { get; set; } = null!;

    public int Cliente { get; set; }

    public double ImporteBrutoMe { get; set; }

    public double ImportePendienteMe { get; set; }

    public int NroOv { get; set; }

    public string TipoOv { get; set; } = null!;

    public string CiaOv { get; set; } = null!;

    public string SufijoOv { get; set; } = null!;

    public string UnidadNegocio { get; set; } = null!;

    public string NroFacturaLegal { get; set; } = null!;

    public DateOnly FechaLiquidacion { get; set; }

    public string? NroFacturaProveedor { get; set; }

    public double ImporteImponible { get; set; }

    public double Impuestos { get; set; }

    public string? IdCuenta { get; set; }

    public DateOnly? FechaVoid { get; set; }

    public long? NumeroReservado { get; set; }

    public string? ReferenciaReservada { get; set; }

    public double? Unidades { get; set; }

    public string? VJde { get; set; }

    public int? LineaOv { get; set; }
}
