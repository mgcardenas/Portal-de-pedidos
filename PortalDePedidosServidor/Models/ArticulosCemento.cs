using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class ArticulosCemento
{
    public int CodCortoArticulo { get; set; }

    public string CodArticulo { get; set; } = null!;

    public string Descripcion1 { get; set; } = null!;

    public string? Descripcion2 { get; set; }

    public string? GrupoArticulo { get; set; }

    public string? UmPrincipal { get; set; }

    public string UmSecundaria { get; set; } = null!;

    public string CodTipoArticulo { get; set; } = null!;

    public string? CodFamiliaProducto { get; set; }

    public string? CodSubFamiliaProducto { get; set; }

    public string? CodTipoEnvase { get; set; }

    public string? CodEan { get; set; }

    public int? CodPlanta { get; set; }

    public string? BloqueoVenta { get; set; }

    public string? SubCategoriaCemento { get; set; }

    public int? ImagenId { get; set; }

    public string? ImagenContenido { get; set; }

    public string? Agrupacion1 { get; set; }
}
