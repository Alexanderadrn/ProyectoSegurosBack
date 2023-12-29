using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoSegurosBack.Models;

public partial class SegurosContext : DbContext
{
    public SegurosContext()
    {
    }

    public SegurosContext(DbContextOptions<SegurosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Poliza> Polizas { get; set; }

    public virtual DbSet<Seguro> Seguros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-S78SCGN;Database=seguros;Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersonas).HasName("PK__personas__05A92012E9EC0548");

            entity.ToTable("personas");

            entity.Property(e => e.CedulaPersonas)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NombrePersonas)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TelefonoPersonas)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Poliza>(entity =>
        {
            entity.HasKey(e => e.IdPoliza).HasName("PK__polizas__730AB2BAF2153C05");

            entity.ToTable("polizas");

            entity.HasOne(d => d.IdPersonasNavigation).WithMany(p => p.Polizas)
                .HasForeignKey(d => d.IdPersonas)
                .HasConstraintName("FK_CedPersonas");

            entity.HasOne(d => d.IdSeguroNavigation).WithMany(p => p.Polizas)
                .HasForeignKey(d => d.IdSeguro)
                .HasConstraintName("FK_CodSeguros");
        });

        modelBuilder.Entity<Seguro>(entity =>
        {
            entity.HasKey(e => e.IdSeguro).HasName("PK__seguros__730AB2BA4E797B47");

            entity.ToTable("seguros");

            entity.Property(e => e.CodigoSeguro)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombreSeguo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Prima).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.SumaAsegurada).HasColumnType("decimal(18, 0)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
