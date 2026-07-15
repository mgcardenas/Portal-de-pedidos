using PortalDePedidosModel;
using PortalDePedidosShared.ImagenesAleatoriasVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using PortalDePedidosShared.ArticulosVM;

namespace PortalDePedidosService {
    public class ImagenCarruselClienteService {
        private HttpClient _http;
        private LogClienteService _logService;
        private string _url = "/api/ImagenCarrusel/";
        public ImagenCarruselClienteService(HttpClient http,LogClienteService logService) {
            _http = http;
            _logService = logService;
        }
        public async Task<List<ImagenCarruselVM>> Get(int cantidad) {
            Respuesta<List<ImagenCarruselVM>> respuesta = new();
            try {
                respuesta = await _http.GetFromJsonAsync<Respuesta<List<ImagenCarruselVM>>>(_url + cantidad);
            } catch(Exception ex) {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }

            return respuesta.Data;
        }
        public async Task<List<ImagenCarruselVM>> GetAll() {
            Respuesta<List<ImagenCarruselVM>> respuesta = new();
            try {
                respuesta = await _http.GetFromJsonAsync<Respuesta<List<ImagenCarruselVM>>>(_url);
            } catch(Exception ex) {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }

            return respuesta.Data;
        }
        public async Task<bool> GuardarImagen(ImagenCarruselVM imagenVM) {
            Respuesta<object> respuesta = new();
            try {
                var response = await _http.PostAsJsonAsync<ImagenCarruselVM>(_url,imagenVM);
                respuesta = response.Content.ReadFromJsonAsync<Respuesta<object>>().Result;
            } catch(Exception ex) {
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
