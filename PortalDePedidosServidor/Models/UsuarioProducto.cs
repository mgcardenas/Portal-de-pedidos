using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class UsuarioProducto
{
    public int IdUsuarioProducto { get; set; }

    public int IdUsuario { get; set; }

    public int IdProducto { get; set; }

    public int RegistroAnulado { get; set; }
}
