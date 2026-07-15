using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class ClientesActivo
{
    public string NombreUsuario { get; set; } = null!;

    public string UsuarioOracle { get; set; } = null!;

    public DateTime FechaUltimaVisita { get; set; }

    public int? Pedidos { get; set; }
}
