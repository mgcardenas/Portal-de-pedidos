using PortalDePedidosModel;
using PortalDePedidosShared.ArticulosVM;
using PortalDePedidosShared.UsuariosVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosService
{
    public class ArticuloClienteService
    {
        private HttpClient _http;
        private LogClienteService _logService;
        private string _url = "/api/Articulo/";
        
        public ArticuloClienteService(HttpClient http, LogClienteService logService)
        {
            _http = http;
            _logService = logService;
        }

        public async Task<List<ArticuloVM>> Get()
        {
            Respuesta<List<ArticuloVM>> respuesta = new();
            try
            {
                respuesta = await _http.GetFromJsonAsync<Respuesta<List<ArticuloVM>>>(_url);
            }
            catch (Exception ex)
            { 
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }

            return respuesta.Data;
        }

        public async Task<ArticuloEditarVM> GetArticuloEditar(string codigo)
        {
            Respuesta<ArticuloEditarVM> respuesta = new();
            try
            {
                var response = await _http.PostAsJsonAsync<string>(_url + "ArticuloEditar", codigo);
                respuesta = response.Content.ReadFromJsonAsync<Respuesta<ArticuloEditarVM>>().Result;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }

            return respuesta.Data;
        }

        public async Task<List<UnidadVM>> GetUnidades()
        {
            Respuesta<List<UnidadVM>> respuesta = new();
            try
            {
                respuesta = await _http.GetFromJsonAsync<Respuesta<List<UnidadVM>>>(_url+"Unidad");
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }

            return respuesta.Data;
        }

        public async Task<List<SubCategoriaVM>> GetSubCategorias()
        {
            Respuesta<List<SubCategoriaVM>> respuesta = new();
            try
            {
                respuesta = await _http.GetFromJsonAsync<Respuesta<List<SubCategoriaVM>>>(_url + "SubCategoria");
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }

            return respuesta.Data;
        }

        public async Task<bool> GuardarArticulo(ArticuloEditarVM articuloVM)
        {
            Respuesta<object> respuesta = new();
            try
            {
                var response = await _http.PostAsJsonAsync<ArticuloEditarVM>(_url, articuloVM);
                respuesta = response.Content.ReadFromJsonAsync<Respuesta<object>>().Result;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }


            return respuesta.Exito;
        }
    }
}
