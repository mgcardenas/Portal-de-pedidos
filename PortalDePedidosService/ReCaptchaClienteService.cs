using System;
using System.Net.Http;
using System.Net.Http.Json;
using Google.Api.Gax.ResourceNames;
using Google.Apis.Http;
using Google.Cloud.RecaptchaEnterprise.V1;
using PortalDePedidosModel;
using PortalDePedidosShared.LoginVM;

namespace PortalDePedidosService
{
    public class ReCaptchaClienteService
    {
        private HttpClient _http;
        private string _url = "/api/ReCaptcha/";

        public ReCaptchaClienteService(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> Validar(string token,string action)
        {
            ReCaptchaVM vm = new ReCaptchaVM(token,action);
            Respuesta<object> respuesta = new();
            try
            {
                //var response = await _http.PostAsJsonAsync(_url, token);
                //respuesta = response.Content.ReadFromJsonAsync<Respuesta<object>>().Result;
                var response = await _http.PostAsJsonAsync<ReCaptchaVM>(_url, vm);
                respuesta = response.Content.ReadFromJsonAsync<Respuesta<object>>().Result;
            }
            catch(Exception ex) {
                return false;
            }
            return respuesta.Exito;
        }
    }
}
