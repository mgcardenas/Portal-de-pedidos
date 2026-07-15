using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class RptRec
{
    public int IdRecibo { get; set; }

    public string IdCliente { get; set; } = null!;

    public string FechaRecibo { get; set; } = null!;

    public string NroRecibo { get; set; } = null!;

    public string? NombreCliente { get; set; }

    public string? NombreCompaniaRec { get; set; }

    public string? Dato1CompaniaRec { get; set; }

    public string? Dato2CompaniaRec { get; set; }

    public string? Dato3CompaniaRec { get; set; }

    public string? DirCliente { get; set; }

    public string? DirCliente2 { get; set; }

    public string? NroCuitCliente { get; set; }

    public string? CondVtaCliente { get; set; }

    public string? MonedaRec { get; set; }

    public string TotalRecibo { get; set; } = null!;

    public string TotalReciboTexto { get; set; } = null!;
}
