using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class Auditoria
{
    public int Id { get; set; }

    public short? IdUsuario { get; set; }

    public int? IdOperacion { get; set; }

    public DateTime? Timestamps { get; set; }

    public virtual Operacione? IdOperacionNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
