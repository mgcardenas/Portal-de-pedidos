using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalDePedidosModel;
using PortalDePedidosServidor.Models;
using PortalDePedidosServidor.Servicios;
using PortalDePedidosShared;
using PortalDePedidosShared.LoginVM;

namespace PortalDePedidosServidor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReCaptchaController : ControllerBase
    {
        private RecaptchaService _recaptchaService;
        private LogService _logService;

        public ReCaptchaController(RecaptchaService recaptchaService, LogService logService)
        {
            _recaptchaService = recaptchaService;
            _logService = logService;
        }

        [HttpPost]
        //public async Task<IActionResult> Validate([FromBody] string token)
        public async Task<IActionResult> Validate([FromBody] ReCaptchaVM reCaptcha)
        {
            Respuesta<object> respuesta = new();
            try
            {
                respuesta.Exito = _recaptchaService.createAssessment(reCaptcha);              
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }
            return Ok(respuesta);
        }
    }
}
