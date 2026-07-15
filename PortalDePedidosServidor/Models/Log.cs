using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class Log
{
    public int? IdLog { get; set; }

    public DateTime? FechaLog { get; set; }

    public string? ClaseLog { get; set; }

    public string? ClaveObjetoLog { get; set; }

    public string? ModuloLog { get; set; }

    public int? IdUsuario { get; set; }

    public string? ObservacionLog { get; set; }
}
