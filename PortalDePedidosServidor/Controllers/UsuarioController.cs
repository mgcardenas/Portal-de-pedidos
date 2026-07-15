using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalDePedidosModel;

using PortalDePedidosServidor.Models;
using PortalDePedidosServidor.ModelsDataWhereHouse;
using PortalDePedidosServidor.Servicios;
using PortalDePedidosShared.DataWhereHouse;
using PortalDePedidosShared.UsuariosVM;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortalDePedidosServidor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private PortalTestContext _context;
        private LogService _logService;
        private UsuarioService _usuarioService;
        private DataWareHouseService _dataWhereHouseService;

        public UsuarioController(PortalTestContext context, LogService logService, UsuarioService usuarioService,DataWareHouseService dataWhereHouseService )
        {
            _context = context;
            _logService = logService;
            _usuarioService = usuarioService;
            _dataWhereHouseService = dataWhereHouseService;
        }

        
        [HttpGet]
        [Authorize][ServiceFilter(typeof(BlacklistAuthorizationFilter))]
        public async Task<IActionResult> Get()
        {
            Respuesta<List<UsuarioVM>> respuesta = new();
            try
            {
                respuesta.Data = await _usuarioService.GetAllUsuarios();
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }
            return Ok(respuesta);
        }

        [HttpGet("ClientesViejo")]
        //[Authorize][ServiceFilter(typeof(BlacklistAuthorizationFilter))] 
        public async Task<IActionResult> GetClientes()
        {
            Respuesta<List<UsuarioVM>> respuesta = new();
            try
            {
                respuesta.Data = await _usuarioService.GetUsuariosClientes();
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }
            return Ok(respuesta);
        }
        
        [HttpGet("Clientes")]
        //[Authorize][ServiceFilter(typeof(BlacklistAuthorizationFilter))] 
        public async Task<IActionResult> GetClientesOptimizado()
        {
            Respuesta<List<UsuarioVM>> respuesta = new();
            try
            {
                respuesta.Data = await _usuarioService.GetUsuariosClientesOptimizado();
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }
            return Ok(respuesta);
        }


        [HttpGet("{id}")]
        [Authorize][ServiceFilter(typeof(BlacklistAuthorizationFilter))] public async Task<IActionResult> Get(int id)
        {
            Respuesta<UsuarioVM> respuesta = new();
            try
            {
                respuesta.Data =await _usuarioService.Get(id);   
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }
            return Ok(respuesta);
        }

        [HttpGet("UsuarioJDE/{nroJDE}")]
        [Authorize][ServiceFilter(typeof(BlacklistAuthorizationFilter))] public async Task<IActionResult> GetUsuarioJDE(string nroJDE)
        {
            Respuesta<UsuarioVM> respuesta = new();
            try
            {
                respuesta.Data = await _usuarioService.GetUsuarioPorNroJDE(nroJDE);
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }
            return Ok(respuesta);
        }
        [HttpPost("UsuarioJDE")]
        [Authorize][ServiceFilter(typeof(BlacklistAuthorizationFilter))] public async Task<IActionResult> GetUsuarioJDE([FromBody] ClavesUsuarioJDE clave)
        {
            Respuesta<UsuarioVM> respuesta = new();
            try
            {
                respuesta.Data = await _usuarioService.GetUsuarioPorNroJDE(clave);
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }
            return Ok(respuesta);
        }

        [HttpGet("Editar/{id}")]
        [Authorize][ServiceFilter(typeof(BlacklistAuthorizationFilter))] public async Task<IActionResult> GetEditar(int id)
        {
            Respuesta<UsuarioEditarVM> respuesta = new();
            try
            {
                respuesta.Data = await _usuarioService.GetUsuarioEditar(id);
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }
            return Ok(respuesta);
        }

        [HttpPost]
        [Authorize]
        [ServiceFilter(typeof(BlacklistAuthorizationFilter))]
        public async Task<IActionResult> Post([FromBody] UsuarioAltaVM usuarioAltaVM)
        {
            Respuesta<object> respuesta = new();
            try
            {
                await _usuarioService.GuardarNuevoUsuario(usuarioAltaVM);
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                return Unauthorized();
                //respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpPost("Buscar")]
        [Authorize][ServiceFilter(typeof(BlacklistAuthorizationFilter))] public async Task<IActionResult> Buscar([FromBody] FiltroUsuarios filtro)
        {
            Respuesta<List<UsuarioVM>> respuesta = new();
            try
            {
                respuesta.Data = await _usuarioService.Buscar(filtro);
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }
            return Ok(respuesta);
        }

        [HttpPost("Editar")]
        [Authorize][ServiceFilter(typeof(BlacklistAuthorizationFilter))] public async Task<IActionResult> Editar([FromBody] UsuarioEditarVM usuarioEditarVM)
        {
            Respuesta<object> respuesta = new();
            try
            {
                respuesta.Exito = await _usuarioService.EditarUsuario(usuarioEditarVM);
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }
            return Ok(respuesta);
        }

        [HttpPost("NombreUsuarioExiste")]
        [Authorize]
        [ServiceFilter(typeof(BlacklistAuthorizationFilter))]
        public async Task<IActionResult> NombreUsuarioExiste([FromBody] string nombreUsuario)
        {
            Respuesta<bool> respuesta = new();
            try
            {
                respuesta.Data = await _usuarioService.NombreUsuarioExiste(nombreUsuario);
                respuesta.Mensaje = respuesta.Data ? "El nombre de usuario ya está en uso." : "El nombre de usuario está disponible.";
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }
            return Ok(respuesta);
        }

        

        [HttpGet("Rol")]
        [Authorize]
        [ServiceFilter(typeof(BlacklistAuthorizationFilter))]
        public async Task<IActionResult> GetRol()
        {
            Respuesta<List<RolVM>> respuesta = new();
            try
            {
                respuesta.Data = await _usuarioService.GetAllRol();
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }
            return Ok(respuesta);
        }

        [HttpGet("Zona")]
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
    }
}
