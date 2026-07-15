using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalDePedidosModel;
using PortalDePedidosServidor.Models;
using PortalDePedidosServidor.Servicios;
using PortalDePedidosShared.AuditoriasVM;
using PortalDePedidosShared.UsuariosVM;

namespace PortalDePedidosServidor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditoriaController : ControllerBase
    {
        private LogService _logService;
        private AuditoriasService _auditoriasService;
        public AuditoriaController(LogService logService, AuditoriasService auditoriasService)
        {
            _logService = logService;
            _auditoriasService = auditoriasService;
        }
        [HttpGet]
        [Authorize][ServiceFilter(typeof(BlacklistAuthorizationFilter))] public async Task<IActionResult> Get()
        {
            Respuesta<List<AuditoriasVM>> respuesta = new();
            try
            {
                respuesta.Data = await _auditoriasService.GetAllAuditorias();
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }
            return Ok(respuesta);
        }

        [HttpPost]
        [Authorize][ServiceFilter(typeof(BlacklistAuthorizationFilter))] public async Task<IActionResult> Post([FromBody] AuditoriasVM auditoriasVM)
        {
            Respuesta<object> respuesta = new();
            try
            {
                await _auditoriasService.GuardarNuevaAuditoria(auditoriasVM);
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
