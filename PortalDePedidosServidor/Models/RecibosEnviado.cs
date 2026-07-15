using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class RecibosEnviado
{
    public int Id { get; set; }

    public string NroRecibo { get; set; } = null!;

    public DateTime FechaRecibo { get; set; }

    public DateTime FechaEnvio { get; set; }

    public string MailEnvio { get; set; } = null!;

    public string NroCliente { get; set; } = null!;

    public string? NombreCliente { get; set; }

    public string? CopiasMail { get; set; }
}
