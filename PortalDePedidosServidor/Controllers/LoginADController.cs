using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalDePedidosModel;

using PortalDePedidosServidor.Models;
using PortalDePedidosServidor.Servicios;

namespace PortalDePedidosServidor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginADController : ControllerBase
    {
        private LogService _logService;
        private LoginService _loginService;
        private JWTService _jwtService;
        private TokenBlacklistService _tokenBlacklistService;
        private bool _esApiPublica;

        public LoginADController(LogService logService, LoginService loginService, JWTService jwtService, TokenBlacklistService tokenBlacklistService, IConfiguration configuration)
        {
            _logService = logService;
            _loginService = loginService;
            _jwtService = jwtService;
            _tokenBlacklistService = tokenBlacklistService;
            _esApiPublica = bool.Parse(configuration.GetConnectionString("AppPublica"));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioLogIn login)
        {
            if (_esApiPublica)
            {
                return Unauthorized();
            }
            else
            {

                Respuesta<SesionUsuario> respuesta = new();
                try
                {
                    var sesion = await _loginService.LoginAD(login);
                    if (sesion != null)
                    {
                        var token = _jwtService.GetAccessToken(sesion);
                        _tokenBlacklistService.AddToTokenGeneradosList(token);
                        sesion.Token = token;
                        respuesta.Data = sesion;
                        respuesta.Exito = true;
                    }
                    else
                    {
                        return Unauthorized();
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
}
