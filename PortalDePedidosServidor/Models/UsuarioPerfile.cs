using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class UsuarioPerfile
{
    public int IdUsuarioPerfil { get; set; }

    public int IdUsuario { get; set; }

    public string NombrePerfil { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public byte PerfilPedidos { get; set; }

    public byte PerfilCuentaC { get; set; }

    public byte PerfilAdmPerfiles { get; set; }

    public DateTime? FechaUltimaVisita { get; set; }

    public byte? RegistroAnulado { get; set; }
}
