using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.ModelsDataWhereHouse;

public partial class VPcConsultaRecibo
{
    public string? NroRecibo { get; set; }

    public DateOnly? FechaCobro { get; set; }

    public int Ccliente { get; set; }

    public string Moneda { get; set; } = null!;

    public double ImporteCobro { get; set; }

    public double ImporteCobroMe { get; set; }

    public string? NombreArchivo { get; set; }
}
