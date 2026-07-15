using ClosedXML.Excel;
using ClosedXML.Excel.Drawings;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PortalDePedidosShared.RecibosVM;
using PortalDePedidosShared.CuentasCorrientesVM;
using PortalDePedidosShared.FacturasVM;
using PortalDePedidosShared.RemitosVM;
using PortalDePedidosShared.SeguimientoPedidosVM;
using PortalDePedidosShared.UsuariosVM;
using System;
using PortalDePedidosShared.ComprasAnticipadasPendientesVM;

public class ExcelService
{
    private NavigationManager _navigation;

    public ExcelService(NavigationManager navigation)
    {
        _navigation = navigation;
    }
    public async Task GenerateExcelAsync<T>(List<T> data, IJSRuntime JSRuntime, string fileName)
    {
        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("Sheet1");

            var properties = typeof(T).GetProperties();

            // Define the headers for the Excel sheet using the property names
            var headers = properties.Select(property => property.Name).ToList();

            // Write headers to the first row of the worksheet
            for (int i = 1; i <= headers.Count; i++)
            {
                worksheet.Cell(1, i).Value = headers[i - 1];
            }

            // Write data to the worksheet
            for (int row = 2; row <= data.Count + 1; row++)
            {
                var item = data[row - 2];
                for (int col = 1; col <= properties.Length; col++)
                {
                    var value = properties[col - 1].GetValue(item);

                    // Conversión explícita del valor a un tipo conocido (string en este caso)
                    worksheet.Cell(row, col).SetValue((value != null) ? value.ToString() : null);
                }
            }

            // Save the workbook to the specified file path
            var content = new byte[0];
            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                content = stream.ToArray();
            }

            await JSRuntime.InvokeAsync<object>("BlazorDownloadFile", fileName, Convert.ToBase64String(content));
        }
    }

    public async Task exportExelRecibos(List<ReciboVM> list, FiltroRecibos filtros, IJSRuntime js, UsuarioVM cliente)
    {
        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("principal");

            //Fecha de reporte, titulo y logo 
            var currentRow = 1;
            worksheet.Cell(currentRow, 1).Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            worksheet.Cell(currentRow, 1).Style.Font.FontSize = 11;

            worksheet.Cell(currentRow, 2).Value = "Recibos";
            worksheet.Cell(currentRow, 2).Style.Font.FontSize = 18;

            // Buscamos logo y añadimos a excel
            var baseUri = new Uri(_navigation.BaseUri);
            var imagePath = _navigation.BaseUri + "/imagenes/logo/logo_empresa.png";

            // Descargar la imagen desde la web
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.GetAsync(imagePath);
                    response.EnsureSuccessStatusCode(); // Lanza una excepción si hay un error

                    using (var imageStream = await response.Content.ReadAsStreamAsync())
                    {
                        // Añadir la imagen desde el stream a la hoja de Excel
                        var picture = worksheet.AddPicture(imageStream, XLPictureFormat.Png) // Especifica el formato de imagen
                                               .MoveTo(worksheet.Cell(1, 5)) // Mover la imagen a la celda C2
                                               .Scale(0.5); // Escalar la imagen al 50% de su tamaño original
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al descargar la imagen: " + imagePath + ex.Message);
                }
            }

            //Formato de primer fila

            worksheet.Range("B1:D1").Merge();
            var rangoPrimerFila = worksheet.Range("A1:F1");
            rangoPrimerFila.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            rangoPrimerFila.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            // Cambiar la altura de la fila 1 (en puntos)
            worksheet.Row(1).Height = 42; // Altura de 42 puntos para que coincida con el logo


            //fila en blanco 
            currentRow++;
            worksheet.Cell(currentRow, 1).Value = "";

            //informacion de filtros
            currentRow++;
            worksheet.Cell(currentRow, 1).Value = "Desde";
            worksheet.Cell(currentRow, 2).Value = (filtros.FechaDesde != null) ? filtros.FechaDesde.ToString("dd/MM/yyyy") : "*";
            currentRow++;
            worksheet.Cell(currentRow, 1).Value = "Hasta";
            worksheet.Cell(currentRow, 2).Value = (filtros.FechaHasta != null) ? filtros.FechaHasta.ToString("dd/MM/yyyy") : "*";
            currentRow++;
            worksheet.Cell(currentRow, 1).Value = "Cliente";
            worksheet.Cell(currentRow, 2).Value = cliente != null ? cliente.razonSocial : "";

            //fila en blanco
            currentRow++;
            worksheet.Cell(currentRow, 1).Value = "";

            //cabezera
            currentRow++;
            var currentCell = 1;
            worksheet.Cell(currentRow, currentCell++).Value = "Nro de recibo";
            worksheet.Cell(currentRow, currentCell++).Value = "Fecha de cobro";
            worksheet.Cell(currentRow, currentCell++).Value = "Moneda";
            worksheet.Cell(currentRow, currentCell++).Value = "Importe de cobro";
            worksheet.Cell(currentRow, currentCell++).Value = "Imporde de cobro ME";

            //llenamos los datos de la tabla
            foreach (var item in list)
            {
                currentRow++;
                currentCell = 1;
                worksheet.Cell(currentRow, currentCell++).Value = item.NroRecibo;
                worksheet.Cell(currentRow, currentCell++).Value = item.FechaCobro.ToString("dd/MM/yyyy");
                worksheet.Cell(currentRow, currentCell++).Value = item.Moneda;
                worksheet.Cell(currentRow, currentCell++).Value = item.ImporteCobro;
                worksheet.Cell(currentRow, currentCell++).Value = item.ImporteCobroMe;
            }
            //-----------Le damos el formato a la cabecera----------------
            var rango = worksheet.Range("A7:E7"); //Seleccionamos un rango
            rango.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin); //Generamos las lineas exteriores
            rango.Style.Border.SetInsideBorder(XLBorderStyleValues.Thin); //Generamos las lineas interiores
            rango.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; //Alineamos horizontalmente
            rango.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;  //Alineamos verticalmente
            rango.Style.Fill.BackgroundColor = XLColor.LightSteelBlue; //Indicamos el color de background

            //Formato de filtros
            var rangoFiltros1 = worksheet.Range("A3:A5");
            rangoFiltros1.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
            rangoFiltros1.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            rangoFiltros1.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);
            rangoFiltros1.Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
            rangoFiltros1.Style.Fill.BackgroundColor = XLColor.LightSteelBlue;
            var rangoFiltros3 = worksheet.Range("B3:B5");
            rangoFiltros3.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            rangoFiltros3.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            rangoFiltros3.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);
            rangoFiltros3.Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
            //ajustamos ancho de columnas
            worksheet.Columns("A:Z").AdjustToContents();
            var content = new byte[0];
            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                content = stream.ToArray();
            }
            var fileName = "Reporte recibos - " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + ".xlsx";
            await js.InvokeAsync<object>("BlazorDownloadFile", fileName, Convert.ToBase64String(content));
        }
    }
    public async Task exportExcelCuentasCorrientes(List<CuentaCorrienteVM> list, FiltroCuentasCorrientesVM filtros, IJSRuntime js, UsuarioVM cliente)
    {
        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("principal");

            //Fecha de reporte, titulo y logo 
            var currentRow = 1;
            worksheet.Cell(currentRow, 1).Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            worksheet.Cell(currentRow, 1).Style.Font.FontSize = 11;

            worksheet.Cell(currentRow, 2).Value = "Cuentas corrientes";
            worksheet.Cell(currentRow, 2).Style.Font.FontSize = 18;

            // Buscamos logo y añadimos a excel
            var baseUri = new Uri(_navigation.BaseUri);
            var imagePath = _navigation.BaseUri + "/imagenes/logo/logo_empresa.png";

            // Descargar la imagen desde la web
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.GetAsync(imagePath);
                    response.EnsureSuccessStatusCode(); // Lanza una excepción si hay un error

                    using (var imageStream = await response.Content.ReadAsStreamAsync())
                    {
                        // Añadir la imagen desde el stream a la hoja de Excel
                        var picture = worksheet.AddPicture(imageStream, XLPictureFormat.Png) // Especifica el formato de imagen
                                               .MoveTo(worksheet.Cell(1, 10)) // Mover la imagen a la celda C2
                                               .Scale(0.5); // Escalar la imagen al 50% de su tamaño original
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al descargar la imagen: " + imagePath + ex.Message);
                }
            }

            //Formato de primer fila

            worksheet.Range("B1:I1").Merge();
            var rangoPrimerFila = worksheet.Range("A1:D1");
            rangoPrimerFila.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            rangoPrimerFila.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            // Cambiar la altura de la fila 1 (en puntos)
            worksheet.Row(1).Height = 42; // Altura de 42 puntos para que coincida con el logo


            //fila en blanco 
            currentRow++;
            worksheet.Cell(currentRow, 1).Value = "";

            //informacion de filtros
            currentRow++;
            worksheet.Cell(currentRow, 1).Value = "Desde";
            worksheet.Cell(currentRow, 2).Value = (filtros.FechaDesde != null) ? filtros.FechaDesde.ToString("dd/MM/yyyy") : "*";
            currentRow++;
            worksheet.Cell(currentRow, 1).Value = "Hasta";
            worksheet.Cell(currentRow, 2).Value = (filtros.FechaHasta != null) ? filtros.FechaHasta.ToString("dd/MM/yyyy") : "*";
            currentRow++;
            worksheet.Cell(currentRow, 1).Value = "Cliente";
            worksheet.Cell(currentRow, 2).Value = cliente != null ? cliente.razonSocial : "";

            //fila en blanco
            currentRow++;
            worksheet.Cell(currentRow, 1).Value = "";

            currentRow++;
            worksheet.Cell(currentRow, 1).Value = "Total pendiente: $" + list.Sum(x => x.importePendiente).ToString("N2", new System.Globalization.CultureInfo("es-AR"));
            worksheet.Cell(currentRow, 3).Value = "Total pagado: $" + list.Sum(x => x.importeBruto).ToString("N2", new System.Globalization.CultureInfo("es-AR"));
            worksheet.Cell(currentRow, 5).Value = "Total comprado: $" + (list.Sum(x => x.importePendiente) + list.Sum(x => x.importeBruto)).ToString("N2", new System.Globalization.CultureInfo("es-AR"));

            //fila en blanco
            currentRow++;
            worksheet.Cell(currentRow, 1).Value = "";

            //cabezera
            currentRow++;
            var currentCell = 1;
            worksheet.Cell(currentRow, currentCell).Value = "Nro de factura";
            worksheet.Cell(currentRow, currentCell++).Value = "Nro de remito";
            worksheet.Cell(currentRow, currentCell++).Value = "Fecha de factura";
            worksheet.Cell(currentRow, currentCell++).Value = "Importe bruto";
            worksheet.Cell(currentRow, currentCell++).Value = "Importe pendiente";
            worksheet.Cell(currentRow, currentCell++).Value = "Fecha de vencimiento";
            worksheet.Cell(currentRow, currentCell++).Value = "Dias de mora";

            //llenamos los datos de la tabla
            foreach (var item in list)
            {
                currentRow++;
                currentCell = 1;
                worksheet.Cell(currentRow, currentCell).Value = item.nro_Factura;
                worksheet.Cell(currentRow, currentCell++).Value = item.nro_remito;
                worksheet.Cell(currentRow, currentCell++).Value = item.fechaFactura.ToString("dd/MM/yyyy");
                worksheet.Cell(currentRow, currentCell++).Value = "$" + item.importeBruto.ToString("N2", new System.Globalization.CultureInfo("es-AR"));
                worksheet.Cell(currentRow, currentCell++).Value = "$" + item.importePendiente.ToString("N2", new System.Globalization.CultureInfo("es-AR"));
                worksheet.Cell(currentRow, currentCell++).Value = item.fechaVencimiento.ToString("dd/MM/yyyy");
                worksheet.Cell(currentRow, currentCell++).Value = item.dias_de_mora;
            }
            //-----------Le damos el formato a los totales----------------
            var rangoTotales = worksheet.Range("A7:E7"); //Seleccionamos un rangoTotales
            rangoTotales.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin); //Generamos las lineas exteriores
            rangoTotales.Style.Border.SetInsideBorder(XLBorderStyleValues.Thin); //Generamos las lineas interiores
            rangoTotales.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; //Alineamos horizontalmente
            rangoTotales.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;  //Alineamos verticalmente
            rangoTotales.Style.Fill.BackgroundColor = XLColor.LightSteelBlue; //Indicamos el color de background
            //-----------Le damos el formato a la cabecera----------------
            var rangoCabecera = worksheet.Range("A9:F9"); //Seleccionamos un rangoCabecera
            rangoCabecera.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin); //Generamos las lineas exteriores
            rangoCabecera.Style.Border.SetInsideBorder(XLBorderStyleValues.Thin); //Generamos las lineas interiores
            rangoCabecera.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; //Alineamos horizontalmente
            rangoCabecera.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;  //Alineamos verticalmente
            rangoCabecera.Style.Fill.BackgroundColor = XLColor.LightSteelBlue; //Indicamos el color de background

            //Formato de filtros
            var rangoFiltros1 = worksheet.Range("A3:A5");
            rangoFiltros1.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
            rangoFiltros1.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            rangoFiltros1.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);
            rangoFiltros1.Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
            rangoFiltros1.Style.Fill.BackgroundColor = XLColor.LightSteelBlue;
            var rangoFiltros3 = worksheet.Range("B3:B5");
            rangoFiltros3.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            rangoFiltros3.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            rangoFiltros3.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);
            rangoFiltros3.Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
            //ajustamos ancho de columnas
            worksheet.Columns("A:J").AdjustToContents();
            var content = new byte[0];
            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                content = stream.ToArray();
            }
            var fileName = "Reporte cuentas corrientes - " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + ".xlsx";
            await js.InvokeAsync<object>("BlazorDownloadFile", fileName, Convert.ToBase64String(content));
        }
    }
    public async Task exportExcelFacturas(List<FacturasSP> list, FiltroFacturasSP filtros, IJSRuntime js, UsuarioVM cliente)
    {
        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("principal");

            //Fecha de reporte, titulo y logo 
            var currentRow = 1;
            worksheet.Cell(currentRow, 1).Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            worksheet.Cell(currentRow, 1).Style.Font.FontSize = 11;

            worksheet.Cell(currentRow, 2).Value = "Facturas";
            worksheet.Cell(currentRow, 2).Style.Font.FontSize = 18;

            // Buscamos logo y añadimos a excel
            var baseUri = new Uri(_navigation.BaseUri);
            var imagePath = _navigation.BaseUri + "/imagenes/logo/logo_empresa.png";

            // Descargar la imagen desde la web
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.GetAsync(imagePath);
                    response.EnsureSuccessStatusCode(); // Lanza una excepción si hay un error

                    using (var imageStream = await response.Content.ReadAsStreamAsync())
                    {
                        // Añadir la imagen desde el stream a la hoja de Excel
                        var picture = worksheet.AddPicture(imageStream, XLPictureFormat.Png) // Especifica el formato de imagen
                                               .MoveTo(worksheet.Cell(1, 6)) // Mover la imagen a la celda C2
                                               .Scale(0.5); // Escalar la imagen al 50% de su tamaño original
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al descargar la imagen: " + imagePath + ex.Message);
                }
            }

            //Formato de primer fila

            worksheet.Range("B1:E1").Merge();
            var rangoPrimerFila = worksheet.Range("A1:F1");
            rangoPrimerFila.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            rangoPrimerFila.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            // Cambiar la altura de la fila 1 (en puntos)
            worksheet.Row(1).Height = 42; // Altura de 42 puntos para que coincida con el logo


            //fila en blanco 
            currentRow++;
            worksheet.Cell(currentRow, 1).Value = "";

            //informacion de filtros
            currentRow++;
            worksheet.Cell(currentRow, 1).Value = "Desde";
            worksheet.Cell(currentRow, 2).Value = (filtros.FechaDesde != null) ? filtros.FechaDesde.ToString("dd/MM/yyyy") : "*";
            currentRow++;
            worksheet.Cell(currentRow, 1).Value = "Hasta";
            worksheet.Cell(currentRow, 2).Value = (filtros.FechaHasta != null) ? filtros.FechaHasta.ToString("dd/MM/yyyy") : "*";
            currentRow++;
            worksheet.Cell(currentRow, 1).Value = "Cliente";
            worksheet.Cell(currentRow, 2).Value = cliente != null ? cliente.razonSocial : "";

            //fila en blanco
            currentRow++;
            worksheet.Cell(currentRow, 1).Value = "";

            //cabezera
            currentRow++;
            var currentCell = 1;
            worksheet.Cell(currentRow, currentCell++).Value = "Nro de documento";
            worksheet.Cell(currentRow, currentCell++).Value = "Nro de factura";
            worksheet.Cell(currentRow, currentCell++).Value = "Precio total";
            worksheet.Cell(currentRow, currentCell++).Value = "Fecha de factura";
            worksheet.Cell(currentRow, currentCell++).Value = "Fecha de vencimiento de factura";
            worksheet.Cell(currentRow, currentCell++).Value = "Nro de remito";

            //llenamos los datos de la tabla
            foreach (var item in list)
            {
                currentRow++;
                currentCell = 1;
                worksheet.Cell(currentRow, currentCell++).Value = item.Nro_doc;
                worksheet.Cell(currentRow, currentCell++).Value = item.NroFactura;
                worksheet.Cell(currentRow, currentCell++).Value = item.Precio_total;
                worksheet.Cell(currentRow, currentCell++).Value = item.Fecha_factura?.ToString("dd/MM/yyyy");
                worksheet.Cell(currentRow, currentCell++).Value = item.Fecha_vto_factura?.ToString("dd/MM/yyyy");
                worksheet.Cell(currentRow, currentCell++).Value = item.Nro_remito;
            }
            //-----------Le damos el formato a la cabecera----------------
            var rango = worksheet.Range("A7:F7"); //Seleccionamos un rango
            rango.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin); //Generamos las lineas exteriores
            rango.Style.Border.SetInsideBorder(XLBorderStyleValues.Thin); //Generamos las lineas interiores
            rango.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; //Alineamos horizontalmente
            rango.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;  //Alineamos verticalmente
            rango.Style.Fill.BackgroundColor = XLColor.LightSteelBlue; //Indicamos el color de background

            //Formato de filtros
            var rangoFiltros1 = worksheet.Range("A3:A5");
            rangoFiltros1.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
            rangoFiltros1.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            rangoFiltros1.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);
            rangoFiltros1.Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
            rangoFiltros1.Style.Fill.BackgroundColor = XLColor.LightSteelBlue;
            var rangoFiltros3 = worksheet.Range("B3:B5");
            rangoFiltros3.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            rangoFiltros3.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            rangoFiltros3.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);
            rangoFiltros3.Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
            //ajustamos ancho de columnas
            worksheet.Columns("A:Z").AdjustToContents();
            var content = new byte[0];
            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                content = stream.ToArray();
            }
            var fileName = "Reporte facturas - " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + ".xlsx";
            await js.InvokeAsync<object>("BlazorDownloadFile", fileName, Convert.ToBase64String(content));
        }
    }
    public async Task exportExcelSeguimientoPedidos(List<SeguimientoPedidoVM> list, FiltroSeguimientoPedidos filtros, IJSRuntime js, UsuarioVM cliente)
    {
        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("principal");

            //Fecha de reporte, titulo y logo 
            var currentRow = 1;
            worksheet.Cell(currentRow, 1).Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            worksheet.Cell(currentRow, 1).Style.Font.FontSize = 11;

            worksheet.Cell(currentRow, 2).Value = "Seguimiento de pedidos";
            worksheet.Cell(currentRow, 2).Style.Font.FontSize = 18;

            // Buscamos logo y añadimos a excel
            var baseUri = new Uri(_navigation.BaseUri);
            var imagePath = _navigation.BaseUri + "/imagenes/logo/logo_empresa.png";

            // Descargar la imagen desde la web
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.GetAsync(imagePath);
                    response.EnsureSuccessStatusCode(); // Lanza una excepción si hay un error

                    using (var imageStream = await response.Content.ReadAsStreamAsync())
                    {
                        // Añadir la imagen desde el stream a la hoja de Excel
                        var picture = worksheet.AddPicture(imageStream, XLPictureFormat.Png) // Especifica el formato de imagen
                                               .MoveTo(worksheet.Cell(1, 10)) // Mover la imagen a la celda C2
                                               .Scale(0.5); // Escalar la imagen al 50% de su tamaño original
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al descargar la imagen: " + imagePath + ex.Message);
                }
            }

            //Formato de primer fila

            worksheet.Range("B1:I1").Merge();
            var rangoPrimerFila = worksheet.Range("A1:D1");
            rangoPrimerFila.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            rangoPrimerFila.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            // Cambiar la altura de la fila 1 (en puntos)
            worksheet.Row(1).Height = 42; // Altura de 42 puntos para que coincida con el logo


            //fila en blanco 
            currentRow++;
            worksheet.Cell(currentRow, 1).Value = "";

            //informacion de filtros
            currentRow++;
            worksheet.Cell(currentRow, 1).Value = "Desde";
            worksheet.Cell(currentRow, 2).Value = (filtros.FechaDesde != null) ? filtros.FechaDesde.ToString("dd/MM/yyyy") : "*";
            currentRow++;
            worksheet.Cell(currentRow, 1).Value = "Hasta";
            worksheet.Cell(currentRow, 2).Value = (filtros.FechaHasta != null) ? filtros.FechaHasta.ToString("dd/MM/yyyy") : "*";
            currentRow++;
            worksheet.Cell(currentRow, 1).Value = "Cliente";
            worksheet.Cell(currentRow, 2).Value = cliente != null ? cliente.razonSocial : "";

            //fila en blanco
            currentRow++;
            worksheet.Cell(currentRow, 1).Value = "";

            //cabezera
            currentRow++;
            var currentCell = 1;
            worksheet.Cell(currentRow, currentCell++).Value = "Fecha de orden";
            worksheet.Cell(currentRow, currentCell++).Value = "Nro de documento";
            worksheet.Cell(currentRow, currentCell++).Value = "Código de articulo";
            worksheet.Cell(currentRow, currentCell++).Value = "Cantidad enviada";
            worksheet.Cell(currentRow, currentCell++).Value = "Código de transportista";
            worksheet.Cell(currentRow, currentCell++).Value = "Transportista";
            worksheet.Cell(currentRow, currentCell++).Value = "Estado";
            worksheet.Cell(currentRow, currentCell++).Value = "Nro de documento EDI";
            worksheet.Cell(currentRow, currentCell++).Value = "Nro de remito";
            worksheet.Cell(currentRow, currentCell++).Value = "Fecha de entrega";

            //llenamos los datos de la tabla
            foreach (var item in list)
            {
                currentRow++;
                currentCell = 1;
                worksheet.Cell(currentRow, currentCell++).Value = item.Fecha_orden;
                worksheet.Cell(currentRow, currentCell++).Value = item.Nro_doc;
                worksheet.Cell(currentRow, currentCell++).Value = item.CodArticulo;
                worksheet.Cell(currentRow, currentCell++).Value = item.Cant_enviada;
                worksheet.Cell(currentRow, currentCell++).Value = item.CodTransportista;
                worksheet.Cell(currentRow, currentCell++).Value = item.Transportista;
                worksheet.Cell(currentRow, currentCell++).Value = item.Estado;
                worksheet.Cell(currentRow, currentCell++).Value = item.Nro_doc_edi;
                worksheet.Cell(currentRow, currentCell++).Value = item.Nro_remito;
                worksheet.Cell(currentRow, currentCell++).Value = item.Fecha_entrega?.ToString("dd/MM/yyyy");
            }
            //-----------Le damos el formato a la cabecera----------------
            var rango = worksheet.Range("A7:J7"); //Seleccionamos un rango
            rango.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin); //Generamos las lineas exteriores
            rango.Style.Border.SetInsideBorder(XLBorderStyleValues.Thin); //Generamos las lineas interiores
            rango.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; //Alineamos horizontalmente
            rango.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;  //Alineamos verticalmente
            rango.Style.Fill.BackgroundColor = XLColor.LightSteelBlue; //Indicamos el color de background

            //Formato de filtros
            var rangoFiltros1 = worksheet.Range("A3:A5");
            rangoFiltros1.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
            rangoFiltros1.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            rangoFiltros1.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);
            rangoFiltros1.Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
            rangoFiltros1.Style.Fill.BackgroundColor = XLColor.LightSteelBlue;
            var rangoFiltros3 = worksheet.Range("B3:B5");
            rangoFiltros3.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            rangoFiltros3.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            rangoFiltros3.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);
            rangoFiltros3.Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
            //ajustamos ancho de columnas
            worksheet.Columns("A:Z").AdjustToContents();
            var content = new byte[0];
            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                content = stream.ToArray();
            }
            var fileName = "Reporte seguimiento de pedidos - " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + ".xlsx";
            await js.InvokeAsync<object>("BlazorDownloadFile", fileName, Convert.ToBase64String(content));
        }
    }

    public async Task exportExcelComprasAnticipadasPendientes(List<ComprasAnticipadasVM> list, FiltroComprasAnticipadasPendientes filtros, IJSRuntime js, UsuarioVM cliente)
    {
        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("principal");

            //Fecha de reporte, titulo y logo 
            var currentRow = 1;
            worksheet.Cell(currentRow, 1).Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            worksheet.Cell(currentRow, 1).Style.Font.FontSize = 11;

            worksheet.Cell(currentRow, 2).Value = "Compras Anticipadas Pendientes";
            worksheet.Cell(currentRow, 2).Style.Font.FontSize = 18;

            // Buscamos logo y añadimos a excel
            var baseUri = new Uri(_navigation.BaseUri);
            var imagePath = _navigation.BaseUri + "/imagenes/logo/logo_empresa.png";

            // Descargar la imagen desde la web
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.GetAsync(imagePath);
                    response.EnsureSuccessStatusCode(); // Lanza una excepción si hay un error

                    using (var imageStream = await response.Content.ReadAsStreamAsync())
                    {
                        // Añadir la imagen desde el stream a la hoja de Excel
                        var picture = worksheet.AddPicture(imageStream, XLPictureFormat.Png) // Especifica el formato de imagen
                                               .MoveTo(worksheet.Cell(1, 10)) // Mover la imagen a la celda C2
                                               .Scale(0.5); // Escalar la imagen al 50% de su tamaño original
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al descargar la imagen: " + imagePath + ex.Message);
                }
            }

            //Formato de primer fila

            worksheet.Range("B1:I1").Merge();
            var rangoPrimerFila = worksheet.Range("A1:D1");
            rangoPrimerFila.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            rangoPrimerFila.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            // Cambiar la altura de la fila 1 (en puntos)
            worksheet.Row(1).Height = 42; // Altura de 42 puntos para que coincida con el logo


            //fila en blanco 
            currentRow++;
            worksheet.Cell(currentRow, 1).Value = "";

            //informacion de filtros
            currentRow++;
            worksheet.Cell(currentRow, 1).Value = "Desde";
            worksheet.Cell(currentRow, 2).Value = (filtros.FechaDesde != null) ? filtros.FechaDesde.ToString("dd/MM/yyyy") : "*";
            currentRow++;
            worksheet.Cell(currentRow, 1).Value = "Hasta";
            worksheet.Cell(currentRow, 2).Value = (filtros.FechaHasta != null) ? filtros.FechaHasta.ToString("dd/MM/yyyy") : "*";
            currentRow++;
            worksheet.Cell(currentRow, 1).Value = "Cliente";
            worksheet.Cell(currentRow, 2).Value = cliente != null ? cliente.razonSocial : "";

            //fila en blanco
            currentRow++;
            worksheet.Cell(currentRow, 1).Value = "";

            //cabezera
            currentRow++;
            var currentCell = 1;
            worksheet.Cell(currentRow, currentCell++).Value = "Nro. de Documento";
            worksheet.Cell(currentRow, currentCell++).Value = "Nro. de Linea";
            worksheet.Cell(currentRow, currentCell++).Value = "Fecha";
            worksheet.Cell(currentRow, currentCell++).Value = "Código de Artículo";
            worksheet.Cell(currentRow, currentCell++).Value = "Cantidad Pedida";
            worksheet.Cell(currentRow, currentCell++).Value = "Cantidad Entregada";
            worksheet.Cell(currentRow, currentCell++).Value = "Cantidad Pendiente";

            //llenamos los datos de la tabla
            foreach (var item in list)
            {
                currentRow++;
                currentCell = 1;
                worksheet.Cell(currentRow, currentCell++).Value = item.NroDoc;
                worksheet.Cell(currentRow, currentCell++).Value = item.NroLinea;
                worksheet.Cell(currentRow, currentCell++).Value = item.FechaOrden;
                worksheet.Cell(currentRow, currentCell++).Value = item.CodArticulo;
                worksheet.Cell(currentRow, currentCell++).Value = item.CantPedida;
                worksheet.Cell(currentRow, currentCell++).Value = item.CantEntregada;
                worksheet.Cell(currentRow, currentCell++).Value = item.CantPendiente;
            }
            //-----------Le damos el formato a la cabecera----------------
            var rango = worksheet.Range("A7:G7"); //Seleccionamos un rango
            rango.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin); //Generamos las lineas exteriores
            rango.Style.Border.SetInsideBorder(XLBorderStyleValues.Thin); //Generamos las lineas interiores
            rango.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; //Alineamos horizontalmente
            rango.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;  //Alineamos verticalmente
            rango.Style.Fill.BackgroundColor = XLColor.LightSteelBlue; //Indicamos el color de background

            //Formato de filtros
            var rangoFiltros1 = worksheet.Range("A3:A5");
            rangoFiltros1.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
            rangoFiltros1.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            rangoFiltros1.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);
            rangoFiltros1.Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
            rangoFiltros1.Style.Fill.BackgroundColor = XLColor.LightSteelBlue;
            var rangoFiltros3 = worksheet.Range("B3:B5");
            rangoFiltros3.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            rangoFiltros3.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            rangoFiltros3.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);
            rangoFiltros3.Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
            //ajustamos ancho de columnas
            worksheet.Columns("A:Z").AdjustToContents();
            var content = new byte[0];
            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                content = stream.ToArray();
            }
            var fileName = "Reporte compras anticipadas pendientes - " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + ".xlsx";
            await js.InvokeAsync<object>("BlazorDownloadFile", fileName, Convert.ToBase64String(content));
        }
    }

    public async Task exportExcelRemitos(List<RemitoVM> list, FiltroRemitosVM filtros, IJSRuntime js, UsuarioVM cliente)
    {
        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("principal");

            //Fecha de reporte, titulo y logo 
            var currentRow = 1;
            worksheet.Cell(currentRow, 1).Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            worksheet.Cell(currentRow, 1).Style.Font.FontSize = 11;

            worksheet.Cell(currentRow, 2).Value = "Remitos";
            worksheet.Cell(currentRow, 2).Style.Font.FontSize = 18;

            // Buscamos logo y añadimos a excel
            var baseUri = new Uri(_navigation.BaseUri);
            var imagePath = _navigation.BaseUri + "/imagenes/logo/logo_empresa.png";

            // Descargar la imagen desde la web
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.GetAsync(imagePath);
                    response.EnsureSuccessStatusCode(); // Lanza una excepción si hay un error

                    using (var imageStream = await response.Content.ReadAsStreamAsync())
                    {
                        // Añadir la imagen desde el stream a la hoja de Excel
                        var picture = worksheet.AddPicture(imageStream, XLPictureFormat.Png) // Especifica el formato de imagen
                                               .MoveTo(worksheet.Cell(1, 4)) // Mover la imagen a la celda C2
                                               .Scale(0.5); // Escalar la imagen al 50% de su tamaño original
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al descargar la imagen: " + imagePath + ex.Message);
                }
            }

            //Formato de primer fila

            worksheet.Range("B1:C1").Merge();
            var rangoPrimerFila = worksheet.Range("A1:D1");
            rangoPrimerFila.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            rangoPrimerFila.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            // Cambiar la altura de la fila 1 (en puntos)
            worksheet.Row(1).Height = 42; // Altura de 42 puntos para que coincida con el logo


            //fila en blanco 
            currentRow++;
            worksheet.Cell(currentRow, 1).Value = "";

            //informacion de filtros
            currentRow++;
            worksheet.Cell(currentRow, 1).Value = "Desde";
            worksheet.Cell(currentRow, 2).Value = (filtros.FechaDesde != null) ? filtros.FechaDesde.ToString("dd/MM/yyyy") : "*";
            currentRow++;
            worksheet.Cell(currentRow, 1).Value = "Hasta";
            worksheet.Cell(currentRow, 2).Value = (filtros.FechaHasta != null) ? filtros.FechaHasta.ToString("dd/MM/yyyy") : "*";
            currentRow++;
            worksheet.Cell(currentRow, 1).Value = "Cliente";
            worksheet.Cell(currentRow, 2).Value = cliente != null ? cliente.razonSocial : "";

            //fila en blanco
            currentRow++;
            worksheet.Cell(currentRow, 1).Value = "";

            //cabezera
            currentRow++;
            var currentCell = 1;
            worksheet.Cell(currentRow, currentCell++).Value = "Fecha de envío";
            worksheet.Cell(currentRow, currentCell++).Value = "Nro de remito";

            //llenamos los datos de la tabla
            foreach (var item in list)
            {
                currentRow++;
                currentCell = 1;
                worksheet.Cell(currentRow, currentCell++).Value = item.FechaEnvio.ToString("dd/MM/yyyy");
                worksheet.Cell(currentRow, currentCell++).Value = item.NroRemito;
            }
            //-----------Le damos el formato a la cabecera----------------
            var rango = worksheet.Range("A7:B7"); //Seleccionamos un rango
            rango.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin); //Generamos las lineas exteriores
            rango.Style.Border.SetInsideBorder(XLBorderStyleValues.Thin); //Generamos las lineas interiores
            rango.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center; //Alineamos horizontalmente
            rango.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;  //Alineamos verticalmente
            rango.Style.Fill.BackgroundColor = XLColor.LightSteelBlue; //Indicamos el color de background

            //Formato de filtros
            var rangoFiltros1 = worksheet.Range("A3:A5");
            rangoFiltros1.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
            rangoFiltros1.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            rangoFiltros1.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);
            rangoFiltros1.Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
            rangoFiltros1.Style.Fill.BackgroundColor = XLColor.LightSteelBlue;
            var rangoFiltros3 = worksheet.Range("B3:B5");
            rangoFiltros3.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            rangoFiltros3.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            rangoFiltros3.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);
            rangoFiltros3.Style.Border.SetInsideBorder(XLBorderStyleValues.Thin);
            //ajustamos ancho de columnas
            worksheet.Columns("A:Z").AdjustToContents();
            var content = new byte[0];
            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                content = stream.ToArray();
            }
            var fileName = "Reporte de remitos - " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + ".xlsx";
            await js.InvokeAsync<object>("BlazorDownloadFile", fileName, Convert.ToBase64String(content));
        }
    }
}