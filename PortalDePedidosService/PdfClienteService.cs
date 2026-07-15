using PortalDePedidosModel;
using PortalDePedidosShared.FacturasVM;
using PortalDePedidosShared.IngresoPedidosVM;
using PortalDePedidosShared.RecibosVM;
using PortalDePedidosShared.RemitosVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosService
{
    public class PdfClienteService
    {
        private HttpClient _http;
        private LogClienteService _logService;
        private string _url = "/api/PDF/";

        public PdfClienteService(HttpClient http, LogClienteService logService)
        {
            _http = http;
            _logService = logService;
        }

        public async Task<byte[]> GetPdfByte(string contenidoHtml)
        {
            Respuesta<byte[]> respuesta = new();
            try
            {
                var response = await _http.PostAsJsonAsync<string>(_url, contenidoHtml);
                respuesta = response.Content.ReadFromJsonAsync<Respuesta<byte[]>>().Result;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                Console.WriteLine(ex.InnerException);
            }

            if (!respuesta.Exito)
                Console.WriteLine(respuesta.Mensaje);

            return respuesta.Data;
        }

        public async Task<Respuesta<byte[]>> GetFacturaByte(FacturasSP factura)
        {
            Respuesta<byte[]> respuesta = new();
            try
            {
                var response = await _http.PostAsJsonAsync<FacturasSP>(_url+ "Factura", factura);
                respuesta = response.Content.ReadFromJsonAsync<Respuesta<byte[]>>().Result;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }

            if (!respuesta.Exito)
                Console.WriteLine(respuesta.Mensaje);

            return respuesta;
        }

        public async Task<Respuesta<byte[]>> GetRemitoByte(RemitoVM remito)
        {
            Respuesta<byte[]> respuesta = new();
            try
            {
                var response = await _http.PostAsJsonAsync<RemitoVM>(_url + "Remito", remito);
                respuesta = response.Content.ReadFromJsonAsync<Respuesta<byte[]>>().Result;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }

            if (!respuesta.Exito)
                Console.WriteLine(respuesta.Mensaje);

            return respuesta;
        }

        public async Task<Respuesta<byte[]>> GetReciboByte(ReciboVM recibo)
        {
            Respuesta<byte[]> respuesta = new();
            try
            {
                var response = await _http.PostAsJsonAsync<ReciboVM>(_url + "Recibo", recibo);
                respuesta = response.Content.ReadFromJsonAsync<Respuesta<byte[]>>().Result;
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
