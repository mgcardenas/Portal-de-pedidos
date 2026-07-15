using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalDePedidosModel;

using PortalDePedidosServidor.Models;
using PortalDePedidosServidor.Servicios;
using PortalDePedidosShared.LoginVM;
using PortalDePedidosShared.UsuariosVM;

namespace PortalDePedidosServidor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecuperarController : ControllerBase
    {
        private LogService _logService;
        private LoginService _logInService;
        private SolicitudContrasenaService _solicitudContrasenaService;

        public RecuperarController(LogService logService, LoginService logInService, SolicitudContrasenaService solicitudContrasenaService)
        {
            _logService = logService;
            _logInService = logInService;
            _solicitudContrasenaService = solicitudContrasenaService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RecuperarContrasenaVM recuperar)
        {
            Respuesta<object> respuesta = new();
            try
            {
                respuesta.Exito = await _logInService.RecuperarContrasena(recuperar);
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }
            return Ok(respuesta);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Respuesta<bool> respuesta = new();
            try
            {
                respuesta.Data = _solicitudContrasenaService.SolicitudVigente(id);
                _solicitudContrasenaService.EliminarSolicitud(id);
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }
            return Ok(respuesta);
        }
    }
}
