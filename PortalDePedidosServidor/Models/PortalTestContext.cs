using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PortalDePedidosServidor.Models;

public partial class PortalTestContext : DbContext
{
    public PortalTestContext()
    {
    }

    public PortalTestContext(DbContextOptions<PortalTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ArticulosCemento> ArticulosCementos { get; set; }

    public virtual DbSet<ArticulosConversionesCompleta> ArticulosConversionesCompletas { get; set; }

    public virtual DbSet<ArticulosExclusivosPorRubro> ArticulosExclusivosPorRubros { get; set; }

    public virtual DbSet<ArticulosZonasConPalletRetornable> ArticulosZonasConPalletRetornables { get; set; }

    public virtual DbSet<Auditoria> Auditorias { get; set; }

    public virtual DbSet<Imagene> Imagenes { get; set; }

    public virtual DbSet<ImagenesAleatoria> ImagenesAleatorias { get; set; }

    public virtual DbSet<ImagenesCarrusel> ImagenesCarrusels { get; set; }

    public virtual DbSet<Operacione> Operaciones { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<PedidoHijo> PedidoHijos { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<RolPermiso> RolPermisos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<VwUdc> VwUdcs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArticulosCemento>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ArticulosCemento");

            entity.Property(e => e.Agrupacion1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("AGRUPACION1");
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
            entity.Property(e => e.ImagenContenido)
                .HasColumnType("text")
                .HasColumnName("imagenContenido");
            entity.Property(e => e.ImagenId).HasColumnName("imagenID");
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

        modelBuilder.Entity<ArticulosExclusivosPorRubro>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ArticulosExclusivosPorRubro");

            entity.Property(e => e.CodArticulo)
                .HasMaxLength(25)
                .IsFixedLength();
            entity.Property(e => e.CodRubroCliente)
                .HasMaxLength(3)
                .IsFixedLength();
        });

        modelBuilder.Entity<ArticulosZonasConPalletRetornable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ArticulosZonasConPalletRetornable");

            entity.Property(e => e.CodArticulo)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Zona)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Auditoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Auditori__3213E83FFF494A36");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdOperacion).HasColumnName("idOperacion");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Timestamps)
                .HasColumnType("datetime")
                .HasColumnName("timestamps");

            entity.HasOne(d => d.IdOperacionNavigation).WithMany(p => p.Auditoria)
                .HasForeignKey(d => d.IdOperacion)
                .HasConstraintName("FK__Auditoria__idOpe__49C3F6B7");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Auditoria)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Auditoria__idUsu__4AB81AF0");
        });

        modelBuilder.Entity<Imagene>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Imagenes__3213E83F95ABF216");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Codigo)
                .HasColumnType("text")
                .HasColumnName("codigo");
            entity.Property(e => e.IdArticulo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ImagenesAleatoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__imagenes__3213E83FC9975F31");

            entity.ToTable("imagenesAleatorias");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Codigo)
                .HasColumnType("text")
                .HasColumnName("codigo");
        });

        modelBuilder.Entity<ImagenesCarrusel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__imagenes__3213E83FB350B21A");

            entity.ToTable("imagenesCarrusel");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Codigo)
                .HasColumnType("text")
                .HasColumnName("codigo");
        });

        modelBuilder.Entity<Operacione>(entity =>
        {
            entity.HasKey(e => e.IdOperacion).HasName("PK__Operacio__E7EB6988429B9643");

            entity.Property(e => e.IdOperacion).HasColumnName("idOperacion");
            entity.Property(e => e.Operacion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("operacion");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido);

            entity.Property(e => e.IdPedido).ValueGeneratedNever();
            entity.Property(e => e.An8)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("AN8");
            entity.Property(e => e.Cars)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CARS");
            entity.Property(e => e.CodZona)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Dct)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DCT");
            entity.Property(e => e.Doc)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DOC");
            entity.Property(e => e.Dst)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DST");
            entity.Property(e => e.FechaEnvio).HasColumnType("datetime");
            entity.Property(e => e.FechaPedido).HasColumnType("datetime");
            entity.Property(e => e.InfoOrigen)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Kco)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("KCO");
            entity.Property(e => e.Lob)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LOB");
            entity.Property(e => e.Mcu)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("MCU");
            entity.Property(e => e.ObservacionPedido).HasColumnType("text");
            entity.Property(e => e.Orby)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ORBY");
        });

        modelBuilder.Entity<PedidoHijo>(entity =>
        {
            entity.HasKey(e => e.IdPedidoHijo);

            entity.Property(e => e.CodArticulo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.PedidoHijos)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PedidoHijos_Pedidos");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.IdPermiso);

            entity.Property(e => e.IdPermiso).HasColumnName("idPermiso");
            entity.Property(e => e.NombrePermiso)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombrePermiso");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK_Roles");

            entity.ToTable("Rol");

            entity.Property(e => e.NombreRol)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RolPermiso>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.IdPermiso).HasColumnName("idPermiso");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.IdRolPermisos)
                .ValueGeneratedOnAdd()
                .HasColumnName("idRolPermisos");

            entity.HasOne(d => d.IdPermisoNavigation).WithMany()
                .HasForeignKey(d => d.IdPermiso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolPermisos_Permisos");

            entity.HasOne(d => d.IdRolNavigation).WithMany()
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolPermisos_Rol");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.Property(e => e.CodZona)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.FechaUltimaContrasena).HasColumnType("datetime");
            entity.Property(e => e.FechaUltimaVisita).HasColumnType("datetime");
            entity.Property(e => e.MailUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Moneda)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PasswordUsuario)
                .HasMaxLength(42)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioOracle)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK_Usuarios_Rol");
        });

        modelBuilder.Entity<VwUdc>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_UDC");

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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
