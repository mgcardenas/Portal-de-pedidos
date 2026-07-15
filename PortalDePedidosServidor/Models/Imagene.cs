using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class Imagene
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string IdArticulo { get; set; } = null!;
}
