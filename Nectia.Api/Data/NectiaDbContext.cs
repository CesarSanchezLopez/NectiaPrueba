using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Models.Models;
namespace Nectia.Api.Data;

public partial class NectiaDbContext : DbContext
{
    public NectiaDbContext()
    {
    }

    public NectiaDbContext(DbContextOptions<NectiaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Perfil> Perfils { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=NectiaDB;TrustServerCertificate=True;User id=sa;Password=123456789");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Perfil>(entity =>
        {
            entity.ToTable("Perfil");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.ToTable("Producto");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(1500)
                .IsUnicode(false);
            entity.Property(e => e.Imagen).HasColumnType("image");
            entity.Property(e => e.Marca)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriaId)
                .HasConstraintName("FK_Producto_Categoria");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("Usuario");

            entity.Property(e => e.Password)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PrimerNombre)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.SegundoNombre)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.User)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.Perfil).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.PerfilId)
                .HasConstraintName("FK_Usuario_Perfil");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.ToTable("Vehiculo");

           // entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Chasis)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Marca)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Modelo)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Placa)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Version)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
