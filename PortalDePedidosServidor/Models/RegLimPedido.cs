using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class RegLimPedido
{
    public int IdRegLimPedido { get; set; }

    public int IdEstado { get; set; }

    public int? IdPedido { get; set; }

    public int NroCliente { get; set; }

    public DateTime Fecha { get; set; }

    public decimal? TotalCemPed { get; set; }

    public string? Limites { get; set; }

    public decimal? TotalActual { get; set; }

    public decimal? CantDespachada { get; set; }

    public string? Despachos { get; set; }

    public decimal? CantPedidos { get; set; }

    public decimal? CantSopend { get; set; }

    public string? Sopend { get; set; }

    public decimal? CantSppend { get; set; }

    public string? Sppend { get; set; }
}
