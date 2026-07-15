using PortalDePedidosModel;
using PortalDePedidosShared.ArticulosVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace PortalDePedidosService
{
    public class ImagenClienteService
    {
        private HttpClient _http;
        private LogClienteService _logService;
        private string _url = "/api/Imagen/";
        public ImagenClienteService(HttpClient http, LogClienteService logService)
        {
            _http = http;
            _logService = logService;
        }
        public async Task<ImagenVM> GetImagen(string idArticulo)
        {
            Respuesta<ImagenVM> respuesta = new();
            try
            {
                respuesta = await _http.GetFromJsonAsync<Respuesta<ImagenVM>>(_url + idArticulo);
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }

            return respuesta.Data;
        }
        public async Task<bool> GuardarImagen(ImagenVM imagenVM)
        {
            Respuesta<object> respuesta = new();
            try
            {
                var response = await _http.PostAsJsonAsync<ImagenVM>(_url, imagenVM);
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
