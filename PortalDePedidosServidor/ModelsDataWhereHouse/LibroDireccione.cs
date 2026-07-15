using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.ModelsDataWhereHouse;

public partial class LibroDireccione
{
    public int CodLibroDireccion { get; set; }

    public string RazonSocial { get; set; } = null!;

    public string Cuit { get; set; } = null!;

    public string Clasificacion { get; set; } = null!;

    public string Categoria5 { get; set; } = null!;

    public string TipoSuministro { get; set; } = null!;

    public string ClasificacionIndustria { get; set; } = null!;

    public DateOnly? FechaAperturaCuenta { get; set; }

    public double LimiteCredito { get; set; }

    public string? UsuarioUltimaModificacion { get; set; }

    public string? CentroCosto { get; set; }

    public string? CompaniaCentroCosto { get; set; }

    public string? Cc30 { get; set; }

    public string? Cc24 { get; set; }

    public string? Cc26 { get; set; }

    public DateOnly? FechaUltimaModificacion { get; set; }

    public string? Categoria1 { get; set; }
}
