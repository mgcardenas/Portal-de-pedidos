using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.ModelsDataWhereHouse;

public partial class VPcSeguimientoPedido
{
    public int? CodCliente { get; set; }

    public string TipoDoc { get; set; } = null!;

    public int NroDoc { get; set; }

    public string? FechaOrden { get; set; }

    public string? CodArticulo { get; set; }

    public decimal? CantEnviada { get; set; }

    public long CodTransportista { get; set; }

    public string? Transportista { get; set; }

    public string? Estado { get; set; }

    public long? NroDocEdi { get; set; }

    public string? NroRemito { get; set; }

    public DateOnly? FechaEntrega { get; set; }
}
