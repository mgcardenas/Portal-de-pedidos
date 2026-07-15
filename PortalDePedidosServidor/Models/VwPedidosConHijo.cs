using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class VwPedidosConHijo
{
    public int NroPedido { get; set; }

    public string? NombreUsuario { get; set; }

    public string? NroCliente { get; set; }

    public string? CodItem { get; set; }

    public int? CantSolicitada { get; set; }

    public int? CantPorUnidad { get; set; }

    public int? Total { get; set; }

    public string? Observaciones { get; set; }

    public string? Planta { get; set; }

    public string? ZonaDestino { get; set; }

    public int? ModoTransporte { get; set; }

    public int TonPlt { get; set; }

    public int TonBol { get; set; }

    public int TonGra { get; set; }

    public DateTime? FechaEnvio { get; set; }
}
