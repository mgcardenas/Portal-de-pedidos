namespace PortalDePedidosServidor.Servicios
{
    
    using PdfSharp.Pdf;
    using TheArtOfDev.HtmlRenderer.PdfSharp;

    public class PdfToBase64Service
    {

        public PdfToBase64Service()
        {
        }


        private static void Convertir(string[] args)
        {
            PdfDocument pdf = PdfGenerator.GeneratePdf("<p><h1>Hello World</h1>This is html rendered text</p>", PdfSharp.PageSize.A4);
            pdf.Save("document.pdf");
        }

        public byte[] GenerarPdfByte(string html)
        {
            if (string.IsNullOrWhiteSpace(html))
            {
                throw new ArgumentException("El contenido HTML no puede estar vacío.", nameof(html));
            }

            byte[] res;
            using (MemoryStream ms = new MemoryStream())
            {
                var pdf = PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
                pdf.Save(ms);
                res = ms.ToArray();
            }
            return res;
        }
    }

}
