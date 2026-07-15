using Microsoft.IdentityModel.Tokens;
using PortalDePedidosShared.FacturasVM;
using PortalDePedidosShared.RecibosVM;
using PortalDePedidosShared.RemitosVM;
using System.Net;

namespace PortalDePedidosServidor.Servicios
{
    public class PDFService
    {
        private AccesoARedService _accesoARedService;
        private LogService _logService;
        private readonly HttpClient _httpClient;
        private IConfiguration _configuration;
        private string _url;

        public PDFService(AccesoARedService accesoARedService, LogService logService, IConfiguration configuration)
        {
            _accesoARedService = accesoARedService;
            _logService = logService;
            _configuration = configuration;

            try
            {

                // Configura el HttpClientHandler con las credenciales
                var handler = new HttpClientHandler
                {
                    Credentials = new NetworkCredential(
                        _configuration.GetConnectionString("networkUsername"),
                        _configuration.GetConnectionString("networkPassword"))
                };

                // Inicializa HttpClient con el handler configurado
                _httpClient = new HttpClient(handler)
                {
                    BaseAddress = new Uri(_configuration.GetConnectionString("urlPDF")) // Establece la URL base
                };
            }
            catch (Exception ex)
            {
                logService.WriteLogException(ex);
            }
        }

        public async Task<byte[]> GetFacturaByte(FacturasSP factura)
        {
            try
            {
                var ruta = GetRutaFacturaPdf(factura);
                
                // Usa directamente el nombre del PDF sin concatenar la URL base
                var response = await _httpClient.GetAsync(ruta);
                if (response.IsSuccessStatusCode)
                {
                //_logService.WriteLogPDF("Exito, url:"+ _httpClient.BaseAddress + ruta);
                    return await response.Content.ReadAsByteArrayAsync();
                }
                else
                {
                    // Manejar el error si la solicitud no fue exitosa
                    _logService.WriteLogPDF("Fallo, url:" + _httpClient.BaseAddress + ruta);
                    throw new Exception($"Error al descargar el PDF: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones, por ejemplo, problemas de red
                throw new Exception("Hubo un problema al acceder a la URL del PDF.", ex);
            }
        }

        public async Task<byte[]> GetReciboByte(ReciboVM recibo)
        {
            try
            {
                var ruta = GetRutaReciboPdf(recibo);

                // Usa directamente el nombre del PDF sin concatenar la URL base
                var response = await _httpClient.GetAsync(ruta);
                if (response.IsSuccessStatusCode)
                {
                    //_logService.WriteLogPDF("Exito, url:"+ _httpClient.BaseAddress + ruta);
                    return await response.Content.ReadAsByteArrayAsync();
                }
                else
                {
                    // Manejar el error si la solicitud no fue exitosa
                    _logService.WriteLogPDF("Fallo, url:" + _httpClient.BaseAddress + ruta);
                    throw new Exception($"Error al descargar el PDF: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones, por ejemplo, problemas de red
                throw new Exception("Hubo un problema al acceder a la URL del PDF.", ex);
            }
        }

        public async Task<byte[]> GetRemitoByte(RemitoVM remito)
        {
            try
            {
                var ruta = GetRutaRemitoPdf(remito);

                // Usa directamente el nombre del PDF sin concatenar la URL base
                var response = await _httpClient.GetAsync(ruta);
                if (response.IsSuccessStatusCode)
                {
                    //_logService.WriteLogPDF("Exito, url:"+ _httpClient.BaseAddress + ruta);
                    return await response.Content.ReadAsByteArrayAsync();
                }
                else
                {
                    // Manejar el error si la solicitud no fue exitosa
                    _logService.WriteLogPDF("Fallo, url:" + _httpClient.BaseAddress + ruta);
                    throw new Exception($"Error al descargar el PDF: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones, por ejemplo, problemas de red
                throw new Exception("Hubo un problema al acceder a la URL del PDF.", ex);
            }
        }

        private string GetRutaFacturaPdf(FacturasSP factura)
        {
            var ruta = "";
            var añoActual = DateTime.Now.Year;
            ruta = "Facturacion/" + factura.Fecha_factura.Value.Year + "/" + factura.Nombre_archivo;
            return ruta;
        }

        private string GetRutaReciboPdf(ReciboVM recibo)
        {
            var ruta = "";
            var añoActual = DateTime.Now.Year;
            ruta = "Recibos/" + recibo.FechaCobro.Year + "/" + recibo.NombreArchivo;
            return ruta;
        }

        private string GetRutaRemitoPdf(RemitoVM remito)
        {
            var ruta = "";
            var añoActual = DateTime.Now.Year;
            ruta = "Remitos/" + remito.FechaEnvio.Year + "/" + remito.NombreArchivo;
            return ruta;
        }

        public void CopiarPDFAServidorLocal(string sourceFileName, string destinationFilePath)
        {
            try
            {
                _accesoARedService.IniciarAcceso();
                string sourceFilePath = Path.Combine(_accesoARedService.networkPath, sourceFileName);
                if (File.Exists(sourceFilePath))
                {
                    File.Copy(sourceFilePath, destinationFilePath, true);
                    _logService.WriteLogPDF("PDF copiado con exito");
                }
                else
                {
                    _logService.WriteLogPDF("No se encontro el pdf");
                }
            }
            catch (Exception ex)
            {
                _logService.WriteLogPDF(ex);
            }
        }

        public void PruebaCopiaAServidorLocal()
        {
            string sourceFileName = "30563598111_001_00097-00099762_2.pdf";
            string destinationFilePath = AppDomain.CurrentDomain.BaseDirectory + sourceFileName;
            CopiarPDFAServidorLocal(sourceFileName, destinationFilePath);
        }
    }
}
