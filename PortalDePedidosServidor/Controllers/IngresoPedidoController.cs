using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalDePedidosModel;
using PortalDePedidosServidor.Servicios;
using PortalDePedidosShared.IngresoPedidosVM;
using PortalDePedidosShared.UsuariosVM;

namespace PortalDePedidosServidor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngresoPedidoController : ControllerBase
    {
        private IngresoPedidoService _ingresoPedidoService { get; set; }
        private LogService _logService { get; set; }

        public IngresoPedidoController(IngresoPedidoService ingresoPedidoService, LogService logService)
        {
            _ingresoPedidoService = ingresoPedidoService;
            _logService = logService;
        }

        [HttpPost]
        [Authorize][ServiceFilter(typeof(BlacklistAuthorizationFilter))] public async Task<IActionResult> Post([FromBody] IngresoPedidoVM ingresoPedido)
        {
            Respuesta<InformacionFinalPedido> respuesta = new();
            try
            {
                respuesta.Data = await _ingresoPedidoService.GuardarPedido(ingresoPedido);
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }
    }
}
