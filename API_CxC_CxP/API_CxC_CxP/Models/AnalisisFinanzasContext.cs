using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API_CxC_CxP.Models;

public partial class AnalisisFinanzasContext : DbContext
{
    public AnalisisFinanzasContext()
    {
    }

    public AnalisisFinanzasContext(DbContextOptions<AnalisisFinanzasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoriaLibretum> CategoriaLibreta { get; set; }

    public virtual DbSet<DetalleDocumento> DetalleDocumentos { get; set; }

    public virtual DbSet<Documento> Documentos { get; set; }

    public virtual DbSet<LibretaDireccione> LibretaDirecciones { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<TerminosCredito> TerminosCreditos { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    public virtual DbSet<TipoLibretum> TipoLibreta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer("Server=MHAYDE\\SQLEXPRESS; Database=AnalisisFinanzas;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoriaLibretum>(entity =>
        {
            entity.HasKey(e => e.CodigoCategoria);

            entity.ToTable("Categoria_Libreta");

            entity.Property(e => e.CodigoCategoria).HasColumnName("codigoCategoria");
            entity.Property(e => e.DescripcionCategoria)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcionCategoria");
        });

        modelBuilder.Entity<DetalleDocumento>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Detalle_Documento");

            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CodigoProducto).HasColumnName("codigoProducto");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numeroDocumento");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("precioUnitario");

            entity.HasOne(d => d.CodigoProductoNavigation).WithMany()
                .HasForeignKey(d => d.CodigoProducto)
                .HasConstraintName("FK_Detalle_Documento_Productos");

            entity.HasOne(d => d.NumeroDocumentoNavigation).WithMany()
                .HasForeignKey(d => d.NumeroDocumento)
                .HasConstraintName("FK_Detalle_Documento_Documentos");
        });

        modelBuilder.Entity<Documento>(entity =>
        {
            entity.HasKey(e => e.NumeroDocumento);

            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numeroDocumento");
            entity.Property(e => e.CodigoLibreta).HasColumnName("codigoLibreta");
            entity.Property(e => e.CodigoTerminoCredito).HasColumnName("codigoTerminoCredito");
            entity.Property(e => e.CodigoTipoDocumento).HasColumnName("codigoTipoDocumento");
            entity.Property(e => e.EstadoDocumento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estadoDocumento");
            entity.Property(e => e.FechaDocumento)
                .HasColumnType("date")
                .HasColumnName("fechaDocumento");
            entity.Property(e => e.FechaVencimiento)
                .HasColumnType("date")
                .HasColumnName("fechaVencimiento");
            entity.Property(e => e.MontoIsv)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("montoISV");
            entity.Property(e => e.MontoTotal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("montoTotal");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("subtotal");

            entity.HasOne(d => d.CodigoLibretaNavigation).WithMany(p => p.Documentos)
                .HasForeignKey(d => d.CodigoLibreta)
                .HasConstraintName("FK_Documentos_Libreta_Direcciones");

            entity.HasOne(d => d.CodigoTipoDocumentoNavigation).WithMany(p => p.Documentos)
                .HasForeignKey(d => d.CodigoTipoDocumento)
                .HasConstraintName("FK_Documentos_Tipo_Documento");
        });

        modelBuilder.Entity<LibretaDireccione>(entity =>
        {
            entity.HasKey(e => e.CodigoLibreta);

            entity.ToTable("Libreta_Direcciones");

            entity.Property(e => e.CodigoLibreta).HasColumnName("codigoLibreta");
            entity.Property(e => e.CiudadOrigen)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ciudadOrigen");
            entity.Property(e => e.CodigoCategoria).HasColumnName("codigoCategoria");
            entity.Property(e => e.CodigoTerminoCredito).HasColumnName("codigoTerminoCredito");
            entity.Property(e => e.CodigoTipo).HasColumnName("codigoTipo");
            entity.Property(e => e.NombreLibreta)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreLibreta");

            entity.HasOne(d => d.CodigoCategoriaNavigation).WithMany(p => p.LibretaDirecciones)
                .HasForeignKey(d => d.CodigoCategoria)
                .HasConstraintName("FK_Libreta_Direcciones_Categoria_Libreta");

            entity.HasOne(d => d.CodigoTerminoCreditoNavigation).WithMany(p => p.LibretaDirecciones)
                .HasForeignKey(d => d.CodigoTerminoCredito)
                .HasConstraintName("FK_Libreta_Direcciones_Terminos_Credito");

            entity.HasOne(d => d.CodigoTipoNavigation).WithMany(p => p.LibretaDirecciones)
                .HasForeignKey(d => d.CodigoTipo)
                .HasConstraintName("FK_Libreta_Direcciones_Tipo_Libreta");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.CodigoProducto);

            entity.Property(e => e.CodigoProducto).HasColumnName("codigoProducto");
            entity.Property(e => e.CodigoLibreta).HasColumnName("codigoLibreta");
            entity.Property(e => e.DescripcionProducto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcionProducto");
            entity.Property(e => e.PrecioCompra)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("precioCompra");
            entity.Property(e => e.PrecioVenta)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("precioVenta");
        });

        modelBuilder.Entity<TerminosCredito>(entity =>
        {
            entity.HasKey(e => e.CodigoTerminoCredito);

            entity.ToTable("Terminos_Credito");

            entity.Property(e => e.CodigoTerminoCredito).HasColumnName("codigoTerminoCredito");
            entity.Property(e => e.CantidadDias)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("cantidadDias");
            entity.Property(e => e.DescripcionTerminoCredito)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcionTerminoCredito");
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.HasKey(e => e.CodigoTipoDocumento);

            entity.ToTable("Tipo_Documento");

            entity.Property(e => e.CodigoTipoDocumento).HasColumnName("codigoTipoDocumento");
            entity.Property(e => e.DescripcionTipoDocumento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcionTipoDocumento");
        });

        modelBuilder.Entity<TipoLibretum>(entity =>
        {
            entity.HasKey(e => e.CodigoTipo);

            entity.ToTable("Tipo_Libreta");

            entity.Property(e => e.CodigoTipo).HasColumnName("codigoTipo");
            entity.Property(e => e.DescripcionTipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcionTipo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
