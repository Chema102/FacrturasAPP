using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FacturasAPP.DAC.Models;

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

    public virtual DbSet<Product> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

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


        });

        modelBuilder.Entity<Product>(entity =>
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
