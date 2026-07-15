using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalDePedidosModel;
using PortalDePedidosServidor.Servicios;
using PortalDePedidosShared.ArticulosVM;
using PortalDePedidosShared.UsuariosVM;

namespace PortalDePedidosServidor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private LogService _logService;
        private ArticuloService _articuloService;

        public ArticuloController(LogService logService, ArticuloService articuloService)
        {
            _logService = logService;
            _articuloService = articuloService;
        }

        //[HttpGet("Ultimo")]
        //public async Task<IActionResult> Ultimo()
        //{
        //    Respuesta<string> respuesta = new();
        //    try
        //    {
        //        respuesta.Data = await _articuloService.GetUltimoId();
        //        respuesta.Exito = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logService.WriteLogException(ex);
        //    }
        //    return Ok(respuesta);
        //}

        //[HttpGet("SubCategoria")]
        //public async Task<IActionResult> GetSubCategoria()
        //{
        //    Respuesta<List<SubCategoriaVM>> respuesta = new();
        //    try
        //    {
        //        respuesta.Data = await _articuloService.GetSubCategorias();
        //        respuesta.Exito = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logService.WriteLogException(ex);
        //    }
        //    return Ok(respuesta);
        //}

        [HttpPost("ArticuloEditar")]
        //[Authorize]
        [ServiceFilter(typeof(BlacklistAuthorizationFilter))]
        public async Task<IActionResult> GetArticuloEditar([FromBody] string codigo)
        {
            Respuesta<ArticuloEditarVM> respuesta = new();
            try
            {
                respuesta.Data = await _articuloService.GetArticuloEditar(codigo);
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }
            return Ok(respuesta);
        }

        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] ArticuloEditarVM articuloVM)
        //{
        //    Respuesta<object> respuesta = new();
        //    try
        //    {
        //        await _articuloService.GuardarArticulo(articuloVM);
        //        respuesta.Exito = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logService.WriteLogException(ex);
        //        respuesta.Mensaje = ex.Message;
        //    }
        //    return Ok(respuesta);
        //}
    }
}
