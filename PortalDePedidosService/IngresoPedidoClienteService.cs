using PortalDePedidosModel;
using PortalDePedidosShared.IngresoPedidosVM;
using PortalDePedidosShared.UsuariosVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosService
{
    public class IngresoPedidoClienteService
    {
        private HttpClient _http;
        private LogClienteService _logService;
        private string _url = "/api/IngresoPedido/";

        public IngresoPedidoClienteService(HttpClient http, LogClienteService logService)
        {
            _http = http;
            _logService = logService;
        }

        public async Task<Respuesta<InformacionFinalPedido>> GuardarNuevoPedido(IngresoPedidoVM ingreso)
        {
            Respuesta<InformacionFinalPedido> respuesta = new();
            try
            {
                var response = await _http.PostAsJsonAsync<IngresoPedidoVM>(_url, ingreso);
                respuesta = response.Content.ReadFromJsonAsync<Respuesta<InformacionFinalPedido>>().Result;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }

            if (!respuesta.Exito)
                Console.WriteLine(respuesta.Mensaje);

            return respuesta;
        }

    }
}
