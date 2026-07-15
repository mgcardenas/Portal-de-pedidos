using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class ImpresionFactura
{
    public int IdFactura { get; set; }

    public string TipoFactura { get; set; } = null!;

    public string? TextoTipoFac { get; set; }

    public string? NroFactura { get; set; }

    public string? NroFactura2 { get; set; }

    public int? FechaFac { get; set; }

    public string? RazonSocFac { get; set; }

    public string? DirFac { get; set; }

    public string? LocalidadFac { get; set; }

    public string? ProvinciaFac { get; set; }

    public int NroCliente { get; set; }

    public string? NombreCliente { get; set; }

    public string? DirCliente { get; set; }

    public string? Dir2Cliente { get; set; }

    public string? LocalidadCliente { get; set; }

    public string? CondVtaCli { get; set; }

    public string? InstEntrega { get; set; }

    public string? InstEntrega2 { get; set; }

    public int? FechaIniAct { get; set; }

    public int? NroEntregar { get; set; }

    public string? TipoNroPedido { get; set; }

    public int? NroPedido { get; set; }

    public string? OcCliente { get; set; }

    public string? AlmPlanta { get; set; }

    public string? Subledger { get; set; }

    public string? TipoInterno { get; set; }

    public int? NroInterno { get; set; }

    public string? CatIva { get; set; }

    public string? CondVtaFac { get; set; }

    public int? FecVtoFac { get; set; }

    public string? NroCuil { get; set; }

    public string? NroIibb { get; set; }

    public string? NroRemito { get; set; }

    public string? ListaPrecio { get; set; }

    public string? MonedaFac { get; set; }

    public float? TipoCambio { get; set; }

    public float? TotalFac { get; set; }

    public string? Compania { get; set; }

    public string? AbrevMoneda { get; set; }

    public string? CaiFac { get; set; }

    public int? FecVtoCai { get; set; }
}
