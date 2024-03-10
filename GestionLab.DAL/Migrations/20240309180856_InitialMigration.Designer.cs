﻿// <auto-generated />
using System;
using GestionLab.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionLab.DAL.Migrations
{
    [DbContext(typeof(GestionlabContext))]
    [Migration("20240309180856_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestionLab.Model.CampoFormato", b =>
                {
                    b.Property<int>("IdCampo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idCampo");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCampo"));

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("createdAt")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("IdFormato")
                        .HasColumnType("int")
                        .HasColumnName("idFormato");

                    b.Property<int?>("IdTipoCampo")
                        .HasColumnType("int")
                        .HasColumnName("idTipoCampo");

                    b.Property<string>("Nombre")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nombre");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updatedAt");

                    b.Property<string>("UrlFoto")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("urlFoto");

                    b.Property<string>("Valor")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("valor");

                    b.HasKey("IdCampo")
                        .HasName("PK__CampoFor__5245D63C288E6FA6");

                    b.HasIndex("IdFormato");

                    b.HasIndex("IdTipoCampo");

                    b.ToTable("CampoFormato", (string)null);
                });

            modelBuilder.Entity("GestionLab.Model.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idCliente");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"));

                    b.Property<string>("CorreoElectronico")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("correoElectronico");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("createdAt")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Direccion")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("direccion");

                    b.Property<string>("NombreCompleto")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nombreCompleto");

                    b.Property<string>("Telefono")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("telefono");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updatedAt");

                    b.HasKey("IdCliente")
                        .HasName("PK__Cliente__885457EEF9B0B2DA");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("GestionLab.Model.Formato", b =>
                {
                    b.Property<int>("IdFormato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idFormato");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFormato"));

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("createdAt")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("IdSolicitud")
                        .HasColumnType("int")
                        .HasColumnName("idSolicitud");

                    b.Property<int?>("IdTipoFormato")
                        .HasColumnType("int")
                        .HasColumnName("idTipoFormato");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int")
                        .HasColumnName("idUsuario");

                    b.Property<string>("Nombre")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nombre");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updatedAt");

                    b.HasKey("IdFormato")
                        .HasName("PK__Formato__60E489D17C035DC2");

                    b.HasIndex("IdSolicitud");

                    b.HasIndex("IdTipoFormato");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Formato", (string)null);
                });

            modelBuilder.Entity("GestionLab.Model.Paciente", b =>
                {
                    b.Property<int>("IdPaciente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idPaciente");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPaciente"));

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("createdAt")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("IdCliente")
                        .HasColumnType("int")
                        .HasColumnName("idCliente");

                    b.Property<string>("NombrePaciente")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nombrePaciente");

                    b.Property<string>("Raza")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("raza");

                    b.Property<DateTime?>("UptadetAt")
                        .HasColumnType("datetime")
                        .HasColumnName("uptadetAt");

                    b.HasKey("IdPaciente")
                        .HasName("PK__Paciente__F48A08F2EF56DCA9");

                    b.HasIndex("IdCliente");

                    b.ToTable("Paciente", (string)null);
                });

            modelBuilder.Entity("GestionLab.Model.Rol", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idRol");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRol"));

                    b.Property<string>("Nombre")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nombre");

                    b.HasKey("IdRol")
                        .HasName("PK__Rol__3C872F768FF23456");

                    b.ToTable("Rol", (string)null);
                });

            modelBuilder.Entity("GestionLab.Model.Solicitud", b =>
                {
                    b.Property<int>("IdSolicitud")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idSolicitud");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSolicitud"));

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("createdAt")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int")
                        .HasColumnName("createdBy");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit")
                        .HasColumnName("estado");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int")
                        .HasColumnName("idCliente");

                    b.Property<int>("IdPaciente")
                        .HasColumnType("int")
                        .HasColumnName("idPaciente");

                    b.Property<int>("IdTipoSolicitud")
                        .HasColumnType("int")
                        .HasColumnName("idTipoSolicitud");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nombre");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updatedAt");

                    b.HasKey("IdSolicitud")
                        .HasName("PK__Solicitu__D801DDB8D29C92F6");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdPaciente");

                    b.HasIndex("IdTipoSolicitud");

                    b.ToTable("Solicitud", (string)null);
                });

            modelBuilder.Entity("GestionLab.Model.Sucursal", b =>
                {
                    b.Property<int>("IdSucursal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idSucursal");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSucursal"));

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("ciudad");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("createdAt")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("direccion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("nombre");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("pais");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("telefono");

                    b.Property<DateTime?>("UptadedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("uptadedAt");

                    b.HasKey("IdSucursal")
                        .HasName("PK__Sucursal__F707694C1E8FEE78");

                    b.ToTable("Sucursal", (string)null);
                });

            modelBuilder.Entity("GestionLab.Model.TipoCampo", b =>
                {
                    b.Property<int>("IdTipoCampo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idTipoCampo");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoCampo"));

                    b.Property<string>("Nombre")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nombre");

                    b.Property<string>("TipoCampo1")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("tipoCampo");

                    b.Property<string>("ValorReferencia")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("valorReferencia");

                    b.HasKey("IdTipoCampo")
                        .HasName("PK__TipoCamp__C984E5BAD6EA4A04");

                    b.ToTable("TipoCampo", (string)null);
                });

            modelBuilder.Entity("GestionLab.Model.TipoFormato", b =>
                {
                    b.Property<int>("IdTipoFormato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idTipoFormato");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoFormato"));

                    b.Property<string>("Nombre")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("nombre");

                    b.HasKey("IdTipoFormato")
                        .HasName("PK__TipoForm__02A6E74963CB1972");

                    b.ToTable("TipoFormato", (string)null);
                });

            modelBuilder.Entity("GestionLab.Model.TipoIdentificacion", b =>
                {
                    b.Property<int>("IdTipoIdentificacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idTipoIdentificacion");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoIdentificacion"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nombre");

                    b.HasKey("IdTipoIdentificacion")
                        .HasName("PK__TipoIden__3F0ADFF6871FE323");

                    b.ToTable("TipoIdentificacion", (string)null);
                });

            modelBuilder.Entity("GestionLab.Model.TipoSolicitud", b =>
                {
                    b.Property<int>("IdTipoSolicitud")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idTipoSolicitud");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoSolicitud"));

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("createdAt")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Nombre")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nombre");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updatedAt");

                    b.HasKey("IdTipoSolicitud")
                        .HasName("PK__TipoSoli__4B3A35EAEA0989F6");

                    b.ToTable("TipoSolicitud", (string)null);
                });

            modelBuilder.Entity("GestionLab.Model.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idUsuario");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("contrasena");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("correo");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("createdAt")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit")
                        .HasColumnName("estado");

                    b.Property<int>("IdRol")
                        .HasColumnType("int")
                        .HasColumnName("idRol");

                    b.Property<int?>("IdSucursal")
                        .HasColumnType("int")
                        .HasColumnName("idSucursal");

                    b.Property<int>("IdTipoIdentificacion")
                        .HasColumnType("int")
                        .HasColumnName("idTipoIdentificacion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nombre");

                    b.Property<int>("NumeroIdentificacion")
                        .HasColumnType("int")
                        .HasColumnName("numeroIdentificacion");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updateAt");

                    b.Property<string>("UrlFoto")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("urlFoto");

                    b.HasKey("IdUsuario")
                        .HasName("PK__Usuario__645723A6D5A59267");

                    b.HasIndex("IdRol");

                    b.HasIndex("IdSucursal");

                    b.HasIndex("IdTipoIdentificacion");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("GestionLab.Model.CampoFormato", b =>
                {
                    b.HasOne("GestionLab.Model.Formato", "IdFormatoNavigation")
                        .WithMany("CampoFormatos")
                        .HasForeignKey("IdFormato")
                        .HasConstraintName("FK__CampoForm__idFor__5DCAEF64");

                    b.HasOne("GestionLab.Model.TipoCampo", "IdTipoCampoNavigation")
                        .WithMany("CampoFormatos")
                        .HasForeignKey("IdTipoCampo")
                        .HasConstraintName("FK__CampoForm__idTip__5EBF139D");

                    b.Navigation("IdFormatoNavigation");

                    b.Navigation("IdTipoCampoNavigation");
                });

            modelBuilder.Entity("GestionLab.Model.Formato", b =>
                {
                    b.HasOne("GestionLab.Model.Solicitud", "IdSolicitudNavigation")
                        .WithMany("Formatos")
                        .HasForeignKey("IdSolicitud")
                        .HasConstraintName("FK__Formato__idSolic__5812160E");

                    b.HasOne("GestionLab.Model.TipoFormato", "IdTipoFormatoNavigation")
                        .WithMany("Formatos")
                        .HasForeignKey("IdTipoFormato")
                        .HasConstraintName("FK__Formato__idTipoF__571DF1D5");

                    b.HasOne("GestionLab.Model.Usuario", "IdUsuarioNavigation")
                        .WithMany("Formatos")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK__Formato__idUsuar__5629CD9C");

                    b.Navigation("IdSolicitudNavigation");

                    b.Navigation("IdTipoFormatoNavigation");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("GestionLab.Model.Paciente", b =>
                {
                    b.HasOne("GestionLab.Model.Cliente", "IdClienteNavigation")
                        .WithMany("Pacientes")
                        .HasForeignKey("IdCliente")
                        .HasConstraintName("FK__Paciente__idClie__48CFD27E");

                    b.Navigation("IdClienteNavigation");
                });

            modelBuilder.Entity("GestionLab.Model.Solicitud", b =>
                {
                    b.HasOne("GestionLab.Model.Usuario", "CreatedByNavigation")
                        .WithMany("Solicituds")
                        .HasForeignKey("CreatedBy")
                        .IsRequired()
                        .HasConstraintName("FK__Solicitud__creat__4F7CD00D");

                    b.HasOne("GestionLab.Model.Cliente", "IdClienteNavigation")
                        .WithMany("Solicituds")
                        .HasForeignKey("IdCliente")
                        .IsRequired()
                        .HasConstraintName("FK__Solicitud__idCli__5165187F");

                    b.HasOne("GestionLab.Model.Paciente", "IdPacienteNavigation")
                        .WithMany("Solicituds")
                        .HasForeignKey("IdPaciente")
                        .IsRequired()
                        .HasConstraintName("FK__Solicitud__idPac__52593CB8");

                    b.HasOne("GestionLab.Model.TipoSolicitud", "IdTipoSolicitudNavigation")
                        .WithMany("Solicituds")
                        .HasForeignKey("IdTipoSolicitud")
                        .IsRequired()
                        .HasConstraintName("FK__Solicitud__idTip__5070F446");

                    b.Navigation("CreatedByNavigation");

                    b.Navigation("IdClienteNavigation");

                    b.Navigation("IdPacienteNavigation");

                    b.Navigation("IdTipoSolicitudNavigation");
                });

            modelBuilder.Entity("GestionLab.Model.Usuario", b =>
                {
                    b.HasOne("GestionLab.Model.Rol", "IdRolNavigation")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdRol")
                        .IsRequired()
                        .HasConstraintName("FK__Usuario__idRol__3E52440B");

                    b.HasOne("GestionLab.Model.Sucursal", "IdSucursalNavigation")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdSucursal")
                        .HasConstraintName("FK__Usuario__idSucur__3F466844");

                    b.HasOne("GestionLab.Model.TipoIdentificacion", "IdTipoIdentificacionNavigation")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdTipoIdentificacion")
                        .IsRequired()
                        .HasConstraintName("FK__Usuario__idTipoI__403A8C7D");

                    b.Navigation("IdRolNavigation");

                    b.Navigation("IdSucursalNavigation");

                    b.Navigation("IdTipoIdentificacionNavigation");
                });

            modelBuilder.Entity("GestionLab.Model.Cliente", b =>
                {
                    b.Navigation("Pacientes");

                    b.Navigation("Solicituds");
                });

            modelBuilder.Entity("GestionLab.Model.Formato", b =>
                {
                    b.Navigation("CampoFormatos");
                });

            modelBuilder.Entity("GestionLab.Model.Paciente", b =>
                {
                    b.Navigation("Solicituds");
                });

            modelBuilder.Entity("GestionLab.Model.Rol", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("GestionLab.Model.Solicitud", b =>
                {
                    b.Navigation("Formatos");
                });

            modelBuilder.Entity("GestionLab.Model.Sucursal", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("GestionLab.Model.TipoCampo", b =>
                {
                    b.Navigation("CampoFormatos");
                });

            modelBuilder.Entity("GestionLab.Model.TipoFormato", b =>
                {
                    b.Navigation("Formatos");
                });

            modelBuilder.Entity("GestionLab.Model.TipoIdentificacion", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("GestionLab.Model.TipoSolicitud", b =>
                {
                    b.Navigation("Solicituds");
                });

            modelBuilder.Entity("GestionLab.Model.Usuario", b =>
                {
                    b.Navigation("Formatos");

                    b.Navigation("Solicituds");
                });
#pragma warning restore 612, 618
        }
    }
}
