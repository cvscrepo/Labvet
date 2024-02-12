using System;
using System.Collections.Generic;
using GestionLab.Model;
using Microsoft.EntityFrameworkCore;

namespace GestionLab.DAL.DBContext;

public partial class GestionlabContext : DbContext
{
    public GestionlabContext()
    {
    }

    public GestionlabContext(DbContextOptions<GestionlabContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Campo> Campos { get; set; }

    public virtual DbSet<Formato> Formatos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Solicitud> Solicituds { get; set; }

    public virtual DbSet<TipoCampo> TipoCampos { get; set; }

    public virtual DbSet<TipoSolicitud> TipoSolicituds { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Campo>(entity =>
        {
            entity.HasKey(e => e.IdCampo).HasName("PK__Campo__5245D63C8F5C3F72");

            entity.ToTable("Campo");

            entity.Property(e => e.IdCampo).HasColumnName("idCampo");
            entity.Property(e => e.IdFormato).HasColumnName("idFormato");
            entity.Property(e => e.IdTipoCampo).HasColumnName("idTipoCampo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Valor)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("valor");

            entity.HasOne(d => d.IdFormatoNavigation).WithMany(p => p.Campos)
                .HasForeignKey(d => d.IdFormato)
                .HasConstraintName("FK__Campo__idFormato__5535A963");

            entity.HasOne(d => d.IdTipoCampoNavigation).WithMany(p => p.Campos)
                .HasForeignKey(d => d.IdTipoCampo)
                .HasConstraintName("FK__Campo__idTipoCam__5629CD9C");
        });

        modelBuilder.Entity<Formato>(entity =>
        {
            entity.HasKey(e => e.IdFormato).HasName("PK__Formato__60E489D163B79BB7");

            entity.ToTable("Formato");

            entity.Property(e => e.IdFormato).HasColumnName("idFormato");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Formatos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Formato__idUsuar__4F7CD00D");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__3C872F767A629485");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Solicitud>(entity =>
        {
            entity.HasKey(e => e.IdSolicitud).HasName("PK__Solicitu__D801DDB884B4555A");

            entity.ToTable("Solicitud");

            entity.Property(e => e.IdSolicitud).HasColumnName("idSolicitud");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdFormato).HasColumnName("idFormato");
            entity.Property(e => e.IdTipo).HasColumnName("idTipo");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.IdFormatoNavigation).WithMany(p => p.Solicituds)
                .HasForeignKey(d => d.IdFormato)
                .HasConstraintName("FK__Solicitud__idFor__5CD6CB2B");

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.Solicituds)
                .HasForeignKey(d => d.IdTipo)
                .HasConstraintName("FK__Solicitud__idTip__5BE2A6F2");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Solicituds)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Solicitud__idUsu__5AEE82B9");
        });

        modelBuilder.Entity<TipoCampo>(entity =>
        {
            entity.HasKey(e => e.IdTipoCampo).HasName("PK__TipoCamp__C984E5BAB898F0B2");

            entity.ToTable("TipoCampo");

            entity.Property(e => e.IdTipoCampo).HasColumnName("idTipoCampo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TipoSolicitud>(entity =>
        {
            entity.HasKey(e => e.IdTipoSolicitud).HasName("PK__TipoSoli__4B3A35EAAA9915F2");

            entity.ToTable("TipoSolicitud");

            entity.Property(e => e.IdTipoSolicitud).HasColumnName("idTipoSolicitud");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__645723A6484423F8");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contrasena");
            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Nit).HasColumnName("nit");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("updateAt");
            entity.Property(e => e.UrlFoto)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("urlFoto");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__idRol__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
