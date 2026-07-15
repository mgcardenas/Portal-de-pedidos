using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class MailSetup
{
    public string SmtpServer { get; set; } = null!;

    public int? Puerto { get; set; }

    public string? MailUser { get; set; }

    public string? MailPass { get; set; }

    public string DireccionRemitente { get; set; } = null!;

    public string? NombreAmostrarRemitente { get; set; }
}
