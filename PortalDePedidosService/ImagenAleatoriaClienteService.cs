using PortalDePedidosModel;
using PortalDePedidosShared.ImagenesAleatoriasVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using PortalDePedidosShared.ArticulosVM;

namespace PortalDePedidosService
{
    public class ImagenAleatoriaClienteService
    {
        private HttpClient _http;
        private LogClienteService _logService;
        private string _url = "/api/ImagenAleatoria/";
        public ImagenAleatoriaClienteService(HttpClient http, LogClienteService logService)
        {
            _http = http;
            _logService = logService;
        }
        public async Task<List<ImagenAleatoriaVM>> Get(int cantidad)
        {
            Respuesta<List<ImagenAleatoriaVM>> respuesta = new();
            try
            {
                respuesta = await _http.GetFromJsonAsync<Respuesta<List<ImagenAleatoriaVM>>>(_url + cantidad);
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }

            return respuesta.Data;
        }
        public async Task<List<ImagenAleatoriaVM>> GetAll() {
            Respuesta<List<ImagenAleatoriaVM>> respuesta = new();
            try {
                respuesta = await _http.GetFromJsonAsync<Respuesta<List<ImagenAleatoriaVM>>>(_url);
            } catch(Exception ex) {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }

            return respuesta.Data;
        }
        public async Task<bool> GuardarImagen(ImagenAleatoriaVM imagenVM)
        {
            Respuesta<object> respuesta = new();
            try
            {
                var response = await _http.PostAsJsonAsync<ImagenAleatoriaVM>(_url, imagenVM);
                respuesta = response.Content.ReadFromJsonAsync<Respuesta<object>>().Result;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }


            return respuesta.Exito;
        }
        public async Task<bool> EliminarImagen(int id) {
            Respuesta<object> respuesta = new();
            try {
                var response = await _http.DeleteAsync(_url + id);
                respuesta = response.Content.ReadFromJsonAsync<Respuesta<object>>().Result;
            } catch(Exception ex) {
                _logService.WriteLogException(ex);
            }

            return respuesta.Exito;
        }
    }
}
