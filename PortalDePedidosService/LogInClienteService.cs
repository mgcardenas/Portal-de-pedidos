using PortalDePedidosModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.PortableExecutable;
using static System.Net.WebRequestMethods;
using PortalDePedidosShared.LoginVM;
using Irony.Parsing;
using System.Net.Http.Headers;
using Google.Api;
using PortalDePedidosShared.UsuariosVM;

namespace PortalDePedidosService
{
    public class LogInClienteService
    {
        private HttpClient _httpClient;
        private LogClienteService _logClienteService;
        private string _url = "/api/Login/";
        private string _urlAD = "/api/LoginAD/";
        private string _urlOlvide = "/api/Olvide/";
        private string _urlRecuperar = "/api/Recuperar/";

        public LogInClienteService(HttpClient httpClient, LogClienteService logClienteService)
        {
            _httpClient = httpClient;
            _logClienteService = logClienteService;
        }

        public async Task<Respuesta<SesionUsuario>> Login(UsuarioLogIn credentials)
        {
            Respuesta<SesionUsuario> respuesta = new();
            try
            {
                var response = await _httpClient.PostAsJsonAsync<UsuarioLogIn>(_url, credentials);
                respuesta = response.Content.ReadFromJsonAsync<Respuesta<SesionUsuario>>().Result;
                respuesta.Mensaje = response.StatusCode.ToString();

                if (respuesta.Exito)
                {
                    // Configurar el token para las solicitudes HTTP
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", respuesta.Data.Token);
                    return respuesta;
                }
            }
            catch (Exception ex)
            { 
                _logClienteService.WriteLogException(ex);
            }
            respuesta.Data = null;
            return respuesta;
        }

        public async Task<bool> LoginMFA(UsuarioLogIn credentials)
        {
            Respuesta<object> respuesta = new();
            try
            {
                var response = await _httpClient.PostAsJsonAsync<UsuarioLogIn>(_url+ "LogInMFA", credentials);
                respuesta = response.Content.ReadFromJsonAsync<Respuesta<object>>().Result;
                return respuesta.Exito;
            }
            catch (Exception ex)
            {
                _logClienteService.WriteLogException(ex);
            }
            return false;
        }

        public async Task<SesionUsuario> IngresoMFA(int? codigo)
        {
            if (codigo == null)
                return null;
            Respuesta<SesionUsuario> respuesta = new();
            try
            {
                respuesta = await _httpClient.GetFromJsonAsync<Respuesta<SesionUsuario>>(_url+ "InicioMFA/"+codigo);

                if (respuesta.Exito)
                {
                    // Configurar el token para las solicitudes HTTP
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", respuesta.Data.Token);
                    return respuesta.Data;
                }
            }
            catch (Exception ex)
            {
                _logClienteService.WriteLogException(ex);
            }
            return null;
        }

        public async Task<Respuesta<SesionUsuario>> LoginAD(UsuarioLogIn credentials)
        {
            Respuesta<SesionUsuario> respuesta = new();
            try
            {
                var response = await _httpClient.PostAsJsonAsync<UsuarioLogIn>(_urlAD, credentials);
                respuesta = response.Content.ReadFromJsonAsync<Respuesta<SesionUsuario>>().Result;

                if (respuesta.Exito)
                {
                    // Configurar el token para las solicitudes HTTP
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", respuesta.Data.Token);
                    return respuesta;
                }
            }
            catch (Exception ex)
            {
                _logClienteService.WriteLogException(ex);
            }
            return null;
        }

        public async Task<bool> OlvideContrasena(OlvideContrasenaVM olvideContrasena)
        {
            Respuesta<bool> respuesta = new();
            try
            {
                var response = await _httpClient.PostAsJsonAsync<OlvideContrasenaVM>(_urlOlvide, olvideContrasena);
                respuesta = response.Content.ReadFromJsonAsync<Respuesta<bool>>().Result;
            }
            catch (Exception ex)
            {
                _logClienteService.WriteLogException(ex);
            }
            return respuesta.Data;
        }

        public async Task<bool> RecuperarContrasena(RecuperarContrasenaVM recuperarVM)
        {
            Respuesta<object> respuesta = new();
            try
            {
                var response = await _httpClient.PostAsJsonAsync<RecuperarContrasenaVM>(_urlRecuperar, recuperarVM);
                respuesta = response.Content.ReadFromJsonAsync<Respuesta<object>>().Result;
            }
            catch (Exception ex)
            {
                _logClienteService.WriteLogException(ex);
            }
            return respuesta.Exito;
        }

        public async Task<bool> EnlaceValido(int id)
        {
            Respuesta<bool> respuesta = new();
            try
            {
                respuesta = await _httpClient.GetFromJsonAsync<Respuesta<bool>>(_urlRecuperar + id);
            }
            catch (Exception ex)
            {
                _logClienteService.WriteLogException(ex);
                respuesta.Data = false;
            }
            return respuesta.Data;
        }

        public async Task<bool> Logout(string token)
        {
            Respuesta<object> respuesta = new();
            try
            {
                //var response = await _httpClient.PostAsJsonAsync<string>(_url+"Logout", token);
                //respuesta = response.Content.ReadFromJsonAsync<Respuesta<object>>().Result;
                respuesta = await _httpClient.GetFromJsonAsync<Respuesta<object>>(_url + "Logout");
            }
            catch (Exception ex)
            {
                _logClienteService.WriteLogException(ex);
            }
            return respuesta.Exito;
        }
    }
}
