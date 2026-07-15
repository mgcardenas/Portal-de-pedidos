using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.ModelsDataWhereHouse;

public partial class CobroCabecera
{
    public int Idpago { get; set; }

    public string NumeroCobro { get; set; } = null!;

    public int Pagador { get; set; }

    public string FechaCobro { get; set; } = null!;

    public double ImporteCobro { get; set; }

    public string Moneda { get; set; } = null!;

    public double ImporteCobroMe { get; set; }

    public string Cuenta { get; set; } = null!;

    public string Observaciones { get; set; } = null!;

    public string Compania { get; set; } = null!;

    public string FechaLmrecibo { get; set; } = null!;

    public short Año { get; set; }

    public byte Periodo { get; set; }

    public string CodAnulacion { get; set; } = null!;

    public DateOnly? FechaCobroDate { get; set; }

    public DateOnly? FechaLmreciboDate { get; set; }

    public DateOnly? FechaVtoCheque { get; set; }

    public string? ReferenciaRecibo { get; set; }
}
