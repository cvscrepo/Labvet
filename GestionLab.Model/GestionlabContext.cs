using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GestionLab.Model;

public partial class GestionlabContext : DbContext
{
    public GestionlabContext()
    {
    }

    public GestionlabContext(DbContextOptions<GestionlabContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CampoFormato> CampoFormatos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Formato> Formatos { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Raza> Razas { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Solicitud> Solicituds { get; set; }

    public virtual DbSet<Sucursal> Sucursals { get; set; }

    public virtual DbSet<TipoCampo> TipoCampos { get; set; }

    public virtual DbSet<TipoFormato> TipoFormatos { get; set; }

    public virtual DbSet<TipoIdentificacion> TipoIdentificacions { get; set; }

    public virtual DbSet<TipoMuestra> TipoMuestras { get; set; }

    public virtual DbSet<TipoSolicitud> TipoSolicituds { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Veterinario> Veterinarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //if (!optionsBuilder.IsConfigured)
        //{

        //    optionsBuilder.UseSqlServer(
        //        "Server=(local); DataBase=GESTIONLAB; Trusted_Connection=True; TrustServerCertificate=True;",
        //        options => options.MigrationsAssembly("GestionLab.DAL")

        //        );
        //}
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CampoFormato>(entity =>
        {
            entity.HasKey(e => e.IdCampo).HasName("PK__CampoFor__5245D63C288E6FA6");

            entity.ToTable("CampoFormato");

            entity.HasIndex(e => e.IdFormato, "IX_CampoFormato_idFormato");

            entity.HasIndex(e => e.IdTipoCampo, "IX_CampoFormato_idTipoCampo");

            entity.Property(e => e.IdCampo).HasColumnName("idCampo");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.IdFormato).HasColumnName("idFormato");
            entity.Property(e => e.IdTipoCampo).HasColumnName("idTipoCampo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UrlFoto)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("urlFoto");
            entity.Property(e => e.Valor)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("valor");

            entity.HasOne(d => d.IdFormatoNavigation).WithMany(p => p.CampoFormatos)
                .HasForeignKey(d => d.IdFormato)
                .HasConstraintName("FK__CampoForm__idFor__5DCAEF64");

            entity.HasOne(d => d.IdTipoCampoNavigation).WithMany(p => p.CampoFormatos)
                .HasForeignKey(d => d.IdTipoCampo)
                .HasConstraintName("FK__CampoForm__idTip__5EBF139D");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__885457EEF9B0B2DA");

            entity.ToTable("Cliente");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("correoElectronico");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombreCompleto");
            entity.Property(e => e.Telefono)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("telefono");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
        });

        modelBuilder.Entity<Formato>(entity =>
        {
            entity.HasKey(e => e.IdFormato).HasName("PK__Formato__60E489D17C035DC2");

            entity.ToTable("Formato");

            entity.HasIndex(e => e.IdSolicitud, "IX_Formato_idSolicitud");

            entity.HasIndex(e => e.IdTipoFormato, "IX_Formato_idTipoFormato");

            entity.HasIndex(e => e.IdUsuario, "IX_Formato_idUsuario");

            entity.Property(e => e.IdFormato).HasColumnName("idFormato");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.IdSolicitud).HasColumnName("idSolicitud");
            entity.Property(e => e.IdTipoFormato).HasColumnName("idTipoFormato");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.IdSolicitudNavigation).WithMany(p => p.Formatos)
                .HasForeignKey(d => d.IdSolicitud)
                .HasConstraintName("FK__Formato__idSolic__5812160E");

            entity.HasOne(d => d.IdTipoFormatoNavigation).WithMany(p => p.Formatos)
                .HasForeignKey(d => d.IdTipoFormato)
                .HasConstraintName("FK__Formato__idTipoF__571DF1D5");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Formatos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Formato__idUsuar__5629CD9C");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("PK__Paciente__F48A08F2EF56DCA9");

            entity.ToTable("Paciente");

            entity.HasIndex(e => e.IdCliente, "IX_Paciente_idCliente");

            entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.NombrePaciente)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombrePaciente");
            entity.Property(e => e.Raza)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("raza");
            entity.Property(e => e.UptadetAt)
                .HasColumnType("datetime")
                .HasColumnName("uptadetAt");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Paciente__idClie__48CFD27E");
        });

        modelBuilder.Entity<Raza>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Raza__3213E83FDBDB844A");

            entity.ToTable("Raza");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__3C872F768FF23456");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Solicitud>(entity =>
        {
            entity.HasKey(e => e.IdSolicitud).HasName("PK__Solicitu__D801DDB8D29C92F6");

            entity.ToTable("Solicitud");

            entity.HasIndex(e => e.CreatedBy, "IX_Solicitud_createdBy");

            entity.HasIndex(e => e.IdCliente, "IX_Solicitud_idCliente");

            entity.HasIndex(e => e.IdPaciente, "IX_Solicitud_idPaciente");

            entity.HasIndex(e => e.IdTipoSolicitud, "IX_Solicitud_idTipoSolicitud");

            entity.Property(e => e.IdSolicitud).HasColumnName("idSolicitud");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaRecoleccion)
                .HasColumnType("datetime")
                .HasColumnName("fechaRecoleccion");
            entity.Property(e => e.HoraRecoleccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("horaRecoleccion");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");
            entity.Property(e => e.IdTipoSolicitud).HasColumnName("idTipoSolicitud");
            entity.Property(e => e.IdVeterinario).HasColumnName("idVeterinario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Obserevaciones)
                .HasColumnType("text")
                .HasColumnName("obserevaciones");
            entity.Property(e => e.TamanoFragmento)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("tamanoFragmento");
            entity.Property(e => e.TipoExamen).HasColumnName("tipoExamen");
            entity.Property(e => e.TipoMuestra).HasColumnName("tipoMuestra");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UrlFotoMuestra)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("urlFotoMuestra");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Solicituds)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Solicitud__creat__4F7CD00D");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Solicituds)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Solicitud__idCli__5165187F");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Solicituds)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Solicitud__idPac__52593CB8");

            entity.HasOne(d => d.IdTipoSolicitudNavigation).WithMany(p => p.Solicituds)
                .HasForeignKey(d => d.IdTipoSolicitud)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Solicitud__idTip__5070F446");

            entity.HasOne(d => d.IdVeterinarioNavigation).WithMany(p => p.Solicituds)
                .HasForeignKey(d => d.IdVeterinario)
                .HasConstraintName("FK__Solicitud__idVet__75A278F5");

            entity.HasOne(d => d.TipoExamenNavigation).WithMany(p => p.Solicituds)
                .HasForeignKey(d => d.TipoExamen)
                .HasConstraintName("FK__Solicitud__tipoE__797309D9");

            entity.HasOne(d => d.TipoMuestraNavigation).WithMany(p => p.Solicituds)
                .HasForeignKey(d => d.TipoMuestra)
                .HasConstraintName("FK__Solicitud__tipoM__787EE5A0");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.IdSucursal).HasName("PK__Sucursal__F707694C1E8FEE78");

            entity.ToTable("Sucursal");

            entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ciudad");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Pais)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pais");
            entity.Property(e => e.Telefono)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("telefono");
            entity.Property(e => e.UptadedAt)
                .HasColumnType("datetime")
                .HasColumnName("uptadedAt");
        });

        modelBuilder.Entity<TipoCampo>(entity =>
        {
            entity.HasKey(e => e.IdTipoCampo).HasName("PK__TipoCamp__C984E5BAD6EA4A04");

            entity.ToTable("TipoCampo");

            entity.Property(e => e.IdTipoCampo).HasColumnName("idTipoCampo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.TipoCampo1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tipoCampo");
            entity.Property(e => e.ValorReferencia)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("valorReferencia");
        });

        modelBuilder.Entity<TipoFormato>(entity =>
        {
            entity.HasKey(e => e.IdTipoFormato).HasName("PK__TipoForm__02A6E74963CB1972");

            entity.ToTable("TipoFormato");

            entity.Property(e => e.IdTipoFormato).HasColumnName("idTipoFormato");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TipoIdentificacion>(entity =>
        {
            entity.HasKey(e => e.IdTipoIdentificacion).HasName("PK__TipoIden__3F0ADFF6871FE323");

            entity.ToTable("TipoIdentificacion");

            entity.Property(e => e.IdTipoIdentificacion).HasColumnName("idTipoIdentificacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TipoMuestra>(entity =>
        {
            entity.HasKey(e => e.IdTipoMuestra).HasName("PK__tipoMues__996B67DC3E8F26BA");

            entity.ToTable("TipoMuestra");

            entity.Property(e => e.IdTipoMuestra).HasColumnName("idTipoMuestra");
            entity.Property(e => e.NombreTipo)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nombreTipo");
        });

        modelBuilder.Entity<TipoSolicitud>(entity =>
        {
            entity.HasKey(e => e.IdTipoSolicitud).HasName("PK__TipoSoli__4B3A35EAEA0989F6");

            entity.ToTable("TipoSolicitud");

            entity.Property(e => e.IdTipoSolicitud).HasColumnName("idTipoSolicitud");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.Valor).HasColumnName("valor");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__645723A6D5A59267");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.IdRol, "IX_Usuario_idRol");

            entity.HasIndex(e => e.IdSucursal, "IX_Usuario_idSucursal");

            entity.HasIndex(e => e.IdTipoIdentificacion, "IX_Usuario_idTipoIdentificacion");

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
            entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");
            entity.Property(e => e.IdTipoIdentificacion).HasColumnName("idTipoIdentificacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NumeroIdentificacion).HasColumnName("numeroIdentificacion");
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
                .HasConstraintName("FK__Usuario__idRol__3E52440B");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdSucursal)
                .HasConstraintName("FK__Usuario__idSucur__3F466844");

            entity.HasOne(d => d.IdTipoIdentificacionNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdTipoIdentificacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__idTipoI__403A8C7D");
        });

        modelBuilder.Entity<Veterinario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vetarina__3213E83F0367846E");

            entity.ToTable("Veterinario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.TarjetaProfesional)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tarjetaProfesional");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Veterinarios)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Vetarinar__idUsu__71D1E811");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
