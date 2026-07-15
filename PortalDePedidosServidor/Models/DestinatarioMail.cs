using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class DestinatarioMail
{
    public int IdDestinatario { get; set; }

    public string DireccionDestinatario { get; set; } = null!;

    public string? NombreAmostrar { get; set; }

    public int CategoriaDestinatario { get; set; }
}
