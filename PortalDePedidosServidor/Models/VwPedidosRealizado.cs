using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class VwPedidosRealizado
{
    public int Id { get; set; }

    public DateTime FechaPedido { get; set; }

    public string? NroCliente { get; set; }

    public string? Nombre { get; set; }

    public int TonPlt { get; set; }

    public int TonBol { get; set; }

    public int TonGra { get; set; }

    public string? Item { get; set; }

    public int? Cant { get; set; }

    public string? Observacion { get; set; }

    public DateTime? FechaEnvio { get; set; }

    public string? Cia { get; set; }

    public string? Area { get; set; }

    public int IdUsuario { get; set; }

    public string? Ruta { get; set; }

    public string? InfoOrigen { get; set; }
}
