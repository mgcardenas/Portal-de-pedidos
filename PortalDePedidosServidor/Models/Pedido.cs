using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public DateTime FechaPedido { get; set; }

    public int IdUsuario { get; set; }

    public int TonPlt { get; set; }

    public int TonBol { get; set; }

    public int TonGra { get; set; }

    public string? ObservacionPedido { get; set; }

    public DateTime? FechaEnvio { get; set; }

    public string? Doc { get; set; }

    public string? Dct { get; set; }

    public string? Kco { get; set; }

    public string? Dst { get; set; }

    public string? An8 { get; set; }

    public string? Mcu { get; set; }

    public string? Cars { get; set; }

    public string? Orby { get; set; }

    public string? Lob { get; set; }

    public string? CodZona { get; set; }

    public int? ModoTransporte { get; set; }

    public string? InfoOrigen { get; set; }

    public int RegistroAnulado { get; set; }

    public virtual ICollection<PedidoHijo> PedidoHijos { get; set; } = new List<PedidoHijo>();
}
