using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class RptFac
{
    public int IdFactura { get; set; }

    public string? TipoFactura { get; set; }

    public string? TextoTipoFac { get; set; }

    public string? NroCodigoFac { get; set; }

    public string? NroFactura { get; set; }

    public string? NroFactura2 { get; set; }

    public string? CodBarra { get; set; }

    public string? FechaFac { get; set; }

    public string? RazonSocFac { get; set; }

    public string? DirFac { get; set; }

    public string? LocalidadFac { get; set; }

    public string? ProvinciaFac { get; set; }

    public int? NroCliente { get; set; }

    public string? NombreCliente { get; set; }

    public string? DirCliente { get; set; }

    public string? DirCliente2 { get; set; }

    public string? LocalidadCliente { get; set; }

    public string? CondVtaCli { get; set; }

    public string? InsEntregar { get; set; }

    public string? InsEntregar2 { get; set; }

    public string? FechaIniAct { get; set; }

    public int? NroEntregar { get; set; }

    public string? NroSp { get; set; }

    public string? TipoNroPedido { get; set; }

    public int? NroPedido { get; set; }

    public string? OcCliente { get; set; }

    public string? AlmPlanta { get; set; }

    public string? Subledger { get; set; }

    public string? TipoInterno { get; set; }

    public int? NroInterno { get; set; }

    public string? CatIva { get; set; }

    public string? CondVtaFac { get; set; }

    public string? FecVtoFac { get; set; }

    public string? NroCuit { get; set; }

    public string? NroIibb { get; set; }

    public string? NroRemito { get; set; }

    public string? ListaPrecio { get; set; }

    public string? MonedaFac { get; set; }

    public string? TipoCambio { get; set; }

    public string? TotalFactura { get; set; }

    public string? CaiFactura { get; set; }

    public string? FechaVtoCai { get; set; }

    public string? Compania { get; set; }

    public string? AbrevMoneda { get; set; }

    public DateTime? FechaCreacionRegistro { get; set; }
}
