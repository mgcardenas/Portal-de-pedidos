using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PortalDePedidosServidor.ModelsDataWhereHouse;

public partial class PortalClienteDataWherehouseContext : DbContext
{
    public PortalClienteDataWherehouseContext()
    {
    }

    public PortalClienteDataWherehouseContext(DbContextOptions<PortalClienteDataWherehouseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Articulo> Articulos { get; set; }

    public virtual DbSet<ArticulosAlmacene> ArticulosAlmacenes { get; set; }

    public virtual DbSet<ArticulosConversionesCompleta> ArticulosConversionesCompletas { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<CobroCabecera> CobroCabeceras { get; set; }

    public virtual DbSet<CuentaCorrienteCliente> CuentaCorrienteClientes { get; set; }

    public virtual DbSet<EdiDetalleOrdene> EdiDetalleOrdenes { get; set; }

    public virtual DbSet<EncabezadoYpieHistorialDeFactura> EncabezadoYpieHistorialDeFacturas { get; set; }

    public virtual DbSet<LibroDireccione> LibroDirecciones { get; set; }

    public virtual DbSet<OrdenVentaEtiquetum> OrdenVentaEtiqueta { get; set; }

    public virtual DbSet<OrdenVentum> OrdenVenta { get; set; }

    public virtual DbSet<PcArticulosExclusivosPorRubro> PcArticulosExclusivosPorRubros { get; set; }

    public virtual DbSet<TblVentasShpendientesJde> TblVentasShpendientesJdes { get; set; }

    public virtual DbSet<Udc> Udcs { get; set; }

    public virtual DbSet<UdcRenombradum> UdcRenombrada { get; set; }

    public virtual DbSet<VArticulosCemento> VArticulosCementos { get; set; }

    public virtual DbSet<VCliente> VClientes { get; set; }

    public virtual DbSet<VPcConsultaFactura> VPcConsultaFacturas { get; set; }

    public virtual DbSet<VPcConsultaRecibo> VPcConsultaRecibos { get; set; }

    public virtual DbSet<VPcConsultaRemito> VPcConsultaRemitos { get; set; }

    public virtual DbSet<VPcConsultaRemitosDistinto> VPcConsultaRemitosDistintos { get; set; }

    public virtual DbSet<VPcCuentaCorrienteCliente> VPcCuentaCorrienteClientes { get; set; }

    public virtual DbSet<VPcSeguimientoPedido> VPcSeguimientoPedidos { get; set; }

    public virtual DbSet<VPcSeguimientoPedidosVentaAnticipadum> VPcSeguimientoPedidosVentaAnticipada { get; set; }

    public virtual DbSet<VwVentasShpendiente> VwVentasShpendientes { get; set; }

    public virtual DbSet<VwVentasShpendientesJde> VwVentasShpendientesJdes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Articulo>(entity =>
        {
            entity.HasKey(e => e.CodCortoArticulo);

            entity.Property(e => e.CodCortoArticulo).ValueGeneratedNever();
            entity.Property(e => e.BloqueoVenta)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CodArticulo)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.CodEan)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CodEAN");
            entity.Property(e => e.CodFamiliaProducto)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.CodSubFamiliaProducto)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.CodTipoArticulo)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.CodTipoEnvase)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion1)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion2)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.GrupoArticulo)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.TipoStock)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.UmPrincipal)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("UM_Principal");
            entity.Property(e => e.UmSecundaria)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("UM_Secundaria");
        });

        modelBuilder.Entity<ArticulosAlmacene>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Articulos_Almacenes");

            entity.Property(e => e.Almacen)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.CodArticulo)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.CodCategoria1)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.CodCategoria2)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.CodClasificacionMercancia)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ArticulosConversionesCompleta>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Articulos_ConversionesCompletas");

            entity.Property(e => e.Umdestino)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("UMDestino");
            entity.Property(e => e.Umorigen)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("UMOrigen");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => new { e.CodCia, e.CodCliente }).HasName("PK_Clientes_LimiteCredito");

            entity.Property(e => e.CodCia)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Cc12)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("CC_12");
            entity.Property(e => e.CertificadoExencionImpuestos)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CodAreaVenta)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.CodCondPago)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CodCondPagoReal)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.CodFleteEspecial)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CodProvincia)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CodRubroCliente)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CodTipoCliente)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CodTipoDeudor)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CodVendedor)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Cuit)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CUIT");
            entity.Property(e => e.FechaCreacionRegistro)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FechaInicioActividades)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("((0))");
            entity.Property(e => e.FechaPrimeraFactura)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ListaCliente)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NombreFantasia)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.NroIibb)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NroIIBB");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CobroCabecera>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CobroCabecera");

            entity.Property(e => e.CodAnulacion)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Compania)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Cuenta)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.FechaCobro)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FechaCobroDate).HasColumnName("FechaCobro_DATE");
            entity.Property(e => e.FechaLmrecibo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FechaLMRecibo");
            entity.Property(e => e.FechaLmreciboDate).HasColumnName("FechaLMRecibo_DATE");
            entity.Property(e => e.Idpago).HasColumnName("IDPago");
            entity.Property(e => e.ImporteCobroMe).HasColumnName("ImporteCobroME");
            entity.Property(e => e.Moneda)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.NumeroCobro)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Observaciones)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ReferenciaRecibo)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CuentaCorrienteCliente>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CiaDocumento).HasMaxLength(5);
            entity.Property(e => e.CiaOv)
                .HasMaxLength(5)
                .HasColumnName("CiaOV");
            entity.Property(e => e.EstadoPago).HasMaxLength(1);
            entity.Property(e => e.FechaVoid).HasColumnName("FECHA_VOID");
            entity.Property(e => e.IdCuenta)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.ImporteBrutoMe).HasColumnName("ImporteBrutoME");
            entity.Property(e => e.ImportePendienteMe).HasColumnName("ImportePendienteME");
            entity.Property(e => e.LineaOv).HasColumnName("LineaOV");
            entity.Property(e => e.Moneda).HasMaxLength(3);
            entity.Property(e => e.NroFacturaLegal).HasMaxLength(25);
            entity.Property(e => e.NroFacturaProveedor)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.NroOv).HasColumnName("NroOV");
            entity.Property(e => e.ReferenciaReservada)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.SufijoDocumento).HasMaxLength(3);
            entity.Property(e => e.SufijoOv)
                .HasMaxLength(3)
                .HasColumnName("SufijoOV");
            entity.Property(e => e.TipoDocumento).HasMaxLength(2);
            entity.Property(e => e.TipoOv)
                .HasMaxLength(2)
                .HasColumnName("TipoOV");
            entity.Property(e => e.UnidadNegocio).HasMaxLength(12);
            entity.Property(e => e.VJde)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("vJDE");
        });

        modelBuilder.Entity<EdiDetalleOrdene>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("EDI_Detalle_Ordenes");

            entity.Property(e => e.CiaDoc)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("CIA_DOC");
            entity.Property(e => e.CiaDocEdi)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("CIA_DOC_EDI");
            entity.Property(e => e.NroDoc).HasColumnName("NRO_DOC");
            entity.Property(e => e.NroDocEdi).HasColumnName("NRO_DOC_EDI");
            entity.Property(e => e.NroLinDoc).HasColumnName("NRO_LIN_DOC");
            entity.Property(e => e.NroLinDocEdi).HasColumnName("NRO_LIN_DOC_EDI");
            entity.Property(e => e.TipoDoc)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("TIPO_DOC");
            entity.Property(e => e.TipoDocEdi)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("TIPO_DOC_EDI");
        });

        modelBuilder.Entity<EncabezadoYpieHistorialDeFactura>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("EncabezadoYPieHistorialDeFacturas");

            entity.Property(e => e.CentroEmisor)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("CENTRO_EMISOR");
            entity.Property(e => e.CiaDoc)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("CIA_DOC");
            entity.Property(e => e.CiaOrden)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("CIA_ORDEN");
            entity.Property(e => e.CuitEmisor)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("CUIT_EMISOR");
            entity.Property(e => e.Descripcion1)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("DESCRIPCION1");
            entity.Property(e => e.NroDoc).HasColumnName("NRO_DOC");
            entity.Property(e => e.NroFacturaLegal)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("NRO_FACTURA_LEGAL");
            entity.Property(e => e.NroOrden).HasColumnName("NRO_ORDEN");
            entity.Property(e => e.TipoDoc)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("TIPO_DOC");
            entity.Property(e => e.TipoOrden)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("TIPO_ORDEN");
        });

        modelBuilder.Entity<LibroDireccione>(entity =>
        {
            entity.HasKey(e => e.CodLibroDireccion);

            entity.Property(e => e.CodLibroDireccion).ValueGeneratedNever();
            entity.Property(e => e.Categoria1)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Categoria5)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Cc24)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("CC24");
            entity.Property(e => e.Cc26)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("CC26");
            entity.Property(e => e.Cc30)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("CC30");
            entity.Property(e => e.CentroCosto)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Clasificacion)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.ClasificacionIndustria)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CompaniaCentroCosto)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Cuit)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("CUIT");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipoSuministro)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UsuarioUltimaModificacion)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OrdenVentaEtiquetum>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OrdenVenta_Etiqueta");

            entity.Property(e => e.CiaDoc)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("CIA_DOC");
            entity.Property(e => e.LinDoc).HasColumnName("LIN_DOC");
            entity.Property(e => e.NroDoc).HasColumnName("NRO_DOC");
            entity.Property(e => e.Remito)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("REMITO");
            entity.Property(e => e.TipoDoc)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("TIPO_DOC");
        });

        modelBuilder.Entity<OrdenVentum>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Año).HasColumnName("AÑO");
            entity.Property(e => e.CantEnviada)
                .HasColumnType("numeric(18, 4)")
                .HasColumnName("CANT_ENVIADA");
            entity.Property(e => e.CantPedida)
                .HasColumnType("numeric(18, 4)")
                .HasColumnName("CANT_PEDIDA");
            entity.Property(e => e.CantPendiente)
                .HasColumnType("numeric(18, 4)")
                .HasColumnName("CANT_PENDIENTE");
            entity.Property(e => e.Ceco)
                .HasMaxLength(12)
                .IsFixedLength()
                .HasColumnName("CECO");
            entity.Property(e => e.CiaDoc)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("CIA_DOC");
            entity.Property(e => e.CiaDocOrig)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("CIA_DOC_ORIG");
            entity.Property(e => e.CiaOrdenRelacionada)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.CodArticulo)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.CodClaseEnvio)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CodRuta)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CodTipoEnvase)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CodigoCosto)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Desc1)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("DESC1");
            entity.Property(e => e.Desc2)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("DESC2");
            entity.Property(e => e.EstSig)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("EST_SIG");
            entity.Property(e => e.EstUlt)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("EST_ULT");
            entity.Property(e => e.ExtDoc)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("EXT_DOC");
            entity.Property(e => e.FechaCancel)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("FECHA_CANCEL");
            entity.Property(e => e.FechaEnvio)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FechaFactura)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FechaLm)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("FECHA_LM");
            entity.Property(e => e.FechaOrden)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("FECHA_ORDEN");
            entity.Property(e => e.FechaUltModif)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("FECHA_ULT_MODIF");
            entity.Property(e => e.GrupoPrecios)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.Itm).HasColumnName("ITM");
            entity.Property(e => e.LinDoc).HasColumnName("LIN_DOC");
            entity.Property(e => e.LinDocOrig).HasColumnName("LIN_DOC_ORIG");
            entity.Property(e => e.Litm)
                .HasMaxLength(25)
                .IsFixedLength()
                .HasColumnName("LITM");
            entity.Property(e => e.Moneda)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("MONEDA");
            entity.Property(e => e.NroDestino).HasColumnName("NRO_DESTINO");
            entity.Property(e => e.NroDoc).HasColumnName("NRO_DOC");
            entity.Property(e => e.NroDocOrig)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("NRO_DOC_ORIG");
            entity.Property(e => e.NroFactura)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.NroOrdenRelacionada)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.NroProveedor).HasColumnName("NRO_PROVEEDOR");
            entity.Property(e => e.NroRemito)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.PatenteCamion)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PatenteSemi)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PesoNt).HasColumnName("PesoNT");
            entity.Property(e => e.PrecioTotal)
                .HasColumnType("numeric(18, 4)")
                .HasColumnName("PRECIO_TOTAL");
            entity.Property(e => e.PrecioTotalMe)
                .HasColumnType("numeric(18, 4)")
                .HasColumnName("PRECIO_TOTAL_ME");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("numeric(18, 4)")
                .HasColumnName("PRECIO_UNITARIO");
            entity.Property(e => e.PrecioUnitarioMe)
                .HasColumnType("numeric(18, 4)")
                .HasColumnName("PRECIO_UNITARIO_ME");
            entity.Property(e => e.Siglo).HasColumnName("SIGLO");
            entity.Property(e => e.TipoCambio)
                .HasColumnType("numeric(10, 4)")
                .HasColumnName("TIPO_CAMBIO");
            entity.Property(e => e.TipoDoc)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("TIPO_DOC");
            entity.Property(e => e.TipoDocContable)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.TipoDocOrig)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("TIPO_DOC_ORIG");
            entity.Property(e => e.TipoLin)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("TIPO_LIN");
            entity.Property(e => e.TipoOrdenRelacionada)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.Um)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("UM");
            entity.Property(e => e.UsuModif)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("USU_MODIF");
            entity.Property(e => e.UsuOriginador)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("USU_ORIGINADOR");
            entity.Property(e => e.Zona)
                .HasMaxLength(3)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PcArticulosExclusivosPorRubro>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PC_ArticulosExclusivosPorRubro");

            entity.Property(e => e.CodArticulo)
                .HasMaxLength(25)
                .IsFixedLength();
            entity.Property(e => e.CodRubroCliente)
                .HasMaxLength(3)
                .IsFixedLength();
        });

        modelBuilder.Entity<TblVentasShpendientesJde>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbl_Ventas_SHPendientes_JDE");

            entity.Property(e => e.CantEntregada).HasColumnName("Cant_Entregada");
            entity.Property(e => e.CantPedida).HasColumnName("CANT_PEDIDA");
            entity.Property(e => e.CantPendiente).HasColumnName("Cant_Pendiente");
            entity.Property(e => e.Ceco)
                .HasMaxLength(24)
                .IsFixedLength()
                .HasColumnName("CECO");
            entity.Property(e => e.CiaDoc)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("CIA_DOC");
            entity.Property(e => e.CodArticulo)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.CodRuta)
                .HasMaxLength(6)
                .IsFixedLength();
            entity.Property(e => e.CodTipoFlete)
                .HasMaxLength(6)
                .IsFixedLength();
            entity.Property(e => e.Desc1)
                .HasMaxLength(60)
                .IsFixedLength()
                .HasColumnName("DESC1");
            entity.Property(e => e.FechaOrden)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FECHA_ORDEN");
            entity.Property(e => e.Moneda)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasColumnName("MONEDA");
            entity.Property(e => e.NroDoc).HasColumnName("NRO_DOC");
            entity.Property(e => e.PrecioUnitario).HasColumnName("PRECIO_UNITARIO");
            entity.Property(e => e.TipoDoc)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("TIPO_DOC");
            entity.Property(e => e.Um)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("UM");
            entity.Property(e => e.Zona)
                .HasMaxLength(6)
                .IsFixedLength();
        });

        modelBuilder.Entity<Udc>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UDC");

            entity.Property(e => e.Drdl01)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("DRDL01");
            entity.Property(e => e.Drdl02)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("DRDL02");
            entity.Property(e => e.Drhrdc)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("DRHRDC");
            entity.Property(e => e.Drky)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("DRKY");
            entity.Property(e => e.Drrt)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("DRRT");
            entity.Property(e => e.Drsphd)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("DRSPHD");
            entity.Property(e => e.Drsy)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("DRSY");
        });

        modelBuilder.Entity<UdcRenombradum>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UDC_Renombrada");

            entity.Property(e => e.CodProducto)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.CodUsuario)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.CodificacionFija)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Descripcion1)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion2)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.GestionEspecial)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Valor)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VArticulosCemento>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_Articulos_Cemento");

            entity.Property(e => e.BloqueoVenta)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CodArticulo)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.CodEan)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CodEAN");
            entity.Property(e => e.CodFamiliaProducto)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.CodSubFamiliaProducto)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.CodTipoArticulo)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.CodTipoEnvase)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion1)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion2)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.GrupoArticulo)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.SubCategoriaCemento)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.UmPrincipal)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("UM_Principal");
            entity.Property(e => e.UmSecundaria)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("UM_Secundaria");
        });

        modelBuilder.Entity<VCliente>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_Clientes");

            entity.Property(e => e.Cc12)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("CC_12");
            entity.Property(e => e.CertificadoExencionImpuestos)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CodAreaVenta)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.CodCia)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CodCondPago)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CodCondPagoReal)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.CodFleteEspecial)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CodProvincia)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CodRubroCliente)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CodTipoCliente)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CodTipoDeudor)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CodVendedor)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Cuit)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CUIT");
            entity.Property(e => e.FechaCreacionRegistro)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FechaInicioActividades)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FechaPrimeraFactura)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ListaCliente)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NombreFantasia)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.NroIibb)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NroIIBB");
            entity.Property(e => e.RubroDescripcion)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VPcConsultaFactura>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_PC_ConsultaFacturas");

            entity.Property(e => e.FechaFactura).HasColumnName("FECHA_FACTURA");
            entity.Property(e => e.FechaVtoFactura).HasColumnName("FECHA_VTO_FACTURA");
            entity.Property(e => e.NombreArchivo)
                .HasMaxLength(4000)
                .HasColumnName("NOMBRE_ARCHIVO");
            entity.Property(e => e.NroDoc).HasColumnName("NRO_DOC");
            entity.Property(e => e.NroFactura)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.NroRemito)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("NRO_REMITO");
            entity.Property(e => e.PrecioTotal)
                .HasColumnType("numeric(38, 4)")
                .HasColumnName("PRECIO_TOTAL");
            entity.Property(e => e.TipoDoc)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("TIPO_DOC");
        });

        modelBuilder.Entity<VPcConsultaRecibo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_PC_ConsultaRecibos");

            entity.Property(e => e.Ccliente).HasColumnName("CCLIENTE");
            entity.Property(e => e.FechaCobro).HasColumnName("FECHA_COBRO");
            entity.Property(e => e.ImporteCobroMe).HasColumnName("ImporteCobroME");
            entity.Property(e => e.Moneda)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.NombreArchivo)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_ARCHIVO");
            entity.Property(e => e.NroRecibo)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("NRO_RECIBO");
        });

        modelBuilder.Entity<VPcConsultaRemito>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_PC_ConsultaRemitos");

            entity.Property(e => e.CantEnviada)
                .HasColumnType("numeric(18, 4)")
                .HasColumnName("CANT_ENVIADA");
            entity.Property(e => e.CodArticulo)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.FechaEnvio)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FechaOrden)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("FECHA_ORDEN");
            entity.Property(e => e.NombreArchivoRemito)
                .HasMaxLength(4000)
                .HasColumnName("NOMBRE_ARCHIVO_REMITO");
            entity.Property(e => e.NroDoc).HasColumnName("NRO_DOC");
            entity.Property(e => e.NroRemito)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.TipoDoc)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("TIPO_DOC");
            entity.Property(e => e.Transportista)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VPcConsultaRemitosDistinto>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_PC_ConsultaRemitosDistintos");

            entity.Property(e => e.NombreArchivoRemito)
                .HasMaxLength(4000)
                .HasColumnName("NOMBRE_ARCHIVO_REMITO");
            entity.Property(e => e.NroRemito)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VPcCuentaCorrienteCliente>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_PC_CuentaCorrienteCliente");

            entity.Property(e => e.DescripcionTipoDocumento)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DiasDeMora).HasColumnName("DIAS_DE_MORA");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .HasColumnName("ESTADO");
            entity.Property(e => e.EstadoPago).HasMaxLength(1);
            entity.Property(e => e.FacturaVencida)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("FACTURA_VENCIDA");
            entity.Property(e => e.ImporteBrutoMe).HasColumnName("ImporteBrutoME");
            entity.Property(e => e.ImportePendienteMe).HasColumnName("ImportePendienteME");
            entity.Property(e => e.Moneda).HasMaxLength(3);
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_CLIENTE");
            entity.Property(e => e.NroCliente).HasColumnName("NRO_CLIENTE");
            entity.Property(e => e.NroFactura)
                .HasMaxLength(25)
                .HasColumnName("NRO_FACTURA");
            entity.Property(e => e.NroRemito)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("NRO_REMITO");
            entity.Property(e => e.TipoDocumento).HasMaxLength(2);
        });

        modelBuilder.Entity<VPcSeguimientoPedido>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_PC_SeguimientoPedidos");

            entity.Property(e => e.CantEnviada)
                .HasColumnType("numeric(18, 4)")
                .HasColumnName("CANT_ENVIADA");
            entity.Property(e => e.CodArticulo)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.FechaEntrega).HasColumnName("FECHA_ENTREGA");
            entity.Property(e => e.FechaOrden)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("FECHA_ORDEN");
            entity.Property(e => e.NroDoc).HasColumnName("NRO_DOC");
            entity.Property(e => e.NroDocEdi).HasColumnName("NRO_DOC_EDI");
            entity.Property(e => e.NroRemito)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("NRO_REMITO");
            entity.Property(e => e.TipoDoc)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("TIPO_DOC");
            entity.Property(e => e.Transportista)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VPcSeguimientoPedidosVentaAnticipadum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_PC_SeguimientoPedidos_VentaAnticipada");

            entity.Property(e => e.CantEnviada)
                .HasColumnType("numeric(18, 4)")
                .HasColumnName("CANT_ENVIADA");
            entity.Property(e => e.CodArticulo)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.FechaEntrega).HasColumnName("FECHA_ENTREGA");
            entity.Property(e => e.FechaOrden)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("FECHA_ORDEN");
            entity.Property(e => e.NroDoc).HasColumnName("NRO_DOC");
            entity.Property(e => e.NroRemito)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("NRO_REMITO");
            entity.Property(e => e.TipoDoc)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("TIPO_DOC");
            entity.Property(e => e.Transportista)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwVentasShpendiente>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Ventas_SHPendientes");

            entity.Property(e => e.CantEntregada).HasColumnName("Cant_Entregada");
            entity.Property(e => e.CantPedida)
                .HasColumnType("numeric(18, 4)")
                .HasColumnName("CANT_PEDIDA");
            entity.Property(e => e.CantPendiente).HasColumnName("Cant_Pendiente");
            entity.Property(e => e.Ceco)
                .HasMaxLength(12)
                .IsFixedLength()
                .HasColumnName("CECO");
            entity.Property(e => e.CiaDoc)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("CIA_DOC");
            entity.Property(e => e.CodArticulo)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.CodRuta)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Desc1)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("DESC1");
            entity.Property(e => e.FechaOrden)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("FECHA_ORDEN");
            entity.Property(e => e.Moneda)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("MONEDA");
            entity.Property(e => e.NroDoc).HasColumnName("NRO_DOC");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("numeric(24, 4)")
                .HasColumnName("PRECIO_UNITARIO");
            entity.Property(e => e.TipoDoc)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("TIPO_DOC");
            entity.Property(e => e.Um)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("UM");
            entity.Property(e => e.Zona)
                .HasMaxLength(3)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwVentasShpendientesJde>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Ventas_SHPendientes_JDE");

            entity.Property(e => e.CantEntregada).HasColumnName("Cant_Entregada");
            entity.Property(e => e.CantPedida).HasColumnName("CANT_PEDIDA");
            entity.Property(e => e.CantPendiente).HasColumnName("Cant_Pendiente");
            entity.Property(e => e.CantSgSinProcesar).HasColumnName("CANT_SG_SIN_PROCESAR");
            entity.Property(e => e.Ceco)
                .HasMaxLength(12)
                .IsFixedLength()
                .HasColumnName("CECO");
            entity.Property(e => e.CiaDoc)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("CIA_DOC");
            entity.Property(e => e.CodArticulo)
                .HasMaxLength(25)
                .IsFixedLength();
            entity.Property(e => e.CodRuta)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.CodTipoFlete)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.Desc1)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("DESC1");
            entity.Property(e => e.FechaOrden)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FECHA_ORDEN");
            entity.Property(e => e.Moneda)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("MONEDA");
            entity.Property(e => e.NroDoc).HasColumnName("NRO_DOC");
            entity.Property(e => e.NroFacturaLegal)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("NRO_FACTURA_LEGAL");
            entity.Property(e => e.PrecioUnitario).HasColumnName("PRECIO_UNITARIO");
            entity.Property(e => e.TipoDoc)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("TIPO_DOC");
            entity.Property(e => e.Um)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("UM");
            entity.Property(e => e.Zona)
                .HasMaxLength(3)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
