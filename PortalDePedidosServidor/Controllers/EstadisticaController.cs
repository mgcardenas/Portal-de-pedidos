using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalDePedidosModel;
using PortalDePedidosServidor.Servicios;
using PortalDePedidosShared.DataWhereHouse;
using PortalDePedidosShared.EstadisticasVM;
using PortalDePedidosShared.FacturasVM;

namespace PortalDePedidosServidor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadisticaController : ControllerBase
    {
        private EstadisticaService _estadisticaService;
        private LogService _logService;

        public EstadisticaController(EstadisticaService estadisticaService, LogService logService)
        {
            _estadisticaService = estadisticaService;
            _logService = logService;
        }

        //[HttpGet("EstadisticaArticuloPrueba")]
        //[Authorize][ServiceFilter(typeof(BlacklistAuthorizationFilter))] public async Task<IActionResult> EstadisticaArticuloPrueba()
        //{
        //    Respuesta<EstadisticaProductoVM> respuesta = new();
        //    try
        //    {
        //        FiltroEstadisticaProducto filtro = new()
        //        {
        //            CodCliente = "12901172",
        //            TipoProducto = TipoEstadisticaProducto.CementoBolsas,
        //        };
        //        respuesta.Data = await _estadisticaService.GetEstadisticaProducto(filtro);
        //        respuesta.Exito = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logService.WriteLogException(ex);
        //        respuesta.Data = new();
        //    }
        //    return Ok(respuesta);
        //}

        [HttpPost("EstadisticaArticulo")]
        [Authorize][ServiceFilter(typeof(BlacklistAuthorizationFilter))] public async Task<IActionResult> EstadisticaArticulo([FromBody] FiltroEstadisticaProducto filtro)
        {
            Respuesta<EstadisticaProductoVM> respuesta = new();
            try
            {
                respuesta.Data = await _estadisticaService.GetEstadisticaProducto(filtro);
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }
            return Ok(respuesta);
        }
    }
}
