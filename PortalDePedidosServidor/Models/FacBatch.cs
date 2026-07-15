using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class FacBatch
{
    public int Id { get; set; }

    public string CodCliente { get; set; } = null!;

    public DateTime? FechaFac { get; set; }

    public string TipoDoc { get; set; } = null!;

    public string NroDoc { get; set; } = null!;

    public string TipoDocContable { get; set; } = null!;

    public string NroDocContable { get; set; } = null!;
}
