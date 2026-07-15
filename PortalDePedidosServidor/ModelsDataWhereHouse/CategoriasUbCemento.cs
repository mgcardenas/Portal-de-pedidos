using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.ModelsDataWhereHouse;

public partial class CategoriasUbCemento
{
    public string Ceco { get; set; } = null!;

    public string? CuentaObjeto { get; set; }

    public string SubCuenta { get; set; } = null!;

    public string? Planta { get; set; }

    public string? SubNegocio { get; set; }

    public string? Concepto { get; set; }

    public string? CodigoTipoPremoldeado { get; set; }

    public string? TipoPremoldeado { get; set; }

    public string Area { get; set; } = null!;
}
