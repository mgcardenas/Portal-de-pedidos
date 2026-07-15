using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using PortalDePedidosModel;
using PortalDePedidosServidor.Models;
using PortalDePedidosServidor.Servicios;
using PortalDePedidosShared.LoginVM;

namespace PortalDePedidosServidor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OlvideController : ControllerBase
    {
        private LogService _logService;
        private MailService _mailService;
        private SolicitudContrasenaService _solicitudContrasenaService;

        public OlvideController(LogService logService, MailService mailService, SolicitudContrasenaService solicitudContrasenaService)
        {
            _logService = logService;
            _mailService = mailService;
            _solicitudContrasenaService = solicitudContrasenaService;
        }

        [EnableRateLimiting("token")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OlvideContrasenaVM recuperar)
        {
            Respuesta<bool> respuesta = new();
            respuesta.Data = true;
            try
            {
                var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
                var nroSolicitudes = _solicitudContrasenaService.GetNroSolicitudes(recuperar.nombreUsuario, ip);
                //verifico que no pase el numero de solicitudes maximo
                if(nroSolicitudes < 3)
                {
                    await _mailService.EnviarMailRecuperar(recuperar);
                    await _solicitudContrasenaService.AddSolicitud(recuperar.nombreUsuario,ip);
                    respuesta.Exito = true;
                }
                else
                {
                    respuesta.Data = false;
                }
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }
            return Ok(respuesta);
        }
    }
}
