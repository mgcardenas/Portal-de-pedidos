using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.ModelsDataWhereHouse;

public partial class ArticulosAlmacene
{
    public string CodArticulo { get; set; } = null!;

    public string Almacen { get; set; } = null!;

    public string CodCategoria1 { get; set; } = null!;

    public string CodCategoria2 { get; set; } = null!;

    public string CodClasificacionMercancia { get; set; } = null!;
}
