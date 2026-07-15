using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class Ncgenerada
{
    public int Id { get; set; }

    public int NroPedido { get; set; }

    public string? TipoPedido { get; set; }

    public string? TipoInterno { get; set; }

    public int NroInterno { get; set; }

    public DateTime FechaEnvio { get; set; }

    public string? MailEnvio { get; set; }

    public int? NroCliente { get; set; }

    public string? NombreCliente { get; set; }

    public string? CopiasMail { get; set; }
}
