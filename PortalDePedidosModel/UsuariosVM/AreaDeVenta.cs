using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.UsuariosVM
{
    public static class AreaDeVentaManager
    {
        public static AreaDeVenta GetAreaDeVenta(int? areaId)
        {
            switch (areaId)
            {
                case 1: return AreaDeVenta.ComodoroRivadavia;
                case 2: return AreaDeVenta.PicoTruncado;
                default: return AreaDeVenta.Nulo;
            }
        }

        public static int GetIntAreaDeVenta(AreaDeVenta? adv)
        {
            switch (adv)
            {
                case AreaDeVenta.ComodoroRivadavia: return 1;
                case AreaDeVenta.PicoTruncado: return 2;
                default: return 0;
            }
        }
    }
    public enum AreaDeVenta
    {
        Nulo = 0,
        ComodoroRivadavia = 1,
        PicoTruncado = 2
    }
}
