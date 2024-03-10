using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionLab.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    idCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreCompleto = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    correoElectronico = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    telefono = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    direccion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cliente__885457EEF9B0B2DA", x => x.idCliente);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    idRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rol__3C872F768FF23456", x => x.idRol);
                });

            migrationBuilder.CreateTable(
                name: "Sucursal",
                columns: table => new
                {
                    idSucursal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    pais = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ciudad = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    direccion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    telefono = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    uptadedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Sucursal__F707694C1E8FEE78", x => x.idSucursal);
                });

            migrationBuilder.CreateTable(
                name: "TipoCampo",
                columns: table => new
                {
                    idTipoCampo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    tipoCampo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    valorReferencia = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TipoCamp__C984E5BAD6EA4A04", x => x.idTipoCampo);
                });

            migrationBuilder.CreateTable(
                name: "TipoFormato",
                columns: table => new
                {
                    idTipoFormato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TipoForm__02A6E74963CB1972", x => x.idTipoFormato);
                });

            migrationBuilder.CreateTable(
                name: "TipoIdentificacion",
                columns: table => new
                {
                    idTipoIdentificacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TipoIden__3F0ADFF6871FE323", x => x.idTipoIdentificacion);
                });

            migrationBuilder.CreateTable(
                name: "TipoSolicitud",
                columns: table => new
                {
                    idTipoSolicitud = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TipoSoli__4B3A35EAEA0989F6", x => x.idTipoSolicitud);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    idPaciente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCliente = table.Column<int>(type: "int", nullable: true),
                    nombrePaciente = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    raza = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    uptadetAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Paciente__F48A08F2EF56DCA9", x => x.idPaciente);
                    table.ForeignKey(
                        name: "FK__Paciente__idClie__48CFD27E",
                        column: x => x.idCliente,
                        principalTable: "Cliente",
                        principalColumn: "idCliente");
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idRol = table.Column<int>(type: "int", nullable: false),
                    idSucursal = table.Column<int>(type: "int", nullable: true),
                    idTipoIdentificacion = table.Column<int>(type: "int", nullable: false),
                    numeroIdentificacion = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    correo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    contrasena = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    urlFoto = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    estado = table.Column<bool>(type: "bit", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updateAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__645723A6D5A59267", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK__Usuario__idRol__3E52440B",
                        column: x => x.idRol,
                        principalTable: "Rol",
                        principalColumn: "idRol");
                    table.ForeignKey(
                        name: "FK__Usuario__idSucur__3F466844",
                        column: x => x.idSucursal,
                        principalTable: "Sucursal",
                        principalColumn: "idSucursal");
                    table.ForeignKey(
                        name: "FK__Usuario__idTipoI__403A8C7D",
                        column: x => x.idTipoIdentificacion,
                        principalTable: "TipoIdentificacion",
                        principalColumn: "idTipoIdentificacion");
                });

            migrationBuilder.CreateTable(
                name: "Solicitud",
                columns: table => new
                {
                    idSolicitud = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    createdBy = table.Column<int>(type: "int", nullable: false),
                    idTipoSolicitud = table.Column<int>(type: "int", nullable: false),
                    idCliente = table.Column<int>(type: "int", nullable: false),
                    idPaciente = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Solicitu__D801DDB8D29C92F6", x => x.idSolicitud);
                    table.ForeignKey(
                        name: "FK__Solicitud__creat__4F7CD00D",
                        column: x => x.createdBy,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario");
                    table.ForeignKey(
                        name: "FK__Solicitud__idCli__5165187F",
                        column: x => x.idCliente,
                        principalTable: "Cliente",
                        principalColumn: "idCliente");
                    table.ForeignKey(
                        name: "FK__Solicitud__idPac__52593CB8",
                        column: x => x.idPaciente,
                        principalTable: "Paciente",
                        principalColumn: "idPaciente");
                    table.ForeignKey(
                        name: "FK__Solicitud__idTip__5070F446",
                        column: x => x.idTipoSolicitud,
                        principalTable: "TipoSolicitud",
                        principalColumn: "idTipoSolicitud");
                });

            migrationBuilder.CreateTable(
                name: "Formato",
                columns: table => new
                {
                    idFormato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUsuario = table.Column<int>(type: "int", nullable: true),
                    idTipoFormato = table.Column<int>(type: "int", nullable: true),
                    idSolicitud = table.Column<int>(type: "int", nullable: true),
                    nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Formato__60E489D17C035DC2", x => x.idFormato);
                    table.ForeignKey(
                        name: "FK__Formato__idSolic__5812160E",
                        column: x => x.idSolicitud,
                        principalTable: "Solicitud",
                        principalColumn: "idSolicitud");
                    table.ForeignKey(
                        name: "FK__Formato__idTipoF__571DF1D5",
                        column: x => x.idTipoFormato,
                        principalTable: "TipoFormato",
                        principalColumn: "idTipoFormato");
                    table.ForeignKey(
                        name: "FK__Formato__idUsuar__5629CD9C",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario");
                });

            migrationBuilder.CreateTable(
                name: "CampoFormato",
                columns: table => new
                {
                    idCampo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idFormato = table.Column<int>(type: "int", nullable: true),
                    idTipoCampo = table.Column<int>(type: "int", nullable: true),
                    nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    valor = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    urlFoto = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CampoFor__5245D63C288E6FA6", x => x.idCampo);
                    table.ForeignKey(
                        name: "FK__CampoForm__idFor__5DCAEF64",
                        column: x => x.idFormato,
                        principalTable: "Formato",
                        principalColumn: "idFormato");
                    table.ForeignKey(
                        name: "FK__CampoForm__idTip__5EBF139D",
                        column: x => x.idTipoCampo,
                        principalTable: "TipoCampo",
                        principalColumn: "idTipoCampo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampoFormato_idFormato",
                table: "CampoFormato",
                column: "idFormato");

            migrationBuilder.CreateIndex(
                name: "IX_CampoFormato_idTipoCampo",
                table: "CampoFormato",
                column: "idTipoCampo");

            migrationBuilder.CreateIndex(
                name: "IX_Formato_idSolicitud",
                table: "Formato",
                column: "idSolicitud");

            migrationBuilder.CreateIndex(
                name: "IX_Formato_idTipoFormato",
                table: "Formato",
                column: "idTipoFormato");

            migrationBuilder.CreateIndex(
                name: "IX_Formato_idUsuario",
                table: "Formato",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_idCliente",
                table: "Paciente",
                column: "idCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_createdBy",
                table: "Solicitud",
                column: "createdBy");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_idCliente",
                table: "Solicitud",
                column: "idCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_idPaciente",
                table: "Solicitud",
                column: "idPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_idTipoSolicitud",
                table: "Solicitud",
                column: "idTipoSolicitud");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_idRol",
                table: "Usuario",
                column: "idRol");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_idSucursal",
                table: "Usuario",
                column: "idSucursal");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_idTipoIdentificacion",
                table: "Usuario",
                column: "idTipoIdentificacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampoFormato");

            migrationBuilder.DropTable(
                name: "Formato");

            migrationBuilder.DropTable(
                name: "TipoCampo");

            migrationBuilder.DropTable(
                name: "Solicitud");

            migrationBuilder.DropTable(
                name: "TipoFormato");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "TipoSolicitud");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Sucursal");

            migrationBuilder.DropTable(
                name: "TipoIdentificacion");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
