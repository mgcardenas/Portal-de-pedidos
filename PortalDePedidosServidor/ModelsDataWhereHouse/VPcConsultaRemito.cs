using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.ModelsDataWhereHouse;

public partial class VPcConsultaRemito
{
    public int? CodCliente { get; set; }

    public string TipoDoc { get; set; } = null!;

    public int NroDoc { get; set; }

    public string? FechaOrden { get; set; }

    public string? FechaEnvio { get; set; }

    public string? CodArticulo { get; set; }

    public decimal? CantEnviada { get; set; }

    public long CodTransportista { get; set; }

    public string? Transportista { get; set; }

    public string NroRemito { get; set; } = null!;

    public string? NombreArchivoRemito { get; set; }
}
