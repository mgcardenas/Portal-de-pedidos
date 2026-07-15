using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class VwUdc
{
    public string CodProducto { get; set; } = null!;

    public string CodUsuario { get; set; } = null!;

    public string Valor { get; set; } = null!;

    public string Descripcion1 { get; set; } = null!;

    public string Descripcion2 { get; set; } = null!;

    public string GestionEspecial { get; set; } = null!;

    public string CodificacionFija { get; set; } = null!;
}
