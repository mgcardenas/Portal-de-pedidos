using System;
using System.Collections.Generic;

namespace PortalDePedidosServidor.Models;

public partial class RolPermiso
{
    public int IdRolPermisos { get; set; }

    public int IdRol { get; set; }

    public int IdPermiso { get; set; }

    public virtual Permiso IdPermisoNavigation { get; set; } = null!;

    public virtual Rol IdRolNavigation { get; set; } = null!;
}
