using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class FacturasProcesada
{
    public int Id { get; set; }

    public int NroPedido { get; set; }

    public string? TipoPedido { get; set; }

    public DateTime FechaProcesada { get; set; }

    public int NroCliente { get; set; }

    public string? NombreCliente { get; set; }
}
