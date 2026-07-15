using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class EventosSesion
{
    public int IdEvento { get; set; }

    public short TipoEvento { get; set; }

    public short IdUsuario { get; set; }

    public DateTime FechaHora { get; set; }

    public short CantUsrConectados { get; set; }

    public short IdUsuarioPerfil { get; set; }

    public short? CantSesiones { get; set; }
}
