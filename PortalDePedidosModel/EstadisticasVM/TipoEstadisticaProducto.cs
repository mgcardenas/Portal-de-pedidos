using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosShared.EstadisticasVM
{
    public enum TipoEstadisticaProducto
    {
        Viguetas = 1,
        Adoquines = 2,
        B20Q = 3,
        CementoBolsas = 4,
        CementoCaltex = 5,
        Adhesivos = 6,
    }

    public class TipoEstadisticaProductoManager()
    {
        public static string GetEtiqueta(TipoEstadisticaProducto tipo)
        {
            switch (tipo)
            {
                case TipoEstadisticaProducto.Adoquines:
                    return "Adoquines";
                    break;
                case TipoEstadisticaProducto.Adhesivos:
                    return "Adhesivos";
                    break;
                case TipoEstadisticaProducto.B20Q:
                    return "B20Q - BLOQUE LISO PORTANTE 19X19X39";
                    break;
                case TipoEstadisticaProducto.CementoBolsas:
                    return "Cemento - Bolsas";
                    break;
                case TipoEstadisticaProducto.CementoCaltex:
                    return "Cemento - Caltex";
                    break;
                case TipoEstadisticaProducto.Viguetas:
                    return "Viguetas";
                    break;
                    default:
                    return "";
                    break;
            }
        }

        public static string GetUnidad(TipoEstadisticaProducto tipo)
        {
            switch (tipo)
            {
                case TipoEstadisticaProducto.Adoquines:
                    return "Unidades";
                    break;
                case TipoEstadisticaProducto.Adhesivos:
                    return "Bolsas";
                    break;
                case TipoEstadisticaProducto.B20Q:
                    return "Unidades";
                    break;
                case TipoEstadisticaProducto.CementoBolsas:
                    return "Bolsas";
                    break;
                case TipoEstadisticaProducto.CementoCaltex:
                    return "Toneladas";
                    break;
                case TipoEstadisticaProducto.Viguetas:
                    return "Metros";
                    break;
                default:
                    return "";
                    break;
            }
        }

    }
}
