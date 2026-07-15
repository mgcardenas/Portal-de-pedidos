using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class SubcategoriaItem
{
    public int IdSubcategoriaItem { get; set; }

    public int IdCategoriaItem { get; set; }

    public string NombreSubcategoriaItem { get; set; } = null!;

    public int RegistroAnulado { get; set; }

    public virtual CategoriaItem IdCategoriaItemNavigation { get; set; } = null!;

    public virtual ICollection<ItemsPreorden> ItemsPreordens { get; set; } = new List<ItemsPreorden>();
}
