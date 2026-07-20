using Dapper;
using System.Globalization;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PortalDePedidosServidor.Models;
using PortalDePedidosServidor.ModelsDataWhereHouse;
using PortalDePedidosShared.ArticulosVM;
using PortalDePedidosShared.AuditoriasVM;
using PortalDePedidosShared.ComprasAnticipadasPendientesVM;
using PortalDePedidosShared.CuentasCorrientesVM;
using PortalDePedidosShared.CuentasCorrientesVM;
using PortalDePedidosShared.DataWhereHouse;
using PortalDePedidosShared.EstadisticasVM;
using PortalDePedidosShared.FacturasVM;
using PortalDePedidosShared.IngresoPedidosVM;
using PortalDePedidosShared.RecibosVM;
using PortalDePedidosShared.RemitosVM;
using PortalDePedidosShared.RemitosVM;
using PortalDePedidosShared.SeguimientoPedidosVM;
using PortalDePedidosShared.UsuariosVM;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using static Google.Cloud.RecaptchaEnterprise.V1.TransactionData.Types;
using Microsoft.Extensions.Caching.Memory; // añadido
using System;

namespace PortalDePedidosServidor.Servicios
{
    public class DataWareHouseService
    {
        private PortalClienteDataWherehouseContext _context;
        private PortalTestContext _localContext;
        private readonly IMemoryCache _cache; // añadido

        public DataWareHouseService(PortalClienteDataWherehouseContext context, PortalTestContext localContext, IMemoryCache cache)
        {
            _context = context;
            _localContext = localContext;
            _cache = cache;
        }

        private DateTime devolverDateTime(string x)
        {
            var fecha = x.Split('/');
            var fechaValida = fecha[2] + "-" + fecha[1] + "-" + fecha[0];
            return DateTime.Parse(fechaValida);
        }

        public async Task<List<string>> GetEstadosPedido()
        {
            return _context.VPcSeguimientoPedidos.Select(x => x.Estado).Distinct().ToList();
        }
        public async Task<List<string>> GetEstadosPedidoVentaAnticipada()
        {
            return _context.VPcSeguimientoPedidosVentaAnticipada.Select(x=>x.Estado).Distinct().ToList();
        }

        public async Task<List<SeguimientoPedidoVM>> GetSeguimientoPedido(FiltroSeguimientoPedidos filtro)
        {
            var query = await _context.VPcSeguimientoPedidos.Where(x => x.CodCliente == filtro.CodCliente).OrderByDescending(x => x.FechaOrden).ToListAsync();

            query = query.Where(x => devolverDateTime(x.FechaOrden) >= filtro.FechaDesde
                           && devolverDateTime(x.FechaOrden) <= filtro.FechaHasta).ToList();

            if (filtro.Estado != "0")
            {
                query = query.Where(x => x.Estado == filtro.Estado).OrderByDescending(x => x.FechaOrden).ToList();
            }
            var seguimientoDB = query;
            var seguimientos = seguimientoDB.Select(x => new SeguimientoPedidoVM()
            {
                CodCliente = x.CodCliente,
                Tipo_doc = x.TipoDoc,
                Nro_doc = x.NroDoc,
                Fecha_orden = devolverDateTime(x.FechaOrden),
                CodArticulo = x.CodArticulo,
                Cant_enviada = x.CantEnviada,
                CodTransportista = x.CodTransportista,
                Transportista = x.Transportista,
                Estado = x.Estado,
                Nro_doc_edi = x.NroDocEdi,
                Nro_remito = x.NroRemito,
                Fecha_entrega = x.FechaEntrega
            }).ToList();

            return seguimientos.OrderByDescending(x => x.Fecha_orden).ToList();
        }

        public async Task<List<SeguimientoPedidoVM>> GetSeguimientoPedidoVentaAnticipada(FiltroSeguimientoPedidos filtro)
        {
            var query = await _context.VPcSeguimientoPedidosVentaAnticipada.Where(x => x.CodCliente == filtro.CodCliente).OrderByDescending(x => x.FechaOrden).ToListAsync();

            query = query.Where(x => devolverDateTime(x.FechaOrden) >= filtro.FechaDesde
                           && devolverDateTime(x.FechaOrden) <= filtro.FechaHasta).ToList();

            if (filtro.Estado != "0")
            {
                query = query.Where(x => x.Estado == filtro.Estado).OrderByDescending(x => x.FechaOrden).ToList();
            }
            var seguimientoDB = query;
            var seguimientos = seguimientoDB.Select(x => new SeguimientoPedidoVM()
            {
                CodCliente = x.CodCliente,
                Tipo_doc = x.TipoDoc,
                Nro_doc = x.NroDoc,
                Fecha_orden = devolverDateTime(x.FechaOrden),
                CodArticulo = x.CodArticulo,
                Cant_enviada = x.CantEnviada,
                CodTransportista = x.CodTransportista,
                Transportista = x.Transportista,
                Estado = x.Estado,
                //Nro_doc_edi = x.NroDocEdi,
                Nro_remito = x.NroRemito,
                Fecha_entrega = x.FechaEntrega
            }).ToList();

            return seguimientos.OrderByDescending(x => x.Fecha_orden).ToList();
        }

        public async Task<List<ComprasAnticipadasVM>> GetComprasAnticipadasPendientes(FiltroComprasAnticipadasPendientes filtro)
        {
            var articulosZonaConPalletRetornable = _localContext.ArticulosZonasConPalletRetornables.ToList();
            var query = await _context.VwVentasShpendientesJdes.Where(x => x.CodCliente == filtro.CodCliente).ToListAsync();
            //var query = await _context.VentasShpendientesLocals.Where(x => x.CodCliente == filtro.CodCliente).ToListAsync();
            query = query.Where(x => DateTime.Parse(x.FechaOrden.Trim()) >= filtro.FechaDesde
                           && DateTime.Parse(x.FechaOrden.Trim()) <= filtro.FechaHasta).ToList();

            if(filtro.Articulo != null && filtro.Articulo != "")
            {
                query = query.Where(x=> x.CodArticulo.Contains(filtro.Articulo.ToUpper()) || x.Desc1.Contains(filtro.Articulo.ToUpper())).ToList();
            }

            return query.Select(x => new ComprasAnticipadasVM()
            {
                CodCliente = (int) x.CodCliente,
                NroDoc =(int) x.NroDoc,
                NroFactura = x.NroFacturaLegal?.Trim(),
                NroLinea = (int?) x.NroLinea,
                FechaOrden = x.FechaOrden?.Trim(),
                CodArticulo = x.CodArticulo?.Trim(),
                Desc1 = x.Desc1?.Trim(),
                CantPedida = ((decimal)x.CantPedida).ToString("N0"),
                CantPedidaNum = x.CantPedida,
                CantEntregada = ((decimal)x.CantEntregada).ToString("N0"),
                CantEntregadaNum = x.CantEntregada,
                CantPendiente = ((double)x.CantPendiente).ToString("N0"),
                CantPendienteNum = x.CantPendiente,
                Ceco = x.Ceco?.Trim(),
                CodRuta = x.CodRuta?.Trim(),
                Zona = x.Zona?.Trim(),
                CodTipoFlete = x.CodTipoFlete?.Trim(),
                CiaDoc = x.CiaDoc.ToString(),
                TipoDoc = x.TipoDoc,
                Um = x.Um,
                PrecioUnitario = (decimal?)x.PrecioUnitario,
                Moneda = x.Moneda,
                CantSgSinProcesar = ((double?)x.CantSgSinProcesar)?.ToString("N0"),
                CantSgSinProcesarNum = (double?)x.CantSgSinProcesar,
                LlevaPalletRetornable = articulosZonaConPalletRetornable.Any(a => a.CodArticulo.Trim() == x.CodArticulo.Trim() )

            }).OrderBy(x => x.NroDoc).ThenBy(x=> x.NroLinea).ToList();
        }

        public async Task<List<CuentaCorrienteVM>> GetCuentasCorrientes(FiltroCuentasCorrientesVM filtroCuentasCorrientesVM)
        {
            var cuentasCorrientesDb = await _context.VPcCuentaCorrienteClientes.Where(x => x.NroCliente == filtroCuentasCorrientesVM.NroCliente).ToListAsync();
            //cuentasCorrientesDb = cuentasCorrientesDb.Where(x => x.FechaFactura >= filtroCuentasCorrientesVM.FechaDesde && x.FechaFactura <= filtroCuentasCorrientesVM.FechaHasta).ToList();
            cuentasCorrientesDb = cuentasCorrientesDb.ToList();

            return cuentasCorrientesDb.Select(x => new CuentaCorrienteVM()
            {
                tipoDocumento = x.TipoDocumento,
                nro_Factura = x.NroFactura,
                nro_remito = x.NroRemito,
                fechaFactura = DateTime.Parse(x.FechaFactura.ToString()),
                importeBruto = x.ImporteBruto,
                importePendiente = x.ImportePendiente,
                fechaVencimiento = DateTime.Parse(x.FechaVencimiento.ToString()),
                dias_de_mora = x.DiasDeMora,
                DescripcionTipoDocumento = x.DescripcionTipoDocumento
            }).OrderBy(x => x.tipoDocumento).ThenBy(x=> x.fechaFactura).ToList();
        }

        public async Task<bool> ClienteTieneDeuda(int nroCliente)
        {
            var deudas = await _context.VPcCuentaCorrienteClientes.Where(x => x.NroCliente == nroCliente && x.FacturaVencida == "S").ToListAsync();
            return deudas.Count > 0;
        }

        public async Task<List<RemitoVM>> GetRemitos(FiltroRemitosVM filtroRemitosVM)
        {
            var remitosDB = await _context.VPcConsultaRemitosDistintos.Where(x => x.CodCliente == filtroRemitosVM.CodCliente).ToListAsync();
            var queryRemitosDB = remitosDB.Where(x => x.FechaEnvio >= DateOnly.Parse(filtroRemitosVM.FechaDesde.ToString()) && x.FechaEnvio <= DateOnly.Parse(filtroRemitosVM.FechaHasta.ToString())).AsQueryable();

            if (!filtroRemitosVM.NroRemito.IsNullOrEmpty())
            {
                queryRemitosDB = queryRemitosDB.Where(x => x.NroRemito == filtroRemitosVM.NroRemito).AsQueryable();
            }

            remitosDB = queryRemitosDB.ToList();

            return remitosDB.Select(x => new RemitoVM()
            {
                CodCliente = (int)x.CodCliente,
                NroRemito = x.NroRemito,
                FechaEnvio = DateTime.Parse(x.FechaEnvio.ToString()),
                NombreArchivo = (!x.NombreArchivoRemito.IsNullOrEmpty()) ? x.NombreArchivoRemito : ""

            }).OrderByDescending(x => x.FechaEnvio).ToList();
        }
        public async Task<List<FacturasSP>> GetFacturas(FiltroFacturasSP filtroFacturasSP)
        {
            var facturasDB = await _context.VPcConsultaFacturas.Where(x => x.CodCliente == filtroFacturasSP.CodCliente).ToListAsync();
            facturasDB = facturasDB.Where(x => x.FechaFactura >= DateOnly.Parse(filtroFacturasSP.FechaDesde.ToString()) && x.FechaFactura <= DateOnly.Parse(filtroFacturasSP.FechaHasta.ToString())).ToList();

            return facturasDB.Select(x => new FacturasSP()
            {
                CodCliente = x.CodCliente,
                Tipo_doc = x.TipoDoc,
                Nro_doc = x.NroDoc,
                Fecha_factura = x.FechaFactura,
                Fecha_vto_factura = x.FechaVtoFactura,
                Expr1 = x.Expr1,
                //CodArticulo = x.CodArticulo,
                //CantEnviada = x.CantEnviada,
                NroFactura = x.NroFactura,
                Nombre_archivo = (!x.NombreArchivo.IsNullOrEmpty()) ? x.NombreArchivo : "",
                Precio_total = x.PrecioTotal != null ? (decimal)x.PrecioTotal : 0,
                Nro_remito = x.NroRemito
            }).OrderByDescending(x => x.Fecha_factura).ToList();
        }

        public async Task<List<ReciboVM>> GetRecibos(FiltroRecibos filtro)
        {
            var recibosDB = await _context.VPcConsultaRecibos.Where(x => x.Ccliente == filtro.CodCliente).ToListAsync();
            var queryRecibosDB = recibosDB.Where(x => DateTime.Parse(x.FechaCobro.ToString()) >= filtro.FechaDesde
                                            && DateTime.Parse(x.FechaCobro.ToString()) <= filtro.FechaHasta).AsQueryable();
            if (!filtro.NroRecibo.IsNullOrEmpty())
            {
                queryRecibosDB = queryRecibosDB.Where(x => x.NroRecibo == filtro.NroRecibo).AsQueryable();
            }

            recibosDB = queryRecibosDB.ToList();

            return recibosDB.Select(x => new ReciboVM()
            {
                NroRecibo = x.NroRecibo,
                FechaCobro = DateTime.Parse(x.FechaCobro.ToString()),
                CodCliente = x.Ccliente,
                Moneda = x.Moneda,
                ImporteCobro = x.ImporteCobro,
                ImporteCobroMe = x.ImporteCobroMe,
                NombreArchivo = (!x.NombreArchivo.IsNullOrEmpty()) ? x.NombreArchivo : "",
            }).OrderByDescending(x => x.NroRecibo).ToList();
        }

        public async Task<List<Zona>> GetZonas()
        {
            var list = new List<Zona>();


            var query = $"select * from UDC where DRRT ='ZN' and DRSY='40' order by 1";
            var zonasDWH = 
                await _localContext.VwUdcs.Where(x => x.CodUsuario == "ZN" && x.CodProducto == "40").OrderBy(x => 1).ToListAsync();
                //await _context.Udcs.Where(x => x.Drrt == "ZN" && x.Drsy == "40").OrderBy(x => 1).ToListAsync();

            list = zonasDWH.Select(x => new Zona()
            {
                CodigoZona = x.Valor.Trim(),
                Descripcion = x.Descripcion1.Trim()
            }).ToList();

            return list.OrderBy(x => x.Descripcion).ToList();
        }

        // --- Mejora en GetArticulos(): evitar N+1 y usar AsNoTracking + cache ---
        public async Task<List<ArticuloVM>> GetArticulos()
        {
            return await _cache.GetOrCreateAsync("Articulos_All", async entry =>
            {
                // TTL cache razonable; ajustar según frecuencia de cambios
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);

                var articulosDWH = await _context.VArticulosCementos.AsNoTracking().ToListAsync();
                var codigos = articulosDWH.Select(a => a.CodArticulo).Where(c=> !string.IsNullOrEmpty(c)).Distinct().ToList();

                // Traer imágenes en un solo query para evitar N+1
                var imagenes = await _localContext.Imagenes
                    .AsNoTracking()
                    .Where(i => codigos.Contains(i.IdArticulo))
                    .ToListAsync();

                var imagenDict = imagenes
                    .GroupBy(i => i.IdArticulo)
                    .ToDictionary(g => g.Key, g => g.First().Codigo);

                var articulosVM = articulosDWH.Select(item => {
                    var artVM = new ArticuloVM();
                    artVM.CodArticulo = item.CodArticulo;
                    artVM.Descripcion = item.Descripcion1;
                    artVM.Categoria = ObtenerCategoria(item.GrupoArticulo);
                    if (item.SubCategoriaCemento != null)
                        artVM.SubCategoria = item.SubCategoriaCemento;
                    if (imagenDict.TryGetValue(item.CodArticulo, out var img))
                        artVM.Imagen = img;
                    return artVM;
                }).OrderBy(x => x.Categoria).ToList();

                return articulosVM;
            });
        }

        // --- Reusar la versión optimizada y cachearla ---
        public async Task<List<ArticuloIngresoPedidoVM>> GetArticulosIngreso()
        {
            // Si la versión optimizada ya es la recomendada, la invocamos y cacheamos.
            return await _cache.GetOrCreateAsync("ArticulosIngreso_All", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
                var articulos = await GetArticulosIngresoOptimizado();
                // Aseguramos ordenamiento consistente
                return articulos.OrderBy(x => x.CodArticulo).ToList();
            });
        }

        public async Task<List<ArticuloIngresoPedidoVM>> GetArticulosIngresoOptimizado()
        {
            // (Se mantiene la implementación optimizada ya existente — no se cambia la lógica)
            // 1. Traigo todos los artículos
            var articulosDWH = await _localContext.ArticulosCementos.ToListAsync();
            var articulosGeneranPalletRetornable = await _localContext.ArticulosZonasConPalletRetornables.Where(x=> x.Zona == "CAM").ToListAsync();

            var codigosArticulos = articulosDWH.Select(a => a.CodArticulo).ToList();
            var codigosCortos = articulosDWH.Select(a => a.CodCortoArticulo).ToList();

            // 3. Traigo todas las conversiones de unidades de una sola vez
            var conversiones = await _localContext.ArticulosConversionesCompletas
                .Where(x => codigosCortos.Contains((int)x.CodArticuloCorto))
                .Select(x => new
                {
                    x.CodArticuloCorto,
                    Unidad = new UnidadMedidaVM
                    {
                        FactorConversion = x.FactorConversion,
                        Umdestino = x.Umdestino,
                        Umorigen = x.Umorigen
                    }
                })
                .ToListAsync();

            var unidadesPorArticulo = conversiones
                .GroupBy(c => c.CodArticuloCorto)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(x => x.Unidad).ToList()
                );

            // 4. Traigo todos los rubros exclusivos de una sola vez
            var rubros = await _context.PcArticulosExclusivosPorRubros
                .Where(x => codigosArticulos.Contains(x.CodArticulo))
                .Select(x => new RubrosExclusivosVM
                {
                    CodArticulo = x.CodArticulo.Trim(),
                    CodRubroCliente = x.CodRubroCliente.Trim()
                })
                .ToListAsync();

            var rubrosPorArticulo = rubros
                .GroupBy(r => r.CodArticulo)
                .ToDictionary(
                    g => g.Key,
                    g => g.ToList()
                );

            // 5. Armo los ViewModels en memoria
            var articulosVM = articulosDWH.Select(item =>
            {
                var artVM = new ArticuloIngresoPedidoVM
                {
                    CodArticulo = item.CodArticulo,
                    CodCortoArticulo = item.CodCortoArticulo,
                    CodTipoArticulo = item.CodTipoArticulo,
                    CodTipoEnvase = item.CodTipoEnvase,
                    Descripcion = item.Descripcion1,
                    UnidadDeMedida = GetUnidadPrincipal(item),
                    Categoria = ObtenerCategoria(item.GrupoArticulo),
                    SubCategoria = item.SubCategoriaCemento ?? "",
                    CodPlanta = item.CodPlanta,
                    unidades = unidadesPorArticulo.TryGetValue(item.CodCortoArticulo, out var unidades)
                                ? unidades
                                : new List<UnidadMedidaVM>(),
                    VisibleSoloComercial = item.BloqueoVenta == "NV",
                    Imagen = item.ImagenContenido,
                    esVigueta = item.GrupoArticulo == "VIG",
                    esArticuloUnico = item.UmPrincipal == "TN" && item.UmSecundaria == "TN",
                    RubrosExclusivos = rubrosPorArticulo.TryGetValue(item.CodArticulo, out var rubrosEx)
                                        ? rubrosEx
                                        : new List<RubrosExclusivosVM>(),
                };

                return artVM;
            })
            .ToList();

            return articulosVM;
        }

        public List<RubrosExclusivosVM> GetRubrosExclusivos(string codArticulo)
        {
            return _context.PcArticulosExclusivosPorRubros.Where(x => x.CodArticulo == codArticulo).Select(x => new RubrosExclusivosVM()
            {
                CodArticulo = x.CodArticulo.Trim(),
                CodRubroCliente = x.CodRubroCliente.Trim(),
            }).ToList();
        }

        public ArticuloIngresoPedidoVM? GetArticuloIngreso(string codArticulo)
        {
            var articuloDWH = _localContext.ArticulosCementos.Where(x => x.CodArticulo == codArticulo).FirstOrDefault();

            if (articuloDWH != null)
            {

                var item = new ArticuloIngresoPedidoVM()
                {
                    CodArticulo = articuloDWH.CodArticulo,
                    CodCortoArticulo = articuloDWH.CodCortoArticulo,
                    CodTipoEnvase = articuloDWH.CodTipoEnvase,
                    CodTipoArticulo = articuloDWH.CodTipoArticulo,
                    Descripcion = articuloDWH.Descripcion1,
                    UnidadDeMedida = GetUnidadPrincipal(articuloDWH),
                    Categoria = ObtenerCategoria(articuloDWH.GrupoArticulo),
                    SubCategoria = "",
                    CodPlanta = articuloDWH.CodPlanta,
                };

                if (articuloDWH.SubCategoriaCemento != null)
                    item.SubCategoria = articuloDWH.SubCategoriaCemento;


                return item;
            }
            return null;
        }

        public async Task<List<SeguimientoEstadisticaVM>> GetSeguimientoEstadistica(FiltroSeguimientoPedidos filtro)
        {
            var query = await _context.VPcSeguimientoPedidos.Where(x => x.CodCliente == filtro.CodCliente).ToListAsync();

            query = query.Where(x => devolverDateTime(x.FechaOrden) >= filtro.FechaDesde
                           && devolverDateTime(x.FechaOrden) <= filtro.FechaHasta).ToList();

            if (filtro.Estado != "0")
            {
                query = query.Where(x => x.Estado == filtro.Estado).OrderByDescending(x => x.FechaOrden).ToList();
            }
            var seguimientoDB = query;
            var seguimientos = seguimientoDB.Select(x => new SeguimientoEstadisticaVM()
            {
                CodCliente = x.CodCliente,
                NroDoc = x.NroDoc,
                Anio = devolverDateTime(x.FechaOrden).Year,
                Mes = devolverDateTime(x.FechaOrden).Month,
                Articulo = GetArticuloIngreso(x.CodArticulo),
                CantEnviada = x.CantEnviada,
            }).ToList();

            return seguimientos;
        }

        public async Task<List<RemitoEstadisticaVM>> GetRemitosEstadistica(FiltroRemitoEstadistica filtro)
        {
            var remitosDB = await _context.VPcConsultaRemitos.Where(x => x.CodCliente == filtro.CodCliente).ToListAsync();
            remitosDB = remitosDB.Where(x => DateTime.Parse(x.FechaOrden) >= filtro.FechaDesde &&
                                            DateTime.Parse(x.FechaOrden) <= filtro.FechaHasta).ToList();

            var remitosEstadistica = remitosDB.Select(x => new RemitoEstadisticaVM()
            {
                CodCliente = x.CodCliente,
                TipoDoc = x.TipoDoc,
                NroDoc = x.NroDoc,
                FechaOrden = DateTime.Parse(x.FechaOrden),
                FechaEnvio = x.FechaEnvio.IsNullOrEmpty() ? null : DateTime.Parse(x.FechaEnvio),
                Articulo = GetArticuloIngreso(x.CodArticulo),
                CantEnviada = x.CantEnviada,
                CodTransportista = x.CodTransportista,
                Transportista = x.Transportista,
                NroRemito = x.NroRemito,
            }).ToList();

            return remitosEstadistica;
        }

        private string GetUnidadPrincipal(ArticulosCemento item)
        {
            if (item.UmPrincipal == "TN" && item.UmSecundaria == "BS")
                return "Bolson";

            if (item.GrupoArticulo == "VIG")
                return "Paquete";

            if (item.UmPrincipal == "UN" || item.UmPrincipal == "BL")
                return "Pallet";

            return "TN";
        }

        public async Task<ArticuloIngresoPedidoVM?> GetPalletRetornable()
        {
            ArticuloIngresoPedidoVM palletRetornable = new();

            //var palletDB = await _context.VArticulosCementos.Where(x=> x.CodArticulo == "905").FirstOrDefaultAsync();
            //if (palletDB != null)
            //{
            //}
            palletRetornable.CodArticulo = "905";
            palletRetornable.CodCortoArticulo = 40220;
            palletRetornable.Descripcion = "Pallet Retornable";
            palletRetornable.CodTipoArticulo = "";
            palletRetornable.UnidadDeMedida = "UN";
            palletRetornable.Categoria = "";
            palletRetornable.SubCategoria = "";
            palletRetornable.CodPlanta = 0;
            palletRetornable.unidades = new();
            ////ver si es necesario
            //itemPallet.ITM = pObjItemPallet.ITM
            //    itemPallet.AITM = pObjItemPallet.AITM
            //    itemPallet.LITM = pObjItemPallet.LITM


            return palletRetornable;
        }

        public async Task<List<UnidadMedidaVM>> GetUnidadesYConversiones(int codCortoArticulo)
        {

            return await _context.ArticulosConversionesCompletas.Where(x => x.CodArticuloCorto == codCortoArticulo).Select(x => new UnidadMedidaVM()
            {
                FactorConversion = x.FactorConversion,
                Umdestino = x.Umdestino,
                Umorigen = x.Umorigen,
            }).ToListAsync();

        }

        public async Task<ArticuloEditarVM?> GetArticuloEditar(string codigo)
        {

            var articuloDB = await _context.VArticulosCementos.Where(x => x.CodArticulo == codigo).FirstOrDefaultAsync();
            ArticuloEditarVM articuloVM = new();
            articuloVM.ArticuloEnBaseDeDatos = false;
            if (articuloDB != null)
            {
                articuloVM.CodCortoArticulo = articuloDB.CodCortoArticulo != 0 ? articuloDB.CodCortoArticulo : 0;
                articuloVM.CodItem = !string.IsNullOrEmpty(articuloDB.CodArticulo) ? articuloDB.CodArticulo : "Sin datos";
                articuloVM.NombreItem = !string.IsNullOrEmpty(articuloDB.Descripcion1) ? articuloDB.Descripcion1 : "Sin datos";
                articuloVM.Descripcion2 = !string.IsNullOrEmpty(articuloDB.Descripcion2) ? articuloDB.Descripcion2 : "Sin datos";
                articuloVM.GrupoArticulo = !string.IsNullOrEmpty(ObtenerCategoria(articuloDB.GrupoArticulo)) ? ObtenerCategoria(articuloDB.GrupoArticulo) : "Sin datos";
                articuloVM.UM_Principal = !string.IsNullOrEmpty(articuloDB.UmPrincipal) ? articuloDB.UmPrincipal : "Sin datos";
                articuloVM.CodEAN = !string.IsNullOrEmpty(articuloDB.CodEan) ? articuloDB.CodEan : "Sin datos";
                articuloVM.CodPlanta = !string.IsNullOrEmpty(ObtenerPlanta(articuloDB.CodPlanta)) ? ObtenerPlanta(articuloDB.CodPlanta) : "Sin datos";

            }
            return articuloVM;

        }

        public async Task<List<RazonSocialVM>> GetAllRazonSocial()
        {

            var libro = await _context.LibroDirecciones.OrderBy(x => x.RazonSocial).ToListAsync();
            return libro.Select(x => new RazonSocialVM()
            {
                CodLibroDireccion = x.CodLibroDireccion,
                RazonSocial = x.RazonSocial,
                Cuit = x.Cuit,
            }).ToList();

        }

        public async Task<LibroDireccione?> GetUsuarioJDE(string nroJDE)
        {
            var usr = await _context.LibroDirecciones.Where(x => x.CodLibroDireccion.ToString() == nroJDE).SingleOrDefaultAsync();
            return usr;

        }

        public List<LibroDireccione?> GetUsuariosJDE()
        {
            return _context.LibroDirecciones.ToList();
        }

        public async Task<InfoClienteVM> GetInfoCliente(string nroJDE)
        {
            var infoVM = new InfoClienteVM();


            var infoDB = await _context.VClientes.Where(x => x.CodCliente == int.Parse(nroJDE)).FirstOrDefaultAsync();
            if (infoDB != null)
            {
                infoVM.nroJDE = (int)infoDB.CodCliente;
                infoVM.nombre = "";
                infoVM.cuit = infoDB.Cuit;
                infoVM.representante = "";
                infoVM.areaVenta = infoDB.CodAreaVenta;
            }


            return infoVM;
        }

        public string? ObtenerCategoria(string grupoArticulo)
        {
            switch (grupoArticulo)
            {
                case "CEM":
                    return "CEMENTOS";
                    break;

                case "MOR":
                    return "ADHESIVOS";
                    break;

                case "PRE":
                    return "MAMPUESTOS";
                    break;

                case "VIG":
                    return "VIGUETAS";
                    break;

                default:
                    return null;
                    break;
            }
        }
        public string? ObtenerPlanta(int? codPlanta)
        {
            switch (codPlanta)
            {
                case 1:
                    return "Comodoro Rivadavia";
                    break;

                case 2:
                    return "Pico Truncado";
                    break;

                case 3:
                    return "Comodoro Rivadavia y Pico Truncado";
                    break;

                default:
                    return "";
                    break;
            }
        }

        public async Task<bool> NroJDENoExiste(int nroJDE)
        {
            var userDB = await _context.LibroDirecciones.Where(x => x.CodLibroDireccion == nroJDE).FirstOrDefaultAsync();

            return userDB == null;
        }

        public async Task<Cliente?> GetCliente(int nroJDE)
        {
            return await _context.Clientes.Where(x => x.CodCliente == nroJDE).FirstOrDefaultAsync();
        }
    }
}
