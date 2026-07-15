using Dapper;
using Google.Api;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PortalDePedidosModel;
using PortalDePedidosServidor.Models;
using PortalDePedidosServidor.ModelsDataWhereHouse;
using PortalDePedidosServidor.ModelsJDE;
using PortalDePedidosShared.DataWhereHouse;
using PortalDePedidosShared.IngresoPedidosVM;
using PortalDePedidosShared.UsuariosVM;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.Arm;

namespace PortalDePedidosServidor.Servicios
{
    public class JDEService
    {
        private JdeContext _jdeContext;
        private LogService _logService { get; set; }
        public JDEService(JdeContext jdeContext, LogService logService)
        {
            _jdeContext = jdeContext;
            _logService = logService;
        }

        public async Task<InfoClienteVM> GetInfoCliente(string nroJDE)
        {
            var infoVM = new InfoClienteVM();


            var infoDB = await _jdeContext.F0101s.Where(x => x.Aban8 == int.Parse(nroJDE)).FirstOrDefaultAsync();
            if (infoDB != null)
            {
                infoVM.nroJDE = (int)infoDB.Aban8;
                infoVM.nombre = infoDB.Abalph.Trim();
                infoVM.cuit = infoDB.Abtax.Trim();
                infoVM.representante = infoDB.Abac02.Trim();
                infoVM.ABAC01 = infoDB.Abac01;
            }


            return infoVM;
        }

        public async Task GuardarPedidoEnJDE(IngresoPedidoVM ingreso)
        {
            F47011 ingresoJDE = new F47011();

            if (ingreso.Doc != "")
            {
                ingresoJDE.Syedoc = double.Parse(ingreso.Doc);
                ingresoJDE.Syorby = ingreso.Doc;
}
            if (ingreso.Dct != "")
            {
                ingresoJDE.Syedct = ingreso.Dct;
            }
            if (ingreso.Kco != "")
            {
                ingresoJDE.Syekco = ingreso.Kco;
            }
            if (ingreso.Dst != "")
            {
                ingresoJDE.Syedst = ingreso.Dst;
            }
            if (ingreso.An8 != "")
            {
                ingresoJDE.Syan8 = double.Parse(ingreso.An8);
                ingresoJDE.Syshan = double.Parse(ingreso.An8);
            }
            if (ingreso.Mcu != "")
            {
                ingresoJDE.Symcu = ingreso.Mcu;
            }
            if (ingreso.Cars != "")
            {
                ingresoJDE.Sycars = double.Parse(ingreso.Cars);
            }
            if (ingreso.zonaDestino != "")
            {
                ingresoJDE.Syzon = ingreso.zonaDestino;
            }

            if (!ingreso.ordenDeCompra.IsNullOrEmpty())
            {
                ingresoJDE.Sydel2 = ingreso.ordenDeCompra;
            }

            //Solo guarda Surpat este dato
            //if (ingreso.DEL2 != "")
            //{
            //    ingresoJDE.Syorby = ingreso.Doc;
            //}

            //Fecha para la que se solicita el envío
            ingresoJDE.Sydrqj = Conversiones.Date2JulianJDE(ingreso.fechaEnvio);
            //Fecha en la que se genera la orden, se pidio q sea la fecha actual
            ingresoJDE.Sytrdj = Conversiones.Date2JulianJDE(DateTime.Now);

            //Estado de pedido en JDE, lo dejo en blanco
            ingresoJDE.Syedsp = "N";

            ingresoJDE.Syedsq = 0;
            ingresoJDE.Syedln = 0;
            ingresoJDE.Syeddt = 0;
            ingresoJDE.Syeddl = 0;
            ingresoJDE.Synxdj = 0;
            ingresoJDE.Syssdj = 0;
            ingresoJDE.Sydoco = 0;
            ingresoJDE.Sypa8 = 0;
            ingresoJDE.Sypddj = 0;
            ingresoJDE.Syopdj = 0;
            ingresoJDE.Syaddj = 0;
            ingresoJDE.Sycndj = 0;
            ingresoJDE.Sypefj = 0;
            ingresoJDE.Syppdj = 0;
            ingresoJDE.Sypsdj = 0;
            ingresoJDE.Sytrdc = 0;
            ingresoJDE.Sypcrt = 0;
            ingresoJDE.Syanby = 0;
            ingresoJDE.Syotot = 0;
            ingresoJDE.Sytotc = 0;
            ingresoJDE.Sycexp = 0;
            ingresoJDE.Sycrr = 0;
            ingresoJDE.Syfap = 0;
            ingresoJDE.Syfcst = 0;
            ingresoJDE.Syurdt = 0;
            ingresoJDE.Syurat = 0;
            ingresoJDE.Syurab = 0;
            ingresoJDE.Sysoor = 0;
            ingresoJDE.Sypmdt = 0;
            ingresoJDE.Syrsdt = 0;
            ingresoJDE.Syrqsj = 0;
            ingresoJDE.Sypstm = 0;
            ingresoJDE.Sypdtt = 0;
            ingresoJDE.Syoptt = 0;
            ingresoJDE.Sydrqt = 0;
            ingresoJDE.Syadtm = 0;
            ingresoJDE.Syadlj = 0;
            ingresoJDE.Sypban = 0;
            ingresoJDE.Syitan = 0;
            ingresoJDE.Syftan = 0;
            ingresoJDE.Sydvan = 0;
            ingresoJDE.Sydoc1 = 0;
            ingresoJDE.Sycord = 0;
            ingresoJDE.Syrsht = 0;
            ingresoJDE.Syoptc = 0;
            ingresoJDE.Syopld = 0;
            ingresoJDE.Syopbk = 0;
            ingresoJDE.Syopsb = 0;
            ingresoJDE.Sypran8 = 0;
            ingresoJDE.Syprcidln = 0;
            ingresoJDE.Syoppid = 0;
            ingresoJDE.Syccidln = 0;
            ingresoJDE.Syshccidln = 0;
            ingresoJDE.Syexnm0 = 0;
            ingresoJDE.Syexnm1 = 0;
            ingresoJDE.Syexnm2 = 0;
            ingresoJDE.Syexnmp0 = 0;
            ingresoJDE.Syexnmp1 = 0;
            ingresoJDE.Syexnmp2 = 0;
            ingresoJDE.Sypohd01 = 0;
            ingresoJDE.Sypohd02 = 0;
            ingresoJDE.Sypohab01 = 0;
            ingresoJDE.Sypohab02 = 0;

            ingresoJDE.Sydel1 = ingreso.datosPedido.observaciones;
            //if (ingreso.compraEnDolares)
            //    ingresoJDE.Sycrcd = "USD";
            ingresoJDE.Sycrcd = ingreso.cliente.moneda;

                _jdeContext.Entry(ingresoJDE).State = EntityState.Added;
                await _jdeContext.SaveChangesAsync();
            

        }

        public async Task GuardarPedidoSGEnJDE(IngresoPedidoVM ingreso)
        {
            var ingresoSG = ingreso.seleccionadosSG.Where(x => x.CodArticulo != "905").FirstOrDefault();

            F47011 ingresoJDE = new F47011();

            if (ingreso.Doc != "")
            {
                ingresoJDE.Syedoc = double.Parse(ingreso.Doc); // en mapeo SG, queda igual
                ingresoJDE.Syorby = ingreso.Doc;
}
            
            ingresoJDE.Syedct = "XX"; // en mapeo SG
            ingresoJDE.Syvr02 = ingresoSG.NroFactura; // en mapeo SG

            //ingresoJDE.Symot = ingresoSG.CodTipoFlete.Trim(); // en mapeo SG
            ingresoJDE.Symot = Conversiones.ConfigurarFleteSG(ingreso.fleteEnviadoPor, ingreso.fleteAbonadoEn, ingresoSG.CodTipoFlete); // en mapeo SG

            if (ingreso.Kco != "")
            {
                ingresoJDE.Syekco = ingresoSG.CiaDoc; // en mapeo SG
            }
            
            ingresoJDE.Syedst = "999"; // en mapeo SG

            
            ingresoJDE.Syan8 = ingresoSG.CodCliente; // en mapeo SG
            ingresoJDE.Syshan = ingresoSG.CodCliente; // en mapeo SG
            
            
            ingresoJDE.Symcu = ingresoSG.Ceco.PadLeft(12, ' '); // en mapeo SG

            if (ingreso.Cars != "")
            {
                ingresoJDE.Sycars = double.Parse(ingreso.Cars);
            }
            if (ingreso.zonaDestino != "")
            {
                ingresoJDE.Syzon = ingreso.zonaDestino;
            }

            if (!ingreso.ordenDeCompra.IsNullOrEmpty())
            {
                ingresoJDE.Sydel2 = ingreso.ordenDeCompra;
            }

            //Solo guarda Surpat este dato
            //if (ingreso.DEL2 != "")
            //{
            //    ingresoJDE.Syorby = ingreso.Doc;
            //}

            //Fecha para la que se solicita el envío
            ingresoJDE.Sydrqj = Conversiones.Date2JulianJDE(ingreso.fechaEnvio);
            //Fecha en la que se genera la orden, se pidio q sea la fecha actual
            ingresoJDE.Sytrdj = Conversiones.Date2JulianJDE(DateTime.Now);

            //Estado de pedido en JDE, lo dejo en blanco
            ingresoJDE.Syedsp = "N";

            ingresoJDE.Syedsq = 0; // en mapeo SG
            ingresoJDE.Syedln = 1000; // en mapeo SG
            ingresoJDE.Syeddt = 0;
            ingresoJDE.Syeddl = 0;
            ingresoJDE.Synxdj = 0;
            ingresoJDE.Syssdj = 0;
            ingresoJDE.Sydoco = 0;
            ingresoJDE.Sypa8 = 0;
            ingresoJDE.Sypddj = 0;
            ingresoJDE.Syopdj = 0;
            ingresoJDE.Syaddj = 0;
            ingresoJDE.Sycndj = 0;
            ingresoJDE.Sypefj = 0;
            ingresoJDE.Syppdj = 0;
            ingresoJDE.Sypsdj = 0;
            ingresoJDE.Sytrdc = 0;
            ingresoJDE.Sypcrt = 0;
            ingresoJDE.Syanby = 0;
            ingresoJDE.Syotot = 0;
            ingresoJDE.Sytotc = 0;
            ingresoJDE.Sycexp = 0;
            ingresoJDE.Sycrr = 0;
            ingresoJDE.Syfap = 0;
            ingresoJDE.Syfcst = 0;
            ingresoJDE.Syurdt = 0;
            ingresoJDE.Syurat = 0;
            ingresoJDE.Syurab = 0;
            ingresoJDE.Sysoor = 0;
            ingresoJDE.Sypmdt = 0;
            ingresoJDE.Syrsdt = 0;
            ingresoJDE.Syrqsj = 0;
            ingresoJDE.Sypstm = 0;
            ingresoJDE.Sypdtt = 0;
            ingresoJDE.Syoptt = 0;
            ingresoJDE.Sydrqt = 0;
            ingresoJDE.Syadtm = 0;
            ingresoJDE.Syadlj = 0;
            ingresoJDE.Sypban = 0;
            ingresoJDE.Syitan = 0;
            ingresoJDE.Syftan = 0;
            ingresoJDE.Sydvan = 0;
            ingresoJDE.Sydoc1 = 0;
            ingresoJDE.Sycord = 0;
            ingresoJDE.Syrsht = 0;
            ingresoJDE.Syoptc = 0;
            ingresoJDE.Syopld = 0;
            ingresoJDE.Syopbk = 0;
            ingresoJDE.Syopsb = 0;
            ingresoJDE.Sypran8 = 0;
            ingresoJDE.Syprcidln = 0;
            ingresoJDE.Syoppid = 0;
            ingresoJDE.Syccidln = 0;
            ingresoJDE.Syshccidln = 0;
            ingresoJDE.Syexnm0 = 0;
            ingresoJDE.Syexnm1 = 0;
            ingresoJDE.Syexnm2 = 0;
            ingresoJDE.Syexnmp0 = 0;
            ingresoJDE.Syexnmp1 = 0;
            ingresoJDE.Syexnmp2 = 0;
            ingresoJDE.Sypohd01 = 0;
            ingresoJDE.Sypohd02 = 0;
            ingresoJDE.Sypohab01 = 0;
            ingresoJDE.Sypohab02 = 0;
            ingresoJDE.Sykcoo = ingresoSG.CiaDoc;// en mapeo SG
            ingresoJDE.Sydcto = "SG";// en mapeo SG
            ingresoJDE.Syokco = ingresoSG.CiaDoc;// en mapeo SG
            ingresoJDE.Syoorn = ingresoSG.NroDoc.ToString().PadRight(8, ' ');// en mapeo SG ej 123456bb, se completa con b hasta 8 caracteres
            ingresoJDE.Syocto = ingresoSG.TipoDoc;// en mapeo SG

            ingresoJDE.Sydel1 = ingreso.datosPedido.observaciones;
            //if (ingreso.compraEnDolares)
            //    ingresoJDE.Sycrcd = "USD";
            ingresoJDE.Sycrcd = ingresoSG.Moneda; // en mapeo SG

            _jdeContext.Entry(ingresoJDE).State = EntityState.Added;
                await _jdeContext.SaveChangesAsync();
            

        }

        public async Task GuardarComentarioJDE(IngresoPedidoVM ingreso)
        {
            if (!ingreso.datosPedido.observaciones.IsNullOrEmpty())
            {
                F55sp002 comentario  = new F55sp002();
                comentario.Svedoc = double.Parse(ingreso.Doc);
                comentario.Svedct= ingreso.Dct;
                comentario.Svekco= ingreso.Kco;
                comentario.Svedln = 1000;//Pongo siempre la linea 1 para asegurarme de que sea correcta (siempre va a haber por lo menos un articulo)
                comentario.Svotitmdsc = Conversiones.Left(ingreso.datosPedido.observaciones,120);

                    _jdeContext.Entry(comentario).State = EntityState.Added;
                    await _jdeContext.SaveChangesAsync();
                
            }

        }

        public async Task GuardarPedidoHijoEnJDE(IngresoPedidoVM ingreso)
        {
            var aux = 0;
            var fechaHoy = DateTime.Now;
            foreach(var item in ingreso.articulos)
            {
                aux++;
                F47012 pedidoHijo = new F47012();

                pedidoHijo.Szedoc =double.Parse(ingreso.Doc);
                pedidoHijo.Szedct = ingreso.Dct;
                pedidoHijo.Szekco = ingreso.Kco;
                pedidoHijo.Szedst = ingreso.Dst;
                pedidoHijo.Szedln = aux * 1000;
                pedidoHijo.Szlnid= aux * 1000;
                pedidoHijo.Szan8 =double.Parse(ingreso.An8);
                pedidoHijo.Szshan = double.Parse(ingreso.An8);
                pedidoHijo.Szitm = item.CodCortoArticulo;
                pedidoHijo.Szlitm = item.CodArticulo;
                pedidoHijo.Szaitm = item.CodArticulo;
                pedidoHijo.Szuorg = item.CalcularUNTotal() * 10000;//asi estaba en portal viejo
                pedidoHijo.Szmcu = ingreso.Mcu;
                pedidoHijo.Szlob = ingreso.Lob;
                pedidoHijo.Szmot = ((int)Conversiones.ConfigurarFlete(ingreso.fleteEnviadoPor, ingreso.fleteAbonadoEn)).ToString();
                pedidoHijo.Szdrqj = Conversiones.Date2JulianJDE(ingreso.fechaEnvio);
                pedidoHijo.Sztrdj = Conversiones.Date2JulianJDE(fechaHoy);
                pedidoHijo.Szrsdj = Conversiones.Date2JulianJDE(ingreso.datosPedido.fechaDeEntrega);

                //Agregado del 04/05/2015
                //Para que no falle la custom de limite de credito y las ordenes no queden bloqueadas, 
                //se necesita escribir un blanco en el campo SZURRG (Rodrigo Martin - TGV)
                pedidoHijo.Szurrf = " ";

                pedidoHijo.Szedsq = 0;
                pedidoHijo.Szeddt = 0;
                pedidoHijo.Szeddl = 0;
                pedidoHijo.Szdoco = 0;
                pedidoHijo.Szogno = 0;
                pedidoHijo.Szrlln = 0;
                pedidoHijo.Szdmcs = 0;
                pedidoHijo.Szpa8 = 0;
                pedidoHijo.Szpddj = 0;
                pedidoHijo.Szopdj = 0;
                pedidoHijo.Szaddj = 0;
                pedidoHijo.Szivd = 0;
                pedidoHijo.Szcndj = 0;
                pedidoHijo.Szdgl = 0;
                //pedidoHijo.Szrsdj = 0;
                pedidoHijo.Szpefj = 0;
                pedidoHijo.Szppdj = 0;
                pedidoHijo.Szpsdj = 0;
                pedidoHijo.Szfrmp = 0;
                pedidoHijo.Szthrp = 0;
                pedidoHijo.Szexdp = 0;
                pedidoHijo.Szktln = 0;
                pedidoHijo.Szcpnt = 0;
                pedidoHijo.Szrkit = 0;
                pedidoHijo.Szktp = 0;
                pedidoHijo.Szsoqs = 0;
                pedidoHijo.Szsobk = 0;
                pedidoHijo.Szsocn = 0;
                pedidoHijo.Szsone = 0;
                pedidoHijo.Szuopn = 0;
                pedidoHijo.Szqtyt = 0;
                pedidoHijo.Szqrlv = 0;
                pedidoHijo.Szuprc = 0;
                pedidoHijo.Szaexp = 0;
                pedidoHijo.Szaopn = 0;
                pedidoHijo.Szlprc = 0;
                pedidoHijo.Szuncs = 0;
                pedidoHijo.Szecst = 0;
                pedidoHijo.Sztcst = 0;
                pedidoHijo.Sztrdc = 0;
                pedidoHijo.Szfun2 = 0;
                pedidoHijo.Szdspr = 0;
                pedidoHijo.Szcadc = 0;
                pedidoHijo.Szdoc = 0;
                pedidoHijo.Szodoc = 0;
                pedidoHijo.Szpsn = 0;
                pedidoHijo.Szdeln = 0;
                pedidoHijo.Szvend = 0;
                pedidoHijo.Szanby = 0;
                pedidoHijo.Szcars = 0;
                pedidoHijo.Szpqor = 0;
                pedidoHijo.Szsqor = 0;
                pedidoHijo.Szitwt = 0;
                pedidoHijo.Szitvl = 0;
                pedidoHijo.Szctry = 0;
                pedidoHijo.Szfy = 0;
                pedidoHijo.Szgrwt = 0;
                pedidoHijo.Szcrr = 0;
                pedidoHijo.Szfprc = 0;
                pedidoHijo.Szfup = 0;
                pedidoHijo.Szfea = 0;
                pedidoHijo.Szfuc = 0;
                pedidoHijo.Szfec = 0;
                pedidoHijo.Szurdt = 0;
                pedidoHijo.Szurat = 0;
                pedidoHijo.Szurab = 0;
                pedidoHijo.Szsoor = 0;
                pedidoHijo.Szdeid = 0;
                pedidoHijo.Szpmdt = 0;
                pedidoHijo.Szrltm = 0;
                pedidoHijo.Szrldj = 0;
                pedidoHijo.Szdrqt = 0;
                pedidoHijo.Szadtm = 0;
                pedidoHijo.Szoptt = 0;
                pedidoHijo.Szpdtt = 0;
                pedidoHijo.Szpstm = 0;
                pedidoHijo.Szdvan = 0;
                pedidoHijo.Szshpn = 0;
                pedidoHijo.Szprjm = 0;

                //if (ingreso.compraEnDolares)
                //    pedidoHijo.Szcrcd = "USD";
                pedidoHijo.Szcrcd = ingreso.cliente.moneda;

                
                    _jdeContext.Entry(pedidoHijo).State = EntityState.Added;
                    await _jdeContext.SaveChangesAsync();
                
            }
        }

        public async Task GuardarPedidoHijoSGEnJDE(IngresoPedidoVM ingreso)
        {
            var aux = 0;
            var fechaHoy = DateTime.Now;
            foreach (var item in ingreso.articulos)
            {
                var ingresoSG = ingreso.seleccionadosSG.Where(x => x.CodArticulo == item.CodArticulo).FirstOrDefault();
                aux++;
                F47012 pedidoHijo = new F47012();

                pedidoHijo.Szedoc = double.Parse(ingreso.Doc); // en mapeo SG
                pedidoHijo.Szvr02 = ingresoSG.NroFactura; // en mapeo SG
                pedidoHijo.Szedct = "XX";
                pedidoHijo.Szekco = ingresoSG.CiaDoc; // en mapeo SG
                pedidoHijo.Szedst = "999"; // en mapeo SG
                pedidoHijo.Szedln = aux * 1000; // en mapeo SG
                pedidoHijo.Szlnid = aux * 1000;
                pedidoHijo.Szan8 = ingresoSG.CodCliente; // en mapeo SGz
                pedidoHijo.Szshan = ingresoSG.CodCliente; // en mapeo SG
                pedidoHijo.Szitm = item.CodCortoArticulo;
                pedidoHijo.Szlitm = item.CodArticulo; // en mapeo SG
                pedidoHijo.Szaitm = item.CodArticulo;
                pedidoHijo.Szuorg = item.CalcularUNTotal() * 10000;//asi estaba en portal viejo
                pedidoHijo.Szmcu = ingresoSG.Ceco.PadLeft(12, ' ');
                pedidoHijo.Szlob = ingreso.Lob;
                //pedidoHijo.Szmot = ingresoSG.CodTipoFlete.Trim(); // en mapeo SGz
                pedidoHijo.Szmot = Conversiones.ConfigurarFleteSG(ingreso.fleteEnviadoPor, ingreso.fleteAbonadoEn, ingresoSG.CodTipoFlete); // en mapeo SGz
                pedidoHijo.Szdrqj = Conversiones.Date2JulianJDE(fechaHoy);// en mapeo SG
                pedidoHijo.Sztrdj = Conversiones.Date2JulianJDE(fechaHoy);// en mapeo SG
                pedidoHijo.Szrsdj = Conversiones.Date2JulianJDE(ingreso.datosPedido.fechaDeEntrega);

                //Agregado del 04/05/2015
                //Para que no falle la custom de limite de credito y las ordenes no queden bloqueadas, 
                //se necesita escribir un blanco en el campo SZURRG (Rodrigo Martin - TGV)
                pedidoHijo.Szurrf = " ";

                pedidoHijo.Szedsq = 0;
                pedidoHijo.Szeddt = 0; // en mapeo SG
                pedidoHijo.Szeddl = 0; // en mapeo SG
                pedidoHijo.Szdoco = 0; // en mapeo SG
                pedidoHijo.Szogno = ingresoSG.NroLinea * 1000; // en mapeo SG
                pedidoHijo.Szrlln = 0;
                pedidoHijo.Szdmcs = 0;
                pedidoHijo.Szpa8 = 0;
                pedidoHijo.Szpddj = 0;
                pedidoHijo.Szopdj = 0;
                pedidoHijo.Szaddj = 0;
                pedidoHijo.Szivd = 0;
                pedidoHijo.Szcndj = 0;
                pedidoHijo.Szdgl = 0;
                //pedidoHijo.Szrsdj = 0;
                pedidoHijo.Szpefj = 0;
                pedidoHijo.Szppdj = 0;
                pedidoHijo.Szpsdj = 0;
                pedidoHijo.Szfrmp = 0;
                pedidoHijo.Szthrp = 0;
                pedidoHijo.Szexdp = 0;
                pedidoHijo.Szktln = 0;
                pedidoHijo.Szcpnt = 0;
                pedidoHijo.Szrkit = 0;
                pedidoHijo.Szktp = 0;
                pedidoHijo.Szsoqs = 0;
                pedidoHijo.Szsobk = 0;
                pedidoHijo.Szsocn = 0;
                pedidoHijo.Szsone = 0;
                pedidoHijo.Szuopn = 0;
                pedidoHijo.Szqtyt = 0;
                pedidoHijo.Szqrlv = 0;

                if (ingreso.seleccionadosSG.Count > 0)
                {
                    _logService.WriteLogCasosEspeciales("Pedido con SG seleccionados: " + string.Join(", ", ingreso.seleccionadosSG.Select(x => x.CodArticulo)));
                    _logService.WriteLogCasosEspeciales("Articulo: " + item.CodArticulo);
                }
                else
                {
                    _logService.WriteLogCasosEspeciales("Pedido sin SG seleccionados");
                }

                //var itemSeleccionado = ingreso.seleccionadosSG.Where(x => x.CodArticulo.Trim() == item.CodArticulo.Trim()).Single();
                //var itemSeleccionado = ingreso.seleccionadosSG
                //.FirstOrDefault(x =>
                //    string.Equals(
                //        (x.CodArticulo ?? "").Trim(),
                //        (item.CodArticulo ?? "").Trim(),
                //        StringComparison.OrdinalIgnoreCase));

                //pedidoHijo.Szuprc = (double)(itemSeleccionado.PrecioUnitario * 10000); // en mapeo SG
                pedidoHijo.Szuprc = (double)(ingresoSG.PrecioUnitario * 10000); // en mapeo SG
                pedidoHijo.Szaexp = 0;
                pedidoHijo.Szaopn = 0;
                pedidoHijo.Szlprc = 0;
                pedidoHijo.Szuncs = 0;
                pedidoHijo.Szecst = 0;
                pedidoHijo.Sztcst = 0;
                pedidoHijo.Sztrdc = 0;
                pedidoHijo.Szfun2 = 0;
                pedidoHijo.Szdspr = 0;
                pedidoHijo.Szcadc = 0;
                pedidoHijo.Szdoc = 0;
                pedidoHijo.Szodoc = 0;
                pedidoHijo.Szpsn = 0;
                pedidoHijo.Szdeln = 0;
                pedidoHijo.Szvend = 0;
                pedidoHijo.Szanby = 0;
                pedidoHijo.Szcars = 0;
                pedidoHijo.Szpqor = 0;
                pedidoHijo.Szsqor = 0;
                pedidoHijo.Szitwt = 0;
                pedidoHijo.Szitvl = 0;
                pedidoHijo.Szctry = 0;
                pedidoHijo.Szfy = 0;
                pedidoHijo.Szgrwt = 0;
                pedidoHijo.Szcrr = 0;
                pedidoHijo.Szfprc = 0;
                pedidoHijo.Szfup = 0;
                pedidoHijo.Szfea = 0;
                pedidoHijo.Szfuc = 0;
                pedidoHijo.Szfec = 0;
                pedidoHijo.Szurdt = 0;
                pedidoHijo.Szurat = 0;
                pedidoHijo.Szurab = 0;
                pedidoHijo.Szsoor = 0;
                pedidoHijo.Szdeid = 0;
                pedidoHijo.Szpmdt = 0;
                pedidoHijo.Szrltm = 0;
                pedidoHijo.Szrldj = 0;
                pedidoHijo.Szdrqt = 0;
                pedidoHijo.Szadtm = 0;
                pedidoHijo.Szoptt = 0;
                pedidoHijo.Szpdtt = 0;
                pedidoHijo.Szpstm = 0;
                pedidoHijo.Szdvan = 0;
                pedidoHijo.Szshpn = 0;
                pedidoHijo.Szprjm = 0;
                pedidoHijo.Szkcoo = ingresoSG.CiaDoc; // en mapeo SG
                pedidoHijo.Szokco = ingresoSG.CiaDoc; // en mapeo SG
                pedidoHijo.Szdcto = "SG"; // en mapeo SG
                pedidoHijo.Szoorn = ingresoSG.NroDoc.ToString().PadRight(8, ' '); // en mapeo SG
                pedidoHijo.Szocto = ingresoSG.TipoDoc; // en mapeo SG
                pedidoHijo.Szuom = ingresoSG.Um; // en mapeo SG
                //pedidoHijo.Szuom = ingreso.seleccionadosSG.Where(x => x.CodArticulo == item.CodArticulo).Single().Um; // en mapeo SG

                //if (ingreso.compraEnDolares)
                //    pedidoHijo.Szcrcd = "USD";
                pedidoHijo.Szcrcd = ingresoSG.Moneda; // en mapeo SG


                _jdeContext.Entry(pedidoHijo).State = EntityState.Added;
                    await _jdeContext.SaveChangesAsync();
                
            }
        }

    }
}
