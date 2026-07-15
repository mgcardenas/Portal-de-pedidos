using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class UsuarioContacto
{
    public int IdUsuarioContacto { get; set; }

    public int IdUsuario { get; set; }

    public int IdContacto { get; set; }

    public int? HabilitadoFacturas { get; set; }

    public int? HabilitadoRecibos { get; set; }

    public int RegistroAnulado { get; set; }
}
