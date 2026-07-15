using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.ModelsDataWhereHouse;

public partial class OrdenVentum
{
    public string CiaDoc { get; set; } = null!;

    public int NroDoc { get; set; }

    public string TipoDoc { get; set; } = null!;

    public int LinDoc { get; set; }

    public string? ExtDoc { get; set; }

    public string? Ceco { get; set; }

    public string? CiaDocOrig { get; set; }

    public string? NroDocOrig { get; set; }

    public string? TipoDocOrig { get; set; }

    public int? LinDocOrig { get; set; }

    public int? NroProveedor { get; set; }

    public int? NroDestino { get; set; }

    public string? FechaOrden { get; set; }

    public string? FechaCancel { get; set; }

    public string? FechaLm { get; set; }

    public int? Itm { get; set; }

    public string? Litm { get; set; }

    public string? Desc1 { get; set; }

    public string? Desc2 { get; set; }

    public string? TipoLin { get; set; }

    public string? EstSig { get; set; }

    public string? EstUlt { get; set; }

    public string? Um { get; set; }

    public decimal? CantPedida { get; set; }

    public decimal? CantEnviada { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public decimal? PrecioTotal { get; set; }

    public short? Año { get; set; }

    public short? Siglo { get; set; }

    public decimal? CantPendiente { get; set; }

    public string? Moneda { get; set; }

    public decimal? TipoCambio { get; set; }

    public decimal? PrecioUnitarioMe { get; set; }

    public decimal? PrecioTotalMe { get; set; }

    public string? UsuOriginador { get; set; }

    public string? UsuModif { get; set; }

    public string? FechaUltModif { get; set; }

    public int? CodCortoArticulo { get; set; }

    public string? CodArticulo { get; set; }

    public string? FechaEnvio { get; set; }

    public string? CodTipoEnvase { get; set; }

    public string? CodRuta { get; set; }

    public int? CodCliente { get; set; }

    public double? PesoNt { get; set; }

    public string? NroRemito { get; set; }

    public string? FechaFactura { get; set; }

    public string? NroFactura { get; set; }

    public string? TipoDocContable { get; set; }

    public long? NroDocContable { get; set; }

    public short? CondPago { get; set; }

    public long CodTransportista { get; set; }

    public long DniChofer { get; set; }

    public string PatenteCamion { get; set; } = null!;

    public string PatenteSemi { get; set; } = null!;

    public byte CodTipoFlete { get; set; }

    public string CodClaseEnvio { get; set; } = null!;

    public string? GrupoPrecios { get; set; }

    public string? CiaOrdenRelacionada { get; set; }

    public string? TipoOrdenRelacionada { get; set; }

    public string? NroOrdenRelacionada { get; set; }

    public int? LineaOrdenRelacionada { get; set; }

    public string? Zona { get; set; }

    public bool? CargaManual { get; set; }

    public string? CodigoCosto { get; set; }
}
