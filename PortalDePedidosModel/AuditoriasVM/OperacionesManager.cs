using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.AuditoriasVM
{
    public static class OperacionesManager
    {
        public static int GetIdOperacion(Operacion operacion)
        {
            switch (operacion)
            {
                case Operacion.AltaUsuario: return ((int)Operacion.AltaUsuario);
                    break;
                case Operacion.EditarUsuario: return ((int)Operacion.EditarUsuario);
                    break;
                case Operacion.IngresoPedido:
                    return ((int)Operacion.IngresoPedido);
                    break;
                case Operacion.EditarArticulo:
                    return ((int)Operacion.EditarArticulo);
                    break;
                    default:return -1;
            }
        }
    }

    public enum Operacion
    {
        AltaUsuario=1,
        EditarUsuario=2,
        IngresoPedido=3,
        EditarArticulo=4,
    }
}
