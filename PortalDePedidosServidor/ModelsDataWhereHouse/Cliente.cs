using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.ModelsDataWhereHouse;

public partial class Cliente
{
    public string CodCia { get; set; } = null!;

    public long CodCliente { get; set; }

    public double LimiteCredito { get; set; }

    public string CodCondPagoReal { get; set; } = null!;

    public string CodAreaVenta { get; set; } = null!;

    public string CodTipoDeudor { get; set; } = null!;

    public string Cuit { get; set; } = null!;

    public string CodRubroCliente { get; set; } = null!;

    public string CodVendedor { get; set; } = null!;

    public string CodCondPago { get; set; } = null!;

    public string CodTipoCliente { get; set; } = null!;

    public string CodFleteEspecial { get; set; } = null!;

    public string ListaCliente { get; set; } = null!;

    public string FechaPrimeraFactura { get; set; } = null!;

    public string FechaCreacionRegistro { get; set; } = null!;

    public string UsuarioModificacion { get; set; } = null!;

    public string NombreFantasia { get; set; } = null!;

    public string NroIibb { get; set; } = null!;

    public string CertificadoExencionImpuestos { get; set; } = null!;

    public string Cc12 { get; set; } = null!;

    public string FechaInicioActividades { get; set; } = null!;

    public string? CodProvincia { get; set; }
}
