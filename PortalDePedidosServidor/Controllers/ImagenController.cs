using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalDePedidosModel;
using PortalDePedidosServidor.Servicios;
using PortalDePedidosShared.ArticulosVM;
using PortalDePedidosShared.AuditoriasVM;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortalDePedidosServidor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagenController : ControllerBase
    {
            private LogService _logService;
            private ImagenService _imagenService;
            public ImagenController(LogService logService, ImagenService imagenService)
            {
                _logService = logService;
                _imagenService = imagenService;
            }
        [HttpGet("{idArticulo}")]
        [Authorize][ServiceFilter(typeof(BlacklistAuthorizationFilter))] public async Task<IActionResult> Get(string idArticulo)
        {
            Respuesta<ImagenVM> respuesta = new();
            try
            {
                respuesta.Data = await _imagenService.GetImagen(idArticulo);
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }
            return Ok(respuesta);
        }

        [HttpPost]
            [Authorize][ServiceFilter(typeof(BlacklistAuthorizationFilter))] public async Task<IActionResult> Post([FromBody] ImagenVM imagenVM)
            {
                Respuesta<object> respuesta = new();
                try
                {
                    await _imagenService.GuardarNuevaImagen(imagenVM);
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