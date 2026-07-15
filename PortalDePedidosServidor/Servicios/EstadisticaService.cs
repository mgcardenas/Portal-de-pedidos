using PortalDePedidosShared.EstadisticasVM;
using PortalDePedidosShared.RemitosVM;
using PortalDePedidosShared.SeguimientoPedidosVM;

namespace PortalDePedidosServidor.Servicios
{
    public class EstadisticaService
    {
        private DataWareHouseService _dataWareHouseService;

        public EstadisticaService(DataWareHouseService dataWareHouseService)
        {
            _dataWareHouseService = dataWareHouseService;
        }

        public async Task<EstadisticaProductoVM> GetEstadisticaProducto(FiltroEstadisticaProducto filtro)
        {
            var estadistica = new EstadisticaProductoVM();
            var remitos = await ObtenerRemitosEstadistica(filtro);
            estadistica.EstadisticasPorMes = CalcularEstadisticaPorMes(remitos, filtro.TipoProducto);             
            //estadistica.EstadisticasPorMes = GenerarEstadisticas(filtro);             
            estadistica.TipoProducto = filtro.TipoProducto;

            return estadistica;
        }

        private async Task<List<SeguimientoEstadisticaVM>> ObtenerSeguimientos(FiltroEstadisticaProducto filtro)
        {
            //busco seguimiento de pedidos de los ultimos 3 años
            var filtroSeguimiento = new FiltroSeguimientoPedidos()
            {
                CodCliente = int.Parse(filtro.CodCliente),
                FechaDesde = filtro.fechaDesde,
                FechaHasta = filtro.fechaHasta,
                Estado = "0"
            };

            return await _dataWareHouseService.GetSeguimientoEstadistica(filtroSeguimiento);
        }

        private async Task<List<RemitoEstadisticaVM>> ObtenerRemitosEstadistica(FiltroEstadisticaProducto filtro)
        {
            //busco seguimiento de pedidos de los ultimos 3 años
            var filtroRemitos = new FiltroRemitoEstadistica()
            {
                CodCliente = int.Parse(filtro.CodCliente),
                FechaDesde = filtro.fechaDesde,
                FechaHasta = filtro.fechaHasta,
            };

            return await _dataWareHouseService.GetRemitosEstadistica(filtroRemitos);
        }

        private List<EstadisticaPorMes> CalcularEstadisticaPorMes(List<RemitoEstadisticaVM> seguimientos,TipoEstadisticaProducto tipoProducto)
        {
            var estadisticasPorMes = new List<EstadisticaPorMes>();
            var seguimientosPorAnio = seguimientos.GroupBy(x => x.FechaOrden.Year).ToList();
            foreach (var seguimientoPorAnio in seguimientosPorAnio)
            {
                var seguimientosPorMes = seguimientoPorAnio.GroupBy(x=> x.FechaOrden.Month).ToList();
                foreach(var seguimientoPorMes in seguimientosPorMes)
                {
                    var estadistica = new EstadisticaPorMes();
                    estadistica.Anio = seguimientoPorAnio.Key;
                    estadistica.Mes = seguimientoPorMes.Key;
                    estadistica.Cantidad = 0;

                    foreach(var seguimiento in seguimientoPorMes)
                    {
                        if(seguimiento.Articulo != null)
                        {
                            switch (tipoProducto)
                            {
                                case TipoEstadisticaProducto.Adoquines:
                                    if (seguimiento.Articulo.Categoria == "MAMPUESTOS" && (seguimiento.Articulo.CodTipoArticulo == "ADO" || seguimiento.Articulo.CodTipoArticulo == ""))
                                    {
                                        estadistica.Cantidad += (decimal)seguimiento.CantEnviada;
                                    }
                                    break;
                                case TipoEstadisticaProducto.Adhesivos:
                                    if (seguimiento.Articulo.Categoria == "ADHESIVOS")
                                    {
                                        estadistica.Cantidad += (decimal)seguimiento.CantEnviada;
                                    }
                                    break;
                                case TipoEstadisticaProducto.B20Q:
                                    if(seguimiento.Articulo.CodArticulo == "B20Q")
                                    {
                                        estadistica.Cantidad += (decimal)seguimiento.CantEnviada;
                                    }
                                    break;
                                case TipoEstadisticaProducto.CementoBolsas:
                                    if (seguimiento.Articulo.SubCategoria == "Bolsas")
                                    {
                                        estadistica.Cantidad += (decimal)seguimiento.CantEnviada;
                                    }
                                    break;
                                case TipoEstadisticaProducto.CementoCaltex:
                                    if (seguimiento.Articulo.Categoria == "CEMENTOS" && seguimiento.Articulo.SubCategoria != "Bolsas")
                                    {
                                        estadistica.Cantidad += (decimal)seguimiento.CantEnviada;
                                    }
                                    break;
                                case TipoEstadisticaProducto.Viguetas:
                                    if (seguimiento.Articulo.Categoria == "VIGUETAS")
                                    {
                                        var mtsXun = seguimiento.Articulo.unidades.Where(x => x.Umorigen == "UN" && x.Umdestino == "MT").SingleOrDefault();
                                        if (mtsXun != null)
                                        {
                                            estadistica.Cantidad += ((decimal) seguimiento.CantEnviada) * ((decimal) mtsXun.FactorConversion);
                                        }
                                    }
                                    break;
                            }
                        }
                        
                    }
                    estadistica.Cantidad = Math.Round(estadistica.Cantidad, 2);
                    estadisticasPorMes.Add(estadistica);
                }
            }

            return estadisticasPorMes.OrderBy(x=> x.Anio).ToList();
        }
        //private List<EstadisticaPorAnio> CalcularEstadisticaPorAnio(List<EstadisticaPorMes> estadisticaPorMes)
        //{
        //    var estadisticasPorAnio= new List<EstadisticaPorAnio>();
        //    var estadisticaPorMesAgrupadasPorAnio= estadisticaPorMes.GroupBy(x=> x.Anio).ToList();


        //    foreach (var mesesDeUnAnio in estadisticaPorMesAgrupadasPorAnio)
        //    {
        //        var datoAnio = new EstadisticaPorAnio();
        //        datoAnio.Anio = mesesDeUnAnio.Key;

        //        foreach (var datoMes in mesesDeUnAnio)
        //        {

        //            switch (datoMes.Mes)
        //            {
        //                case 1:
        //                    datoAnio.Enero = datoMes.Cantidad;
        //                    break;
        //                case 2:
        //                    datoAnio.Febrero = datoMes.Cantidad;
        //                    break;
        //                case 3:
        //                    datoAnio.Marzo = datoMes.Cantidad;
        //                    break;
        //                case 4:
        //                    datoAnio.Abril = datoMes.Cantidad;
        //                    break;
        //                case 5:
        //                    datoAnio.Mayo = datoMes.Cantidad;
        //                    break;
        //                case 6:
        //                    datoAnio.Junio = datoMes.Cantidad;
        //                    break;
        //                case 7:
        //                    datoAnio.Julio = datoMes.Cantidad;
        //                    break;
        //                case 8:
        //                    datoAnio.Agosto = datoMes.Cantidad;
        //                    break;
        //                case 9:
        //                    datoAnio.Septiembre = datoMes.Cantidad;
        //                    break;
        //                case 10:
        //                    datoAnio.Octubre = datoMes.Cantidad;
        //                    break;
        //                case 11:
        //                    datoAnio.Noviembre = datoMes.Cantidad;
        //                    break;
        //                case 12:
        //                    datoAnio.Diciembre = datoMes.Cantidad;
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }

        //        estadisticasPorAnio.Add(datoAnio);
        //    }
        //    return estadisticasPorAnio;
        //}

        public List<EstadisticaPorMes> GenerarEstadisticas(FiltroEstadisticaProducto filtro)
        {
            var estadisticas = new List<EstadisticaPorMes>();
            DateTime fechaActual = filtro.fechaHasta;
            DateTime fechaInicio = filtro.fechaDesde;

            Random random = new Random();

            for (DateTime fecha = fechaInicio; fecha <= fechaActual; fecha = fecha.AddMonths(1))
            {
                var x = (decimal)(random.NextDouble() * (5000 - 1000) + 1000);
                estadisticas.Add(new EstadisticaPorMes
                {
                    Mes = fecha.Month,
                    Anio = fecha.Year,
                    Cantidad = Math.Round(x, 2)
                });
            }

            return estadisticas.OrderBy(x => x.Anio).ToList() ;
        }

    }
}
