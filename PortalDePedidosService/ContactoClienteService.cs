using PortalDePedidosModel;
using PortalDePedidosShared.ContactosVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosService
{
    public class ContactoClienteService
    {
        private HttpClient _http;
        private LogClienteService _logService;
        private string _url = "/api/Contacto/";

        public ContactoClienteService(HttpClient http, LogClienteService logService)
        {
            _http = http;
            _logService = logService;
        }

        public async Task<List<ContactoVM>> Get()
        {
            Respuesta<List<ContactoVM>> respuesta = new();
            try
            {
                respuesta = await _http.GetFromJsonAsync<Respuesta<List<ContactoVM>>>(_url);
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
