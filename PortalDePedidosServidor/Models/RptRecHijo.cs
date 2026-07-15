using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class RptRecHijo
{
    public int IdRptRecHijo { get; set; }

    public string NroRecibo { get; set; } = null!;

    public string? Dato1 { get; set; }

    public string? Dato2 { get; set; }

    public string? Dato3 { get; set; }

    public string? Dato4 { get; set; }

    public string? Dato5 { get; set; }
}
