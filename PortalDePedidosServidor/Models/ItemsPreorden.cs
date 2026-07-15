using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class ItemsPreorden
{
    public int IdItemPreorden { get; set; }

    public string CodItem { get; set; } = null!;

    public int? IdSubcategoriaItem { get; set; }

    public string NombreItem { get; set; } = null!;

    public string? UrlImagen { get; set; }

    public int IdUnidadItem { get; set; }

    public int MinimoUnidades { get; set; }

    public int CantPorUnidad { get; set; }

    public decimal? PesoUnidad { get; set; }

    public short? LocacionItem { get; set; }

    public short? AlmacenItem { get; set; }

    public int RegistroAnulado { get; set; }

    public virtual SubcategoriaItem? IdSubcategoriaItemNavigation { get; set; }

    public virtual UnidadItem IdUnidadItemNavigation { get; set; } = null!;
}
