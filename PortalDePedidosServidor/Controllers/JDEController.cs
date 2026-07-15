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
    public class JDEController : ControllerBase
    {
        public JDEService _JDEService { get; set; }
        public LogService _logService { get; set; }

        public JDEController(JDEService jDEService, LogService logService)
        {
            _JDEService = jDEService;
            _logService = logService;
        }

        [HttpGet("InfoCLiente/{nroJDE}")]
        [Authorize][ServiceFilter(typeof(BlacklistAuthorizationFilter))] public async Task<IActionResult> GetInfoCLiente(string nroJDE)
        {
            Respuesta<InfoClienteVM> respuesta = new();
            try
            {
                respuesta.Data = await _JDEService.GetInfoCliente(nroJDE);
                respuesta.Mensaje = "Información del cliente obtenida con éxito.";
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = "Cliente no encontrado. Verifica el ID e intenta nuevamente.";
                _logService.WriteLogException(ex);
            }
            return Ok(respuesta);
        }

    }
}
