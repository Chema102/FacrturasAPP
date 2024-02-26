using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FacrturasAPP.Models;

public partial class FctContext : DbContext
{
    public FctContext()
    {
    }

    public FctContext(DbContextOptions<FctContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<FacturaDetalle> FacturaDetalles { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PIPO\\SQLEXPRESS; Database=FCT; Trusted_Connection=True; TrustServerCertificate=True ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Factura");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Crt)
                .HasColumnType("datetime")
                .HasColumnName("CRT");
            entity.Property(e => e.Dltt).HasColumnName("DLTT");
            entity.Property(e => e.Total)
                .HasColumnType("money")
                .HasColumnName("total");
            entity.Property(e => e.Uppdt)
                .HasColumnType("datetime")
                .HasColumnName("UPPDT");
        });

        modelBuilder.Entity<FacturaDetalle>(entity =>
        {
            entity.ToTable("FacturaDetalle");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Crt)
                .HasColumnType("datetime")
                .HasColumnName("CRT");
            entity.Property(e => e.Dltt).HasColumnName("DLTT");
            entity.Property(e => e.FacturaId).HasColumnName("FacturaID");
            entity.Property(e => e.Precio).HasColumnType("money");
            entity.Property(e => e.ProductoId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ProductoID");
            entity.Property(e => e.Uppdt)
                .HasColumnType("datetime")
                .HasColumnName("UPPDT");

            entity.HasOne(d => d.Factura).WithMany(p => p.FacturaDetalles)
                .HasForeignKey(d => d.FacturaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacturaDetalle_Facturas");

            entity.HasOne(d => d.Producto).WithMany(p => p.FacturaDetalles)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacturaDetalle_Productos");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ID");
            entity.Property(e => e.Crt)
                .HasColumnType("datetime")
                .HasColumnName("CRT");
            entity.Property(e => e.Descripccion)
                .HasMaxLength(45)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Dltt).HasColumnName("DLTT");
            entity.Property(e => e.Uppdt)
                .HasColumnType("datetime")
                .HasColumnName("UPPDT");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
