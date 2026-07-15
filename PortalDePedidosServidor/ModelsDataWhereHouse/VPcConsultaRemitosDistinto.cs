using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.ModelsDataWhereHouse;

public partial class VPcConsultaRemitosDistinto
{
    public int? CodCliente { get; set; }

    public DateOnly? FechaEnvio { get; set; }

    public string NroRemito { get; set; } = null!;

    public string? NombreArchivoRemito { get; set; }
}
