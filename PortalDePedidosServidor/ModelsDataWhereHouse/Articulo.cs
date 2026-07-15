using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.ModelsDataWhereHouse;

public partial class Articulo
{
    public int CodCortoArticulo { get; set; }

    public string CodArticulo { get; set; } = null!;

    public string Descripcion1 { get; set; } = null!;

    public string Descripcion2 { get; set; } = null!;

    public string GrupoArticulo { get; set; } = null!;

    public string UmPrincipal { get; set; } = null!;

    public string UmSecundaria { get; set; } = null!;

    public string CodTipoArticulo { get; set; } = null!;

    public string? CodFamiliaProducto { get; set; }

    public string? CodSubFamiliaProducto { get; set; }

    public string? CodTipoEnvase { get; set; }

    public string? CodEan { get; set; }

    public string? TipoStock { get; set; }

    public string? BloqueoVenta { get; set; }
}
