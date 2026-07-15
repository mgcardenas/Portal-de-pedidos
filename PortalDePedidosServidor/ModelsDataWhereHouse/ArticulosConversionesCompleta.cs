using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.ModelsDataWhereHouse;

public partial class ArticulosConversionesCompleta
{
    public long? CodArticuloCorto { get; set; }

    public string? Umorigen { get; set; }

    public string? Umdestino { get; set; }

    public double? FactorConversion { get; set; }
}
