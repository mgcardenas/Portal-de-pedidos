using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using PortalDePedidosModel;

using PortalDePedidosServidor.Models;
using PortalDePedidosServidor.Servicios;
using PortalDePedidosShared.UsuariosVM;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortalDePedidosServidor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LogService _logService;
        private LoginService _loginService;
        private JWTService _jwtService;
        private TokenBlacklistService _tokenBlacklistService;
        private BloqueoLogInService _boqueoLogInService;
        private LogInMFAService _logInMFAService;

        public LoginController(LogService logService, LoginService loginService, JWTService jwtService, TokenBlacklistService tokenBlacklistService, BloqueoLogInService boqueoLogInService, LogInMFAService logInMFAService)
        {
            _logService = logService;
            _loginService = loginService;
            _jwtService = jwtService;
            _tokenBlacklistService = tokenBlacklistService;
            _boqueoLogInService = boqueoLogInService;
            _logInMFAService = logInMFAService;
        }


        // POST api/<LoginController>
        [EnableRateLimiting("token")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioLogIn login)
        {
            Respuesta<SesionUsuario> respuesta = new();

            try
            {
                var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
                if (!_boqueoLogInService.IsLogInBloqueado(login.userName, ip))
                {
                    //si el login no esta bloqueado procedo normalmente
                    var sesion = await _loginService.LoginBD(login);
                    if (sesion != null)
                    {
                        //se inicio sesion correctamente
                        var token = _jwtService.GetAccessToken(sesion);
                        _tokenBlacklistService.AddToTokenGeneradosList(token);
                        _boqueoLogInService.EliminarSolicitud(login.userName, ip);
                        sesion.Token = token;
                        respuesta.Data = sesion;
                        respuesta.Exito = true;
                    }
                    else
                    {
                        //credenciales incorrectas
                        await _boqueoLogInService.AddSolicitud(login.userName, ip);
                        //chequeo si supero el numero de intentos bloqueo el login
                        if (_boqueoLogInService.SuperaLimiteDeIntentos(login.userName, ip))
                            _boqueoLogInService.BloqueoLogIn(login.userName, ip);

                        //return Unauthorized();
                    }
                }
                else
                {
                    //LoginBloqueado
                    return Unauthorized();
                }

            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }
            return Ok(respuesta);
        }

        [HttpGet("Logout")]
        [Authorize]
        [ServiceFilter(typeof(BlacklistAuthorizationFilter))]
        public async Task<IActionResult> Logout()
        {
            Respuesta<object> respuesta = new();

            try
            {
                // Verificar si el encabezado 'Authorization' está presente
                if (Request.Headers.TryGetValue("Authorization", out var token))
                {
                    // Eliminar la palabra 'Bearer ' del token, si es necesario
                    var jwtToken = token.ToString().Replace("Bearer ", "");
                    if (_tokenBlacklistService.EsTokenGenerado(jwtToken))
                    {
                        await _loginService.Logout(jwtToken);
                        respuesta.Exito = true;
                        respuesta.Mensaje = "Sesión cerrada exitosamente.";
                    }
                }
                else
                {
                    respuesta.Mensaje = "401 Unauthorized";
                }
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }
            return Ok(respuesta);
        }

        // POST api/<LoginController> Login MFA
        [EnableRateLimiting("token")]
        [HttpPost("LogInMFA")]
        public async Task<IActionResult> LogInMFA([FromBody] UsuarioLogIn login)
        {
            Respuesta<object> respuesta = new();

            try
            {
                var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
                if (!_boqueoLogInService.IsLogInBloqueado(login.userName, ip))
                {
                    //si el login no esta bloqueado procedo normalmente
                    var sesion = await _loginService.LoginBD(login);
                    if (sesion != null)
                    {
                        //se inicio sesion correctamente
                        var token = _jwtService.GetAccessToken(sesion);
                        _tokenBlacklistService.AddToTokenGeneradosList(token);
                        _boqueoLogInService.EliminarSolicitud(login.userName, ip);
                        sesion.Token = token;
                        await _logInMFAService.IniciarLogInMFA(sesion);
                        respuesta.Exito = true;
                    }
                    else
                    {
                        //credenciales incorrectas
                        await _boqueoLogInService.AddSolicitud(login.userName, ip);
                        //chequeo si supero el numero de intentos bloqueo el login
                        if (_boqueoLogInService.SuperaLimiteDeIntentos(login.userName, ip))
                            _boqueoLogInService.BloqueoLogIn(login.userName, ip);

                        return Unauthorized();
                    }
                }
                else
                {
                    //LoginBloqueado
                    return Unauthorized();
                }

            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }
            return Ok(respuesta);
        }
        [EnableRateLimiting("token")]
        [HttpGet("InicioMFA/{codigo}")]
        public async Task<IActionResult> InicioMFA(int codigo)
        {
            Respuesta<SesionUsuario> respuesta = new();
            try
            {
                respuesta.Data = _logInMFAService.ObtenerSesion(codigo);
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }
            return Ok(respuesta);
        }
        //[HttpGet("Ping")]
        //public async Task<IActionResult> Ping()
        //{
        //    Respuesta<object> respuesta = new();
        //    try
        //    {
        //        respuesta.Exito = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logService.WriteLogException(ex);
        //    }
        //    return Ok(respuesta);
        //}

    }
}
