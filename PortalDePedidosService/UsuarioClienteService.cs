using Microsoft.AspNetCore.Components;
using PortalDePedidosModel;
using PortalDePedidosShared.DataWhereHouse;
using PortalDePedidosShared.UsuariosVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosService
{
    public class UsuarioClienteService
    {
        private HttpClient _http;
        private LogClienteService _logService;
        private string _url = "/api/Usuario/";

        public UsuarioClienteService(HttpClient http, LogClienteService logService)
        {
            _http = http;
            _logService = logService;
        }

        public async Task<List<UsuarioVM>> Get()
        {
            Respuesta<List<UsuarioVM>> respuesta = new();
            try
            {
                respuesta = await _http.GetFromJsonAsync<Respuesta<List<UsuarioVM>>>(_url);
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }

            return respuesta.Data;
        }

        public async Task<List<UsuarioVM>> GetClientes()
        {
            Respuesta<List<UsuarioVM>> respuesta = new();
            try
            {
                respuesta = await _http.GetFromJsonAsync<Respuesta<List<UsuarioVM>>>(_url+"Clientes");
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }

            return respuesta.Data;
        }

        public async Task<UsuarioVM> Get(int id)
        {
            Respuesta<UsuarioVM> respuesta = new();
            try
            {
                respuesta = await _http.GetFromJsonAsync<Respuesta<UsuarioVM>>(_url+ id);
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }

            return respuesta.Data;
        }

        public async Task<UsuarioVM> GetUsuarioJDE(int id,string nroJDE)
        {
            ClavesUsuarioJDE clave = new();
            clave.id = id;
            clave.nroJDE = nroJDE;
            Respuesta<UsuarioVM> respuesta = new();
            try
            {
                //cambiar a post
                //respuesta = await _http.GetFromJsonAsync<Respuesta<UsuarioVM>>(_url + "UsuarioJDE/" + nroJDE);
                var response = await _http.PostAsJsonAsync<ClavesUsuarioJDE>(_url + "UsuarioJDE", clave);
                respuesta = response.Content.ReadFromJsonAsync<Respuesta<UsuarioVM>>().Result;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }

            return respuesta.Data;
        }

        public async Task<UsuarioEditarVM> GetUsuarioEditar(int id)
        {
            Respuesta<UsuarioEditarVM> respuesta = new();
            try
            {
                respuesta = await _http.GetFromJsonAsync<Respuesta<UsuarioEditarVM>>(_url+"Editar/" + id);
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }

            return respuesta.Data;
        }

        public async Task<List<Zona>> GetZonas()
        {
            Respuesta<List<Zona>> respuesta = new();
            try
            {
                respuesta = await _http.GetFromJsonAsync<Respuesta<List<Zona>>>(_url + "Zona");
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }

            return respuesta.Data;
        }

        public async Task<List<UsuarioVM>> Buscar(FiltroUsuarios filtro)
        {
            Respuesta<List<UsuarioVM>> respuesta = new();
            try
            {
                var response = await _http.PostAsJsonAsync<FiltroUsuarios>(_url+"Buscar", filtro);
                respuesta = response.Content.ReadFromJsonAsync<Respuesta<List<UsuarioVM>>>().Result;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }

            return respuesta.Data;
        }

        public async Task<List<RolVM>> GetRol()
        {
            Respuesta<List<RolVM>> respuesta = new();
            try
            {
                respuesta = await _http.GetFromJsonAsync<Respuesta<List<RolVM>>>(_url+"Rol");
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }

            return respuesta.Data;
        }

        public async Task<bool> GuardarNuevoUsuario(UsuarioAltaVM usuarioAltaVM)
        {
            Respuesta<object> respuesta = new();
            try
            {
                var response = await _http.PostAsJsonAsync<UsuarioAltaVM>(_url , usuarioAltaVM);
                respuesta = response.Content.ReadFromJsonAsync<Respuesta<object>>().Result;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }

            if(!respuesta.Exito) 
                Console.WriteLine(respuesta.Mensaje);

            return respuesta.Exito;
        }
        public async Task<bool> ActualizarUsuario(UsuarioEditarVM usuarioEditarVM)
        {
            Respuesta<object> respuesta = new();
            try
            {
                var response = await _http.PostAsJsonAsync<UsuarioEditarVM>(_url+"Editar", usuarioEditarVM);
                respuesta = response.Content.ReadFromJsonAsync<Respuesta<object>>().Result;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }

            if (!respuesta.Exito)
                Console.WriteLine(respuesta.Mensaje);

            return respuesta.Exito;
        }

        public async Task<bool> NombreUsuarioExiste(string nombreUsuario)
        {
            Respuesta<bool> respuesta = new();
            try
            {
                var response = await _http.PostAsJsonAsync<string>(_url + "NombreUsuarioExiste", nombreUsuario);
                respuesta = response.Content.ReadFromJsonAsync<Respuesta<bool>>().Result;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }

            if (!respuesta.Exito)
                Console.WriteLine(respuesta.Mensaje);

            return respuesta.Data;
        }

        
    }
}
