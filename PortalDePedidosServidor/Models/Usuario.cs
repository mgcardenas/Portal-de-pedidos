using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class Usuario
{
    public short IdUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string PasswordUsuario { get; set; } = null!;

    public DateTime FechaUltimaVisita { get; set; }

    public string UsuarioOracle { get; set; } = null!;

    public string? MailUsuario { get; set; }

    public string? CodZona { get; set; }

    public int? HabilitadoEnvioRecibos { get; set; }

    public int? HabilitadoEnvioMail { get; set; }

    public short? HabilitadoPedidos { get; set; }

    public int? AreaVenta { get; set; }

    public short? CargaInstEntrega { get; set; }

    public short? BloquearConfFlete { get; set; }

    public short? ConfigFlete { get; set; }

    public byte RegistroAnulado { get; set; }

    public int? IdRol { get; set; }

    public DateTime? FechaUltimaContrasena { get; set; }

    public string? Moneda { get; set; }

    public virtual ICollection<Auditoria> Auditoria { get; set; } = new List<Auditoria>();

    public virtual Rol? IdRolNavigation { get; set; }
}
