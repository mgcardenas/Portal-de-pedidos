using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class FacturasEnviada
{
    public DateTime FechaDeEnvío { get; set; }

    public DateTime? FechaDeFactura { get; set; }

    public string? CentroCosto { get; set; }

    public string? NroFactura { get; set; }

    public string? TipoDePedido { get; set; }

    public int NroPedido { get; set; }

    public int NroCliente { get; set; }

    public string? NombreCliente { get; set; }

    public string EnviadoA { get; set; } = null!;

    public string? EnviadoCc { get; set; }

    public string? NroRemito { get; set; }

    public string? TipoInterno { get; set; }

    public int NroInterno { get; set; }
}
