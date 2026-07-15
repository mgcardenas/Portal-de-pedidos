using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class VwListadoArticulosVigente
{
    public int IdItemPreorden { get; set; }

    public string CodItem { get; set; } = null!;

    public string NombreItem { get; set; } = null!;

    public string? NombreSubcategoriaItem { get; set; }
}
