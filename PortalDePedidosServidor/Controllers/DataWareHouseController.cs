using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalDePedidosModel;
using PortalDePedidosServidor.Models;
using PortalDePedidosServidor.ModelsDataWhereHouse;
using PortalDePedidosServidor.Servicios;
using PortalDePedidosShared.ArticulosVM;
using PortalDePedidosShared.DataWhereHouse;
using PortalDePedidosShared.FacturasVM;
using PortalDePedidosShared.IngresoPedidosVM;
using PortalDePedidosShared.RecibosVM;
using PortalDePedidosShared.SeguimientoPedidosVM;
using PortalDePedidosShared.UsuariosVM;
using PortalDePedidosShared.RemitosVM;
using PortalDePedidosShared.CuentasCorrientesVM;
using Microsoft.AspNetCore.Authorization;
using PortalDePedidosShared.ComprasAnticipadasPendientesVM;

namespace PortalDePedidosServidor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataWareHouseController : ControllerBase
    {
        private DataWareHouseService _dataWhereHouseService;
        private MailService _mailService;
        private LogService _logService;

        public DataWareHouseController(DataWareHouseService dataWhereHouseService, LogService logService, MailService mailService)
        {
            _dataWhereHouseService = dataWhereHouseService;
            _logService = logService;
            _mailService = mailService;
        }

        [HttpGet("EstadosPedido")]
        [Authorize]
        [ServiceFilter(typeof(BlacklistAuthorizationFilter))]
        public async Task<IActionResult> GetEstadosPedido()
        {
            Respuesta<List<string>> respuesta = new();
            try
            {
                respuesta.Data = await _dataWhereHouseService.GetEstadosPedido();
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }
            return Ok(respuesta);
        }

        [HttpGet("EstadosPedidoVentaAnticipada")]
        [Authorize]
        [ServiceFilter(typeof(BlacklistAuthorizationFilter))]
        public async Task<IActionResult> GetEstadosPedidoVentaAnticipada()
        {
            Respuesta<List<string>> respuesta = new();
            try
            {
                respuesta.Data = await _dataWhereHouseService.GetEstadosPedidoVentaAnticipada();
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }
            return Ok(respuesta);
        }

        [HttpPost("SeguimientoPedidos")]
        [Authorize][ServiceFilter(typeof(BlacklistAuthorizationFilter))] public async Task<IActionResult> GetSeguimientoPedidos(FiltroSeguimientoPedidos filtro)
        {
            Respuesta<List<SeguimientoPedidoVM>> respuesta = new();
            try
            {
                respuesta.Data = await _dataWhereHouseService.GetSeguimientoPedido(filtro);
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }
            return Ok(respuesta);
        }

        [HttpPost("SeguimientoPedidosVentasAnticipadas")]
        [Authorize]
        [ServiceFilter(typeof(BlacklistAuthorizationFilter))]
        public async Task<IActionResult> GetSeguimientoPedidosVentasAnticipadas(FiltroSeguimientoPedidos filtro)
        {
            Respuesta<List<SeguimientoPedidoVM>> respuesta = new();
            try
            {
                respuesta.Data = await _dataWhereHouseService.GetSeguimientoPedidoVentaAnticipada(filtro);
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }
            return Ok(respuesta);
        }

        [HttpPost("ComprasAnticipadasPendientes")]
        //[Authorize]
        //[ServiceFilter(typeof(BlacklistAuthorizationFilter))]
        public async Task<IActionResult> GetComprasAnticipadasPendientes(FiltroComprasAnticipadasPendientes filtro)
        {
            Respuesta<List<ComprasAnticipadasVM>> respuesta = new();
            try
            {
                respuesta.Data = await _dataWhereHouseService.GetComprasAnticipadasPendientes(filtro);
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }
            return Ok(respuesta);
        }

        [HttpPost("CuentasCorrientes")]
        [Authorize][ServiceFilter(typeof(BlacklistAuthorizationFilter))] public async Task<IActionResult> GetCuentasCorrientes([FromBody] FiltroCuentasCorrientesVM filtroCuentasCorrientesVM)
        {
            Respuesta<List<CuentaCorrienteVM>> respuesta = new();
            try
            {
                respuesta.Data = await _dataWhereHouseService.GetCuentasCorrientes(filtroCuentasCorrientesVM);
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }
            return Ok(respuesta);
        }
        [HttpPost("Remitos")]
        [Authorize][ServiceFilter(typeof(BlacklistAuthorizationFilter))] public async Task<IActionResult> GetRemitos([FromBody] FiltroRemitosVM filtroRemitosVM)
        {
            Respuesta<List<RemitoVM>> respuesta = new();
            try
            {
                respuesta.Data = await _dataWhereHouseService.GetRemitos(filtroRemitosVM);
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }
            return Ok(respuesta);
        }

        [HttpPost("Facturas")]
        [Authorize][ServiceFilter(typeof(BlacklistAuthorizationFilter))] public async Task<IActionResult> GetFacturas([FromBody] FiltroFacturasSP filtroFacturasSP)
        {
            Respuesta<List<FacturasSP>> respuesta = new();
            try
            {
                respuesta.Data = await _dataWhereHouseService.GetFacturas(filtroFacturasSP);
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }
            return Ok(respuesta);
        }

        [HttpPost("Recibos")]
        [Authorize][ServiceFilter(typeof(BlacklistAuthorizationFilter))] public async Task<IActionResult> GetRecibos([FromBody] FiltroRecibos filtro)
        {
            Respuesta<List<ReciboVM>> respuesta = new();
            try
            {
                respuesta.Data = await _dataWhereHouseService.GetRecibos(filtro);
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }
            return Ok(respuesta);
        }

        [HttpGet("Zonas")]
        [Authorize][ServiceFilter(typeof(BlacklistAuthorizationFilter))] public async Task<IActionResult> GetZona()
        {
            Respuesta<List<Zona>> respuesta = new();
            try
            {
                respuesta.Data = await _dataWhereHouseService.GetZonas();
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }
            return Ok(respuesta);
        }

        [HttpGet("Articulos")]
        [Authorize][ServiceFilter(typeof(BlacklistAuthorizationFilter))] public async Task<IActionResult> GetArticulos()
        {
            Respuesta<List<ArticuloVM>> respuesta = new();
            try
            {
                respuesta.Data = await _dataWhereHouseService.GetArticulos();
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }
            return Ok(respuesta);
        }


        [HttpGet("ArticulosIngreso")]
        [Authorize][ServiceFilter(typeof(BlacklistAuthorizationFilter))] 
        public async Task<IActionResult> GetArticulosIngreso()
        {
            Respuesta<List<ArticuloIngresoPedidoVM>> respuesta = new();
            try
            {
                respuesta.Data = await _dataWhereHouseService.GetArticulosIngreso();
                respuesta.Mensaje = respuesta.Data.Count().ToString();
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }
            return Ok(respuesta);
        }

        [HttpGet("RazonSocial")]
        [Authorize]
        [ServiceFilter(typeof(BlacklistAuthorizationFilter))]
        public async Task<IActionResult> GetRazonSocial()
        {
            Respuesta<List<RazonSocialVM>> respuesta = new();
            try
            {
                respuesta.Data = await _dataWhereHouseService.GetAllRazonSocial();
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }
            return Ok(respuesta);
        }

        [HttpPost("NroJDENoExiste")]
        [Authorize]
        [ServiceFilter(typeof(BlacklistAuthorizationFilter))]
        public async Task<IActionResult> NroJDENoExiste([FromBody] int nroJDE)
        {
            Respuesta<bool> respuesta = new();
            try
            {
                respuesta.Data = await _dataWhereHouseService.NroJDENoExiste(nroJDE);
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }
            return Ok(respuesta);
        }

        [HttpPost("ConsultaSaldoAFavor")]
        [Authorize]
        [ServiceFilter(typeof(BlacklistAuthorizationFilter))]
        public async Task<IActionResult> ConsultaSaldoAFavor([FromBody] ConsultaSaldoAFavor consulta)
        {
            Respuesta<bool> respuesta = new();
            try
            { 
                respuesta.Exito = await _mailService.EnviarMailConsulta(consulta);
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }
            return Ok(respuesta);
        }
    }
}
