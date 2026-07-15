using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class CategoriaItem
{
    public int IdCategoriaItem { get; set; }

    public string NombreCategoriaItem { get; set; } = null!;

    public int RegistroAnulado { get; set; }

    public virtual ICollection<SubcategoriaItem> SubcategoriaItems { get; set; } = new List<SubcategoriaItem>();
}
