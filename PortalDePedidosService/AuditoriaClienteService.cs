using PortalDePedidosModel;
using PortalDePedidosShared.AuditoriasVM;
using PortalDePedidosShared.UsuariosVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosService
{
    public class AuditoriaClienteService
    {
        private HttpClient _http;
        private LogClienteService _logService;
        private string _url = "/api/Auditoria/";
        public AuditoriaClienteService(HttpClient http, LogClienteService logService)
        {
            _http = http;
            _logService = logService;
        }
        public async Task<List<AuditoriasVM>> Get()
        {
            Respuesta<List<AuditoriasVM>> respuesta = new();
            try
            {
                respuesta = await _http.GetFromJsonAsync<Respuesta<List<AuditoriasVM>>>(_url);
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }

            return respuesta.Data;
        }
        public async Task<bool> GuardarNuevaAuditoria(AuditoriasVM auditoriasVM)
        {
            Respuesta<object> respuesta = new();
            try
            {
                var response = await _http.PostAsJsonAsync<AuditoriasVM>(_url, auditoriasVM);
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
    }
}
