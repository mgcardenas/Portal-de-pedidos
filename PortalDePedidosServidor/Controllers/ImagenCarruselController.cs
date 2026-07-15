using Microsoft.AspNetCore.Mvc;
using PortalDePedidosModel;
using PortalDePedidosServidor.Servicios;
using PortalDePedidosShared.ImagenesAleatoriasVM;
using PortalDePedidosShared.AuditoriasVM;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortalDePedidosServidor.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ImagenCarruselController : ControllerBase {
        private LogService _logService;
        private ImagenCarruselService _imagenService;
        public ImagenCarruselController(LogService logService,ImagenCarruselService imagenService) {
            _logService = logService;
            _imagenService = imagenService;
        }
        [HttpGet("{cantidad}")]
        [Authorize]
        [ServiceFilter(typeof(BlacklistAuthorizationFilter))]
        public async Task<IActionResult> Get(int cantidad) {
            Respuesta<List<ImagenCarruselVM>> respuesta = new();
            try {
                respuesta.Data = await _imagenService.GetImagen(cantidad);
                respuesta.Exito = true;
            } catch(Exception ex) {
                _logService.WriteLogException(ex);
            }
            return Ok(respuesta);
        }

        [HttpGet]
        [Authorize]
        [ServiceFilter(typeof(BlacklistAuthorizationFilter))]
        public async Task<IActionResult> GetAll() {
            Respuesta<List<ImagenCarruselVM>> respuesta = new();
            try {
                respuesta.Data = await _imagenService.GetImagenAll();
                respuesta.Exito = true;
            } catch(Exception ex) {
                _logService.WriteLogException(ex);
            }
            return Ok(respuesta);
        }

        [HttpPost]
        [Authorize]
        [ServiceFilter(typeof(BlacklistAuthorizationFilter))]
        public async Task<IActionResult> Post([FromBody] ImagenCarruselVM imagenVM) {
            Respuesta<object> respuesta = new();
            try {
                await _imagenService.GuardarNuevaImagen(imagenVM);
                respuesta.Exito = true;
            } catch(Exception ex) {
                _logService.WriteLogException(ex);
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }
        [HttpDelete("{id}")]
        [Authorize]
        [ServiceFilter(typeof(BlacklistAuthorizationFilter))]
        public async Task<IActionResult> Delete(int id) {
            Respuesta<object> respuesta = new();
            try {
                await _imagenService.EliminarImagen(id);
                respuesta.Exito = true;
            } catch(Exception ex) {
                _logService.WriteLogException(ex);
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }
    }
}