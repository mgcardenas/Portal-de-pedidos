//using System;
//using System.Collections.Generic;
//using System.Data;
//using Microsoft.Data.SqlClient;
//using Microsoft.EntityFrameworkCore;
//using PortalDePedidosServidor.Models;
//using PortalDePedidosShared.FacturasVM;

//namespace PortalDePedidosServidor.ModelsDataWhereHouse;

//public partial class PortalClienteDataWherehouseContext : DbContext
//{
//    public PortalClienteDataWherehouseContext()
//    {
//    }

//    public PortalClienteDataWherehouseContext(DbContextOptions<PortalClienteDataWherehouseContext> options)
//        : base(options)
//    {
//    }
//    public DbSet<FacturasSP> Facturas { get; set; }
//    public async Task<List<FacturasSP>> GetFacturasAsync(FiltroFacturasSP filtroFacturasSP)
//    {
//        //var codClienteParam = new SqlParameter("@codCliente", filtroFacturasSP.codCliente);
//        //var fechaDesdeParam = new SqlParameter("@fechaDesde", filtroFacturasSP.fechaDesde);
//        //var fechaHastaParam = new SqlParameter("@fechaHasta", filtroFacturasSP.fechaHasta);
//        //int RC = new();
//        //return await Facturas.FromSqlRaw(
//        //    "EXEC @RC = sp_portalClientes_GetFacturasNDyNC @ClienteId, @FechaInicio, @FechaFin",
//        //    RC,codClienteParam, fechaDesdeParam, fechaHastaParam
//        //).ToListAsync();

//        var rcParam = new SqlParameter("@RC", SqlDbType.Int) { Direction = ParameterDirection.Output };
//        var codClienteParam = new SqlParameter("@codCliente", filtroFacturasSP.codCliente);
//        var fechaDesdeParam = new SqlParameter("@fechaDesde", filtroFacturasSP.fechaDesde);
//        var fechaHastaParam = new SqlParameter("@fechaHasta", filtroFacturasSP.fechaHasta);

//        await Database.ExecuteSqlRawAsync(
//            "EXEC @RC = sp_portalClientes_GetFacturasNDyNC @codCliente, @fechaDesde, @fechaHasta",
//            rcParam, codClienteParam, fechaDesdeParam, fechaHastaParam
//        );

//        var facturas = await Facturas.FromSqlRaw(
//            "EXEC sp_portalClientes_GetFacturasNDyNC @codCliente, @fechaDesde, @fechaHasta",
//            codClienteParam, fechaDesdeParam, fechaHastaParam
//        ).ToListAsync();

//        int rc = (int)rcParam.Value;

//        return facturas;
//    }
//    public virtual DbSet<Articulo> Articulos { get; set; }

//    public virtual DbSet<ArticulosAlmacene> ArticulosAlmacenes { get; set; }

//    public virtual DbSet<ArticulosConversionesCompleta> ArticulosConversionesCompletas { get; set; }

//    public virtual DbSet<Cliente> Clientes { get; set; }

//    public virtual DbSet<EncabezadoYpieHistorialDeFactura> EncabezadoYpieHistorialDeFacturas { get; set; }

//    public virtual DbSet<LibroDireccione> LibroDirecciones { get; set; }

//    public virtual DbSet<OrdenVentaEtiquetum> OrdenVentaEtiqueta { get; set; }

//    public virtual DbSet<OrdenVentum> OrdenVenta { get; set; }

//    public virtual DbSet<Udc> Udcs { get; set; }

//    public virtual DbSet<VArticulosCemento> VArticulosCementos { get; set; }

//    public virtual DbSet<VCliente> VClientes { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer();

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<FacturasSP>(entity =>
//        {
//            entity.HasNoKey();
//        });
//        modelBuilder.Entity<Articulo>(entity =>
//        {
//            entity.HasKey(e => e.CodCortoArticulo);

//            entity.Property(e => e.CodCortoArticulo).ValueGeneratedNever();
//            entity.Property(e => e.CodArticulo)
//                .HasMaxLength(25)
//                .IsUnicode(false);
//            entity.Property(e => e.CodEan)
//                .HasMaxLength(15)
//                .IsUnicode(false)
//                .HasColumnName("CodEAN");
//            entity.Property(e => e.CodFamiliaProducto)
//                .HasMaxLength(6)
//                .IsUnicode(false);
//            entity.Property(e => e.CodSubFamiliaProducto)
//                .HasMaxLength(6)
//                .IsUnicode(false);
//            entity.Property(e => e.CodTipoArticulo)
//                .HasMaxLength(5)
//                .IsUnicode(false);
//            entity.Property(e => e.CodTipoEnvase)
//                .HasMaxLength(3)
//                .IsUnicode(false);
//            entity.Property(e => e.Descripcion1)
//                .HasMaxLength(30)
//                .IsUnicode(false);
//            entity.Property(e => e.Descripcion2)
//                .HasMaxLength(30)
//                .IsUnicode(false);
//            entity.Property(e => e.GrupoArticulo)
//                .HasMaxLength(3)
//                .IsUnicode(false);
//            entity.Property(e => e.TipoStock)
//                .HasMaxLength(1)
//                .IsUnicode(false);
//            entity.Property(e => e.UmPrincipal)
//                .HasMaxLength(2)
//                .IsUnicode(false)
//                .HasColumnName("UM_Principal");
//            entity.Property(e => e.UmSecundaria)
//                .HasMaxLength(2)
//                .IsUnicode(false)
//                .HasColumnName("UM_Secundaria");
//        });

//        modelBuilder.Entity<ArticulosAlmacene>(entity =>
//        {
//            entity
//                .HasNoKey()
//                .ToTable("Articulos_Almacenes");

//            entity.Property(e => e.Almacen)
//                .HasMaxLength(25)
//                .IsUnicode(false);
//            entity.Property(e => e.CodArticulo)
//                .HasMaxLength(25)
//                .IsUnicode(false);
//            entity.Property(e => e.CodCategoria1)
//                .HasMaxLength(5)
//                .IsUnicode(false);
//            entity.Property(e => e.CodCategoria2)
//                .HasMaxLength(5)
//                .IsUnicode(false);
//            entity.Property(e => e.CodClasificacionMercancia)
//                .HasMaxLength(5)
//                .IsUnicode(false);
//        });

//        modelBuilder.Entity<ArticulosConversionesCompleta>(entity =>
//        {
//            entity
//                .HasNoKey()
//                .ToTable("Articulos_ConversionesCompletas");

//            entity.Property(e => e.Umdestino)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("UMDestino");
//            entity.Property(e => e.Umorigen)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("UMOrigen");
//        });

//        modelBuilder.Entity<Cliente>(entity =>
//        {
//            entity.HasKey(e => new { e.CodCia, e.CodCliente }).HasName("PK_Clientes_LimiteCredito");

//            entity.Property(e => e.CodCia)
//                .HasMaxLength(5)
//                .IsUnicode(false)
//                .IsFixedLength();
//            entity.Property(e => e.Cc12)
//                .HasMaxLength(4)
//                .IsUnicode(false)
//                .HasColumnName("CC_12");
//            entity.Property(e => e.CertificadoExencionImpuestos)
//                .HasMaxLength(20)
//                .IsUnicode(false);
//            entity.Property(e => e.CodAreaVenta)
//                .HasMaxLength(2)
//                .IsUnicode(false);
//            entity.Property(e => e.CodCondPago)
//                .HasMaxLength(3)
//                .IsUnicode(false);
//            entity.Property(e => e.CodCondPagoReal)
//                .HasMaxLength(4)
//                .IsUnicode(false);
//            entity.Property(e => e.CodFleteEspecial)
//                .HasMaxLength(3)
//                .IsUnicode(false);
//            entity.Property(e => e.CodProvincia)
//                .HasMaxLength(3)
//                .IsUnicode(false);
//            entity.Property(e => e.CodRubroCliente)
//                .HasMaxLength(3)
//                .IsUnicode(false);
//            entity.Property(e => e.CodTipoCliente)
//                .HasMaxLength(3)
//                .IsUnicode(false);
//            entity.Property(e => e.CodTipoDeudor)
//                .HasMaxLength(3)
//                .IsUnicode(false);
//            entity.Property(e => e.CodVendedor)
//                .HasMaxLength(3)
//                .IsUnicode(false);
//            entity.Property(e => e.Cuit)
//                .HasMaxLength(15)
//                .IsUnicode(false)
//                .HasColumnName("CUIT");
//            entity.Property(e => e.FechaCreacionRegistro)
//                .HasMaxLength(20)
//                .IsUnicode(false);
//            entity.Property(e => e.FechaInicioActividades)
//                .HasMaxLength(10)
//                .IsUnicode(false)
//                .HasDefaultValueSql("((0))");
//            entity.Property(e => e.FechaPrimeraFactura)
//                .HasMaxLength(10)
//                .IsUnicode(false);
//            entity.Property(e => e.ListaCliente)
//                .HasMaxLength(10)
//                .IsUnicode(false);
//            entity.Property(e => e.NombreFantasia)
//                .HasMaxLength(30)
//                .IsUnicode(false);
//            entity.Property(e => e.NroIibb)
//                .HasMaxLength(20)
//                .IsUnicode(false)
//                .HasColumnName("NroIIBB");
//            entity.Property(e => e.UsuarioModificacion)
//                .HasMaxLength(15)
//                .IsUnicode(false);
//        });

//        modelBuilder.Entity<EncabezadoYpieHistorialDeFactura>(entity =>
//        {
//            entity
//                .HasNoKey()
//                .ToTable("EncabezadoYPieHistorialDeFacturas");

//            entity.Property(e => e.CentroEmisor)
//                .HasMaxLength(15)
//                .IsFixedLength()
//                .HasColumnName("CENTRO_EMISOR");
//            entity.Property(e => e.CiaDoc)
//                .HasMaxLength(5)
//                .IsFixedLength()
//                .HasColumnName("CIA_DOC");
//            entity.Property(e => e.CiaOrden)
//                .HasMaxLength(5)
//                .IsFixedLength()
//                .HasColumnName("CIA_ORDEN");
//            entity.Property(e => e.CuitEmisor)
//                .HasMaxLength(20)
//                .IsFixedLength()
//                .HasColumnName("CUIT_EMISOR");
//            entity.Property(e => e.Descripcion1)
//                .HasMaxLength(30)
//                .IsFixedLength()
//                .HasColumnName("DESCRIPCION1");
//            entity.Property(e => e.NroDoc).HasColumnName("NRO_DOC");
//            entity.Property(e => e.NroFacturaLegal)
//                .HasMaxLength(8)
//                .IsFixedLength()
//                .HasColumnName("NRO_FACTURA_LEGAL");
//            entity.Property(e => e.NroOrden).HasColumnName("NRO_ORDEN");
//            entity.Property(e => e.TipoDoc)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("TIPO_DOC");
//            entity.Property(e => e.TipoOrden)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("TIPO_ORDEN");
//        });

//        modelBuilder.Entity<LibroDireccione>(entity =>
//        {
//            entity.HasKey(e => e.CodLibroDireccion);

//            entity.Property(e => e.CodLibroDireccion).ValueGeneratedNever();
//            entity.Property(e => e.Categoria1)
//                .HasMaxLength(3)
//                .IsUnicode(false);
//            entity.Property(e => e.Categoria5)
//                .HasMaxLength(3)
//                .IsUnicode(false)
//                .IsFixedLength();
//            entity.Property(e => e.Cc24)
//                .HasMaxLength(3)
//                .IsUnicode(false)
//                .HasColumnName("CC24");
//            entity.Property(e => e.Cc26)
//                .HasMaxLength(3)
//                .IsUnicode(false)
//                .HasColumnName("CC26");
//            entity.Property(e => e.Cc30)
//                .HasMaxLength(3)
//                .IsUnicode(false)
//                .HasColumnName("CC30");
//            entity.Property(e => e.CentroCosto)
//                .HasMaxLength(12)
//                .IsUnicode(false);
//            entity.Property(e => e.Clasificacion)
//                .HasMaxLength(3)
//                .IsUnicode(false);
//            entity.Property(e => e.ClasificacionIndustria)
//                .HasMaxLength(10)
//                .IsUnicode(false);
//            entity.Property(e => e.CompaniaCentroCosto)
//                .HasMaxLength(5)
//                .IsUnicode(false);
//            entity.Property(e => e.Cuit)
//                .HasMaxLength(25)
//                .IsUnicode(false)
//                .HasColumnName("CUIT");
//            entity.Property(e => e.RazonSocial)
//                .HasMaxLength(50)
//                .IsUnicode(false);
//            entity.Property(e => e.TipoSuministro)
//                .HasMaxLength(3)
//                .IsUnicode(false)
//                .IsFixedLength();
//            entity.Property(e => e.UsuarioUltimaModificacion)
//                .HasMaxLength(10)
//                .IsUnicode(false);
//        });

//        modelBuilder.Entity<OrdenVentaEtiquetum>(entity =>
//        {
//            entity
//                .HasNoKey()
//                .ToTable("OrdenVenta_Etiqueta");

//            entity.Property(e => e.CiaDoc)
//                .HasMaxLength(5)
//                .IsFixedLength()
//                .HasColumnName("CIA_DOC");
//            entity.Property(e => e.LinDoc).HasColumnName("LIN_DOC");
//            entity.Property(e => e.NroDoc).HasColumnName("NRO_DOC");
//            entity.Property(e => e.Remito)
//                .HasMaxLength(25)
//                .IsUnicode(false)
//                .HasColumnName("REMITO");
//            entity.Property(e => e.TipoDoc)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("TIPO_DOC");
//        });

//        modelBuilder.Entity<OrdenVentum>(entity =>
//        {
//            entity.HasNoKey();

//            entity.Property(e => e.Año).HasColumnName("AÑO");
//            entity.Property(e => e.CantEnviada)
//                .HasColumnType("numeric(18, 4)")
//                .HasColumnName("CANT_ENVIADA");
//            entity.Property(e => e.CantPedida)
//                .HasColumnType("numeric(18, 4)")
//                .HasColumnName("CANT_PEDIDA");
//            entity.Property(e => e.CantPendiente)
//                .HasColumnType("numeric(18, 4)")
//                .HasColumnName("CANT_PENDIENTE");
//            entity.Property(e => e.Ceco)
//                .HasMaxLength(12)
//                .IsFixedLength()
//                .HasColumnName("CECO");
//            entity.Property(e => e.CiaDoc)
//                .HasMaxLength(5)
//                .IsFixedLength()
//                .HasColumnName("CIA_DOC");
//            entity.Property(e => e.CiaDocOrig)
//                .HasMaxLength(5)
//                .IsFixedLength()
//                .HasColumnName("CIA_DOC_ORIG");
//            entity.Property(e => e.CiaOrdenRelacionada)
//                .HasMaxLength(5)
//                .IsUnicode(false);
//            entity.Property(e => e.CodArticulo)
//                .HasMaxLength(25)
//                .IsUnicode(false);
//            entity.Property(e => e.CodClaseEnvio)
//                .HasMaxLength(3)
//                .IsUnicode(false)
//                .IsFixedLength();
//            entity.Property(e => e.CodRuta)
//                .HasMaxLength(3)
//                .IsUnicode(false);
//            entity.Property(e => e.CodTipoEnvase)
//                .HasMaxLength(3)
//                .IsUnicode(false);
//            entity.Property(e => e.Desc1)
//                .HasMaxLength(30)
//                .IsFixedLength()
//                .HasColumnName("DESC1");
//            entity.Property(e => e.Desc2)
//                .HasMaxLength(30)
//                .IsFixedLength()
//                .HasColumnName("DESC2");
//            entity.Property(e => e.EstSig)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("EST_SIG");
//            entity.Property(e => e.EstUlt)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("EST_ULT");
//            entity.Property(e => e.ExtDoc)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("EXT_DOC");
//            entity.Property(e => e.FechaCancel)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("FECHA_CANCEL");
//            entity.Property(e => e.FechaEnvio)
//                .HasMaxLength(10)
//                .IsUnicode(false);
//            entity.Property(e => e.FechaFactura)
//                .HasMaxLength(10)
//                .IsUnicode(false);
//            entity.Property(e => e.FechaLm)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("FECHA_LM");
//            entity.Property(e => e.FechaOrden)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("FECHA_ORDEN");
//            entity.Property(e => e.FechaUltModif)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("FECHA_ULT_MODIF");
//            entity.Property(e => e.GrupoPrecios)
//                .HasMaxLength(8)
//                .IsUnicode(false);
//            entity.Property(e => e.Itm).HasColumnName("ITM");
//            entity.Property(e => e.LinDoc).HasColumnName("LIN_DOC");
//            entity.Property(e => e.LinDocOrig).HasColumnName("LIN_DOC_ORIG");
//            entity.Property(e => e.Litm)
//                .HasMaxLength(25)
//                .IsFixedLength()
//                .HasColumnName("LITM");
//            entity.Property(e => e.Moneda)
//                .HasMaxLength(3)
//                .IsFixedLength()
//                .HasColumnName("MONEDA");
//            entity.Property(e => e.NroDestino).HasColumnName("NRO_DESTINO");
//            entity.Property(e => e.NroDoc).HasColumnName("NRO_DOC");
//            entity.Property(e => e.NroDocOrig)
//                .HasMaxLength(8)
//                .IsFixedLength()
//                .HasColumnName("NRO_DOC_ORIG");
//            entity.Property(e => e.NroFactura)
//                .HasMaxLength(25)
//                .IsUnicode(false);
//            entity.Property(e => e.NroOrdenRelacionada)
//                .HasMaxLength(8)
//                .IsUnicode(false);
//            entity.Property(e => e.NroProveedor).HasColumnName("NRO_PROVEEDOR");
//            entity.Property(e => e.NroRemito)
//                .HasMaxLength(25)
//                .IsUnicode(false);
//            entity.Property(e => e.PatenteCamion)
//                .HasMaxLength(10)
//                .IsUnicode(false);
//            entity.Property(e => e.PatenteSemi)
//                .HasMaxLength(10)
//                .IsUnicode(false);
//            entity.Property(e => e.PesoNt).HasColumnName("PesoNT");
//            entity.Property(e => e.PrecioTotal)
//                .HasColumnType("numeric(18, 4)")
//                .HasColumnName("PRECIO_TOTAL");
//            entity.Property(e => e.PrecioTotalMe)
//                .HasColumnType("numeric(18, 4)")
//                .HasColumnName("PRECIO_TOTAL_ME");
//            entity.Property(e => e.PrecioUnitario)
//                .HasColumnType("numeric(18, 4)")
//                .HasColumnName("PRECIO_UNITARIO");
//            entity.Property(e => e.PrecioUnitarioMe)
//                .HasColumnType("numeric(18, 4)")
//                .HasColumnName("PRECIO_UNITARIO_ME");
//            entity.Property(e => e.Siglo).HasColumnName("SIGLO");
//            entity.Property(e => e.TipoCambio)
//                .HasColumnType("numeric(10, 4)")
//                .HasColumnName("TIPO_CAMBIO");
//            entity.Property(e => e.TipoDoc)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("TIPO_DOC");
//            entity.Property(e => e.TipoDocContable)
//                .HasMaxLength(2)
//                .IsUnicode(false);
//            entity.Property(e => e.TipoDocOrig)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("TIPO_DOC_ORIG");
//            entity.Property(e => e.TipoLin)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("TIPO_LIN");
//            entity.Property(e => e.TipoOrdenRelacionada)
//                .HasMaxLength(2)
//                .IsUnicode(false);
//            entity.Property(e => e.Um)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("UM");
//            entity.Property(e => e.UsuModif)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("USU_MODIF");
//            entity.Property(e => e.UsuOriginador)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("USU_ORIGINADOR");
//            entity.Property(e => e.Zona)
//                .HasMaxLength(3)
//                .IsUnicode(false);
//        });

//        modelBuilder.Entity<Udc>(entity =>
//        {
//            entity
//                .HasNoKey()
//                .ToTable("UDC");

//            entity.Property(e => e.Drdl01)
//                .HasMaxLength(30)
//                .IsFixedLength()
//                .HasColumnName("DRDL01");
//            entity.Property(e => e.Drdl02)
//                .HasMaxLength(30)
//                .IsFixedLength()
//                .HasColumnName("DRDL02");
//            entity.Property(e => e.Drhrdc)
//                .HasMaxLength(1)
//                .IsFixedLength()
//                .HasColumnName("DRHRDC");
//            entity.Property(e => e.Drky)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("DRKY");
//            entity.Property(e => e.Drrt)
//                .HasMaxLength(2)
//                .IsFixedLength()
//                .HasColumnName("DRRT");
//            entity.Property(e => e.Drsphd)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("DRSPHD");
//            entity.Property(e => e.Drsy)
//                .HasMaxLength(4)
//                .IsFixedLength()
//                .HasColumnName("DRSY");
//        });

//        modelBuilder.Entity<VArticulosCemento>(entity =>
//        {
//            entity
//                .HasNoKey()
//                .ToView("v_Articulos_Cemento");

//            entity.Property(e => e.CodArticulo)
//                .HasMaxLength(25)
//                .IsUnicode(false);
//            entity.Property(e => e.CodEan)
//                .HasMaxLength(15)
//                .IsUnicode(false)
//                .HasColumnName("CodEAN");
//            entity.Property(e => e.CodFamiliaProducto)
//                .HasMaxLength(6)
//                .IsUnicode(false);
//            entity.Property(e => e.CodSubFamiliaProducto)
//                .HasMaxLength(6)
//                .IsUnicode(false);
//            entity.Property(e => e.CodTipoArticulo)
//                .HasMaxLength(5)
//                .IsUnicode(false);
//            entity.Property(e => e.CodTipoEnvase)
//                .HasMaxLength(3)
//                .IsUnicode(false);
//            entity.Property(e => e.Descripcion1)
//                .HasMaxLength(30)
//                .IsUnicode(false);
//            entity.Property(e => e.Descripcion2)
//                .HasMaxLength(30)
//                .IsUnicode(false);
//            entity.Property(e => e.GrupoArticulo)
//                .HasMaxLength(3)
//                .IsUnicode(false);
//            entity.Property(e => e.UmPrincipal)
//                .HasMaxLength(2)
//                .IsUnicode(false)
//                .HasColumnName("UM_Principal");
//            entity.Property(e => e.UmSecundaria)
//                .HasMaxLength(2)
//                .IsUnicode(false)
//                .HasColumnName("UM_Secundaria");
//        });

//        modelBuilder.Entity<VCliente>(entity =>
//        {
//            entity
//                .HasNoKey()
//                .ToView("v_Clientes");

//            entity.Property(e => e.Cc12)
//                .HasMaxLength(4)
//                .IsUnicode(false)
//                .HasColumnName("CC_12");
//            entity.Property(e => e.CertificadoExencionImpuestos)
//                .HasMaxLength(20)
//                .IsUnicode(false);
//            entity.Property(e => e.CodAreaVenta)
//                .HasMaxLength(2)
//                .IsUnicode(false);
//            entity.Property(e => e.CodCia)
//                .HasMaxLength(5)
//                .IsUnicode(false)
//                .IsFixedLength();
//            entity.Property(e => e.CodCondPago)
//                .HasMaxLength(3)
//                .IsUnicode(false);
//            entity.Property(e => e.CodCondPagoReal)
//                .HasMaxLength(4)
//                .IsUnicode(false);
//            entity.Property(e => e.CodFleteEspecial)
//                .HasMaxLength(3)
//                .IsUnicode(false);
//            entity.Property(e => e.CodProvincia)
//                .HasMaxLength(3)
//                .IsUnicode(false);
//            entity.Property(e => e.CodRubroCliente)
//                .HasMaxLength(3)
//                .IsUnicode(false);
//            entity.Property(e => e.CodTipoCliente)
//                .HasMaxLength(3)
//                .IsUnicode(false);
//            entity.Property(e => e.CodTipoDeudor)
//                .HasMaxLength(3)
//                .IsUnicode(false);
//            entity.Property(e => e.CodVendedor)
//                .HasMaxLength(3)
//                .IsUnicode(false);
//            entity.Property(e => e.Cuit)
//                .HasMaxLength(15)
//                .IsUnicode(false)
//                .HasColumnName("CUIT");
//            entity.Property(e => e.FechaCreacionRegistro)
//                .HasMaxLength(20)
//                .IsUnicode(false);
//            entity.Property(e => e.FechaInicioActividades)
//                .HasMaxLength(10)
//                .IsUnicode(false);
//            entity.Property(e => e.FechaPrimeraFactura)
//                .HasMaxLength(10)
//                .IsUnicode(false);
//            entity.Property(e => e.ListaCliente)
//                .HasMaxLength(10)
//                .IsUnicode(false);
//            entity.Property(e => e.NombreFantasia)
//                .HasMaxLength(30)
//                .IsUnicode(false);
//            entity.Property(e => e.NroIibb)
//                .HasMaxLength(20)
//                .IsUnicode(false)
//                .HasColumnName("NroIIBB");
//            entity.Property(e => e.RubroDescripcion)
//                .HasMaxLength(30)
//                .IsFixedLength();
//            entity.Property(e => e.UsuarioModificacion)
//                .HasMaxLength(15)
//                .IsUnicode(false);
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}
