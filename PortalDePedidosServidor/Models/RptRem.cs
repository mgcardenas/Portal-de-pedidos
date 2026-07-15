using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class RptRem
{
    public int IdRemito { get; set; }

    public string? TipoRemito { get; set; }

    public string? TextoTipoRem { get; set; }

    public string? NroCodigoRem { get; set; }

    public string? NroRemito { get; set; }

    public string? NroRemito2 { get; set; }

    public string? FechaRem { get; set; }

    public string? RazonSocRem { get; set; }

    public string? DirRem { get; set; }

    public string? LocalidadRem { get; set; }

    public string? ProvinciaRem { get; set; }

    public int? NroCliente { get; set; }

    public string? NombreCliente { get; set; }

    public string? DirCliente { get; set; }

    public string? DirCliente2 { get; set; }

    public string? LocalidadCliente { get; set; }

    public string? NroCarga { get; set; }

    public string? CodRuta { get; set; }

    public string? CodRutaDesc { get; set; }

    public string? NumTransportista { get; set; }

    public string? InsEntregar { get; set; }

    public string? InsEntregar2 { get; set; }

    public string? FechaIniAct { get; set; }

    public int? NroEntregar { get; set; }

    public string? NroSp { get; set; }

    public string? TipoNroPedido { get; set; }

    public int? NroPedido { get; set; }

    public string? OcCliente { get; set; }

    public string? AlmPlanta { get; set; }

    public string? TipoInterno { get; set; }

    public int? NroInterno { get; set; }

    public string? CatIva { get; set; }

    public string? DescTransp { get; set; }

    public string? NumPrincipal { get; set; }

    public string? NroCuit { get; set; }

    public string? NomChofer { get; set; }

    public string? DniChofer { get; set; }

    public string? Pat1 { get; set; }

    public string? Pat2 { get; set; }

    public string? CuitTransp { get; set; }

    public string? Idfiscal { get; set; }

    public string? CaiRemito { get; set; }

    public string? FechaVtoCai { get; set; }

    public string? Tara { get; set; }

    public string? Bruto { get; set; }

    public string? Neto { get; set; }

    public string? HoraEntrada { get; set; }

    public string? HoraSalida { get; set; }

    public int? HabilitarCampos { get; set; }

    public string? NroFactura { get; set; }
}
