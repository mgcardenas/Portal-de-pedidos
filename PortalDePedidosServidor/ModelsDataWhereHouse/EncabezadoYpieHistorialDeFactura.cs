using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.ModelsDataWhereHouse;

public partial class EncabezadoYpieHistorialDeFactura
{
    public string? CiaDoc { get; set; }

    public string? TipoDoc { get; set; }

    public int? NroDoc { get; set; }

    public string? NroFacturaLegal { get; set; }

    public string? Descripcion1 { get; set; }

    public string? CuitEmisor { get; set; }

    public string? CiaOrden { get; set; }

    public string? TipoOrden { get; set; }

    public int? NroOrden { get; set; }

    public string? CentroEmisor { get; set; }
}
