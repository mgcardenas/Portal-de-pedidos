using PortalDePedidosModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosService
{
    public class PagoService
    {
        private HttpClient _http;
        private LogClienteService _logService;
        private string _url = "/api/Pago/";

        public PagoService(HttpClient http, LogClienteService logService)
        {
            _http = http;
            _logService = logService;
        }

        public async Task<List<Pago>> Get()
        {
            Respuesta<List<Pago>> respuesta = new();
            try
            {
                respuesta = await _http.GetFromJsonAsync<Respuesta<List<Pago>>>(_url);
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();

            }

            return respuesta.Data;
        }
    }
}
