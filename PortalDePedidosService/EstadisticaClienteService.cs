using PortalDePedidosModel;
using PortalDePedidosShared.EstadisticasVM;
using PortalDePedidosShared.SeguimientoPedidosVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosService
{
    public class EstadisticaClienteService
    {
        private HttpClient _http;
        private LogClienteService _logService;
        private string _url = "/api/Estadistica/";

        public EstadisticaClienteService(HttpClient http, LogClienteService logService)
        {
            _http = http;
            _logService = logService;
        }

        public async Task<EstadisticaProductoVM> GetEstadisticaProducto(FiltroEstadisticaProducto filtro)
        {
            Respuesta<EstadisticaProductoVM> respuesta = new();
            try
            {
                var response = await _http.PostAsJsonAsync<FiltroEstadisticaProducto>(_url + "EstadisticaArticulo", filtro);
                respuesta = response.Content.ReadFromJsonAsync<Respuesta<EstadisticaProductoVM>>().Result;
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
