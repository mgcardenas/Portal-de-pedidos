using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.UsuariosVM
{
    public static class PermisosManager
    {
        public static Permisos GetPermiso(int id)
        {
            switch (id)
            {
                case 1: return Permisos.Configuracion;
                case 2: return Permisos.Pedidos;
                case 3: return Permisos.FacturasYRemitos;
                case 4: return Permisos.Estadisticas;
                default: return Permisos.Nulo;
            }
        }

    }
    public enum Permisos
    {
        //Se corresponden con los ids en la tabla Permisos
        Nulo = 0,
        Configuracion = 1,
        Pedidos = 2,
        FacturasYRemitos = 3,
        Estadisticas = 4
    }
}
