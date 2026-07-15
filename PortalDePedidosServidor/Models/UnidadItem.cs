using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class UnidadItem
{
    public int IdUnidadItem { get; set; }

    public string NombreUnidad { get; set; } = null!;

    public int RegistroAnulado { get; set; }
}
