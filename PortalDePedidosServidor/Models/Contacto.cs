using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class Contacto
{
    public int IdContacto { get; set; }

    public string NombreContacto { get; set; } = null!;

    public string MailContacto { get; set; } = null!;

    public string? ObservacionContacto { get; set; }

    public int RegistroAnulado { get; set; }
}
