using PortalDePedidosModel;
using PortalDePedidosShared.ArticulosVM;
using PortalDePedidosShared.ComprasAnticipadasPendientesVM;
using PortalDePedidosShared.CuentasCorrientesVM;
using PortalDePedidosShared.FacturasVM;
using PortalDePedidosShared.IngresoPedidosVM;
using PortalDePedidosShared.RecibosVM;
using PortalDePedidosShared.RemitosVM;
using PortalDePedidosShared.SeguimientoPedidosVM;
using PortalDePedidosShared.UsuariosVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PortalDePedidosService
{
    public class DataWareHouseClienteService
    {
        private HttpClient _http;
        private LogClienteService _logService;
        private string _url = "/api/DataWareHouse/";

        public DataWareHouseClienteService(HttpClient http, LogClienteService logService)
        {
            _http = http;
            _logService = logService;
        }
        public async Task<List<CuentaCorrienteVM>> GetCuentasCorrientes(FiltroCuentasCorrientesVM filtro)
        {
            Respuesta<List<CuentaCorrienteVM>> respuesta = new();
            try
            {
                var response = await _http.PostAsJsonAsync<FiltroCuentasCorrientesVM>(_url + "CuentasCorrientes", filtro);
                respuesta = response.Content.ReadFromJsonAsync<Respuesta<List<CuentaCorrienteVM>>>().Result;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }

            return respuesta.Data;
        }

        public async Task<List<string>> GetEstadosPedido()
        {
            Respuesta<List<string>> respuesta = new();
            try
            {
                respuesta = await _http.GetFromJsonAsync<Respuesta<List<string>>>(_url + "EstadosPedido");
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }

            return respuesta.Data;
        }
        public async Task<List<string>> GetEstadosPedidoVentaAnticipada()
        {
            Respuesta<List<string>> respuesta = new();
            try
            {
                respuesta = await _http.GetFromJsonAsync<Respuesta<List<string>>>(_url + "EstadosPedidoVentaAnticipada");
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }

            return respuesta.Data;
        }

        public async Task<List<SeguimientoPedidoVM>> GetSeguimientoPedido(FiltroSeguimientoPedidos filtro)
        {
            Respuesta<List<SeguimientoPedidoVM>> respuesta = new();
            try
            {
                var response = await _http.PostAsJsonAsync<FiltroSeguimientoPedidos>(_url + "SeguimientoPedidos", filtro);
                respuesta = response.Content.ReadFromJsonAsync<Respuesta<List<SeguimientoPedidoVM>>>().Result;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }

            return respuesta.Data;
        }

        public async Task<List<SeguimientoPedidoVM>> GetSeguimientoPedidoVentaAnticipada(FiltroSeguimientoPedidos filtro)
        {
            Respuesta<List<SeguimientoPedidoVM>> respuesta = new();
            try
            {
                var response = await _http.PostAsJsonAsync<FiltroSeguimientoPedidos>(_url + "SeguimientoPedidosVentasAnticipadas", filtro);
                respuesta = response.Content.ReadFromJsonAsync<Respuesta<List<SeguimientoPedidoVM>>>().Result;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }

            return respuesta.Data;
        }

        public async Task<List<ComprasAnticipadasVM>> GetComprasAnticipadasPendientes(FiltroComprasAnticipadasPendientes filtro)
        {
            Respuesta<List<ComprasAnticipadasVM>> respuesta = new();
            try
            {
                var response = await _http.PostAsJsonAsync<FiltroComprasAnticipadasPendientes>(_url + "ComprasAnticipadasPendientes", filtro);
                respuesta = response.Content.ReadFromJsonAsync<Respuesta<List<ComprasAnticipadasVM>>>().Result;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }

            return respuesta.Data;
        }

        public async Task<List<FacturasSP>> GetFacturas(FiltroFacturasSP filtro)
        {
            Respuesta<List<FacturasSP>> respuesta = new();
            try
            {
                var response = await _http.PostAsJsonAsync<FiltroFacturasSP>(_url+ "Facturas", filtro);
                respuesta = response.Content.ReadFromJsonAsync<Respuesta<List<FacturasSP>>>().Result;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }

            if (!respuesta.Exito)
                Console.WriteLine(respuesta.Mensaje);

            return respuesta.Data;
        }

        public async Task<List<RemitoVM>> GetRemitos(FiltroRemitosVM filtro)
        {
            Respuesta<List<RemitoVM>> respuesta = new();
            try
            {
                var response = await _http.PostAsJsonAsync<FiltroRemitosVM>(_url + "Remitos", filtro);
                respuesta = response.Content.ReadFromJsonAsync<Respuesta<List<RemitoVM>>>().Result;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }

            if (!respuesta.Exito)
                Console.WriteLine(respuesta.Mensaje);

            return respuesta.Data;
        }

        public async Task<List<ReciboVM>> GetRecibos(FiltroRecibos filtro)
        {
            Respuesta<List<ReciboVM>> respuesta = new();
            try
            {
                var response = await _http.PostAsJsonAsync<FiltroRecibos>(_url + "Recibos", filtro);
                respuesta = response.Content.ReadFromJsonAsync<Respuesta<List<ReciboVM>>>().Result;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }

            if (!respuesta.Exito)
                Console.WriteLine(respuesta.Mensaje);

            return respuesta.Data;
        }

        public async Task<List<RazonSocialVM>> GetAllRazonSocial()
        {
            Respuesta<List<RazonSocialVM>> respuesta = new();
            try
            {
                respuesta = await _http.GetFromJsonAsync<Respuesta<List<RazonSocialVM>>>(_url+"RazonSocial");
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }

            return respuesta.Data;
        }

        public async Task<List<ArticuloVM>> GetArticulos()
        {
            Respuesta<List<ArticuloVM>> respuesta = new();
            try
            {
                respuesta = await _http.GetFromJsonAsync<Respuesta<List<ArticuloVM>>>(_url+"Articulos");
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }

            return respuesta.Data;
        }

        public async Task<List<ArticuloIngresoPedidoVM>> GetArticulosIngreso()
        {
            Respuesta<List<ArticuloIngresoPedidoVM>> respuesta = new();
            try
            {
                respuesta = await _http.GetFromJsonAsync<Respuesta<List<ArticuloIngresoPedidoVM>>>(_url + "ArticulosIngreso");
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Data = new();
            }

            return respuesta.Data;
        }

        public async Task<bool> NroJDENoExiste(int nroJDE)
        {
            Respuesta<bool> respuesta = new();
            try
            {
                var response = await _http.PostAsJsonAsync<int>(_url + "NroJDENoExiste", nroJDE);
                respuesta = response.Content.ReadFromJsonAsync<Respuesta<bool>>().Result;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }

            if (!respuesta.Exito)
                Console.WriteLine(respuesta.Mensaje);

            return respuesta.Data;
        }

        public async Task<bool> EnviarConsultaSaldo(ConsultaSaldoAFavor consulta)
        {
            Respuesta<bool> respuesta = new();
            try
            {
                var response = await _http.PostAsJsonAsync<ConsultaSaldoAFavor>(_url + "ConsultaSaldoAFavor", consulta);
                respuesta = response.Content.ReadFromJsonAsync<Respuesta<bool>>().Result;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
            }

            if (!respuesta.Exito)
                Console.WriteLine(respuesta.Mensaje);

            return respuesta.Data;
        }
    }
}
