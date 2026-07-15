using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class LoginUsuario
{
    public DateTime FechaHora { get; set; }

    public short? CantSesiones { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string UsuarioOracle { get; set; } = null!;
}
