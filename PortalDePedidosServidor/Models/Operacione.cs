using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class Operacione
{
    public int IdOperacion { get; set; }

    public string Operacion { get; set; } = null!;

    public virtual ICollection<Auditoria> Auditoria { get; set; } = new List<Auditoria>();
}
