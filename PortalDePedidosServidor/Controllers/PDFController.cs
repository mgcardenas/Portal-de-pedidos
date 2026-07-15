using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalDePedidosModel;
using PortalDePedidosServidor.Servicios;
using PortalDePedidosShared.FacturasVM;
using PortalDePedidosShared.IngresoPedidosVM;
using PortalDePedidosShared.RecibosVM;
using PortalDePedidosShared.RemitosVM;
using PortalDePedidosShared.UsuariosVM;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortalDePedidosServidor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PDFController : ControllerBase
    {
        private LogService _logService;
        private PDFService _pdfService;
        private PdfToBase64Service _pdfToBase64;

        public PDFController(LogService logService, PDFService pdfService, PdfToBase64Service pdfToBase64)
        {
            _logService = logService;
            _pdfService = pdfService;
            _pdfToBase64 = pdfToBase64;
        }

        [HttpPost("Factura")]
        [Authorize][ServiceFilter(typeof(BlacklistAuthorizationFilter))] public async Task<IActionResult> Factura([FromBody] FacturasSP factura)
        {
            Respuesta<byte[]> respuesta = new();
            try
            {
                respuesta.Data =await _pdfService.GetFacturaByte(factura);
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpPost("Recibo")]
        [Authorize][ServiceFilter(typeof(BlacklistAuthorizationFilter))] public async Task<IActionResult> Recibo([FromBody] ReciboVM recibo)
        {
            Respuesta<byte[]> respuesta = new();
            try
            {
                respuesta.Data = await _pdfService.GetReciboByte(recibo);
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpPost("Remito")]
        [Authorize][ServiceFilter(typeof(BlacklistAuthorizationFilter))]
        public async Task<IActionResult> Remito([FromBody] RemitoVM remito)
        {
            Respuesta<byte[]> respuesta = new();
            try
            {
                respuesta.Data = await _pdfService.GetRemitoByte(remito);
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }

        [HttpPost]
        [Authorize][ServiceFilter(typeof(BlacklistAuthorizationFilter))] public async Task<IActionResult> Post([FromBody] string contenidoHtml)
        {
            Respuesta<byte[]> respuesta = new();
            try
            {
                respuesta.Data = _pdfToBase64.GenerarPdfByte(contenidoHtml);
                respuesta.Exito = true;
            }
            catch (Exception ex)
            {
                _logService.WriteLogException(ex);
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }


    }
}
