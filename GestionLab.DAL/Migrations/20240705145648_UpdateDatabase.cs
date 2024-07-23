using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionLab.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "valor",
                table: "TipoSolicitud",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaRecoleccion",
                table: "Solicitud",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "horaRecoleccion",
                table: "Solicitud",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "idVeterinario",
                table: "Solicitud",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "obserevaciones",
                table: "Solicitud",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tamanoFragmento",
                table: "Solicitud",
                type: "varchar(150)",
                unicode: false,
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tipoExamen",
                table: "Solicitud",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tipoMuestra",
                table: "Solicitud",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "urlFotoMuestra",
                table: "Solicitud",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Raza",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Raza__3213E83FDBDB844A", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    idServicios = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreServicio = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: false),
                    imgReferenced = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Servicio__185EC2A0A25A0A7E", x => x.idServicios);
                });

            migrationBuilder.CreateTable(
                name: "TipoMuestra",
                columns: table => new
                {
                    idTipoMuestra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreTipo = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tipoMues__996B67DC3E8F26BA", x => x.idTipoMuestra);
                });

            migrationBuilder.CreateTable(
                name: "Veterinario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUsuario = table.Column<int>(type: "int", nullable: true),
                    nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    tarjetaProfesional = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Vetarina__3213E83F0367846E", x => x.id);
                    table.ForeignKey(
                        name: "FK__Vetarinar__idUsu__71D1E811",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_idVeterinario",
                table: "Solicitud",
                column: "idVeterinario");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_tipoExamen",
                table: "Solicitud",
                column: "tipoExamen");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitud_tipoMuestra",
                table: "Solicitud",
                column: "tipoMuestra");

            migrationBuilder.CreateIndex(
                name: "IX_Veterinario_idUsuario",
                table: "Veterinario",
                column: "idUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK__Solicitud__idVet__75A278F5",
                table: "Solicitud",
                column: "idVeterinario",
                principalTable: "Veterinario",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__Solicitud__tipoE__797309D9",
                table: "Solicitud",
                column: "tipoExamen",
                principalTable: "TipoFormato",
                principalColumn: "idTipoFormato");

            migrationBuilder.AddForeignKey(
                name: "FK__Solicitud__tipoM__787EE5A0",
                table: "Solicitud",
                column: "tipoMuestra",
                principalTable: "TipoMuestra",
                principalColumn: "idTipoMuestra");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Solicitud__idVet__75A278F5",
                table: "Solicitud");

            migrationBuilder.DropForeignKey(
                name: "FK__Solicitud__tipoE__797309D9",
                table: "Solicitud");

            migrationBuilder.DropForeignKey(
                name: "FK__Solicitud__tipoM__787EE5A0",
                table: "Solicitud");

            migrationBuilder.DropTable(
                name: "Raza");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "TipoMuestra");

            migrationBuilder.DropTable(
                name: "Veterinario");

            migrationBuilder.DropIndex(
                name: "IX_Solicitud_idVeterinario",
                table: "Solicitud");

            migrationBuilder.DropIndex(
                name: "IX_Solicitud_tipoExamen",
                table: "Solicitud");

            migrationBuilder.DropIndex(
                name: "IX_Solicitud_tipoMuestra",
                table: "Solicitud");

            migrationBuilder.DropColumn(
                name: "valor",
                table: "TipoSolicitud");

            migrationBuilder.DropColumn(
                name: "fechaRecoleccion",
                table: "Solicitud");

            migrationBuilder.DropColumn(
                name: "horaRecoleccion",
                table: "Solicitud");

            migrationBuilder.DropColumn(
                name: "idVeterinario",
                table: "Solicitud");

            migrationBuilder.DropColumn(
                name: "obserevaciones",
                table: "Solicitud");

            migrationBuilder.DropColumn(
                name: "tamanoFragmento",
                table: "Solicitud");

            migrationBuilder.DropColumn(
                name: "tipoExamen",
                table: "Solicitud");

            migrationBuilder.DropColumn(
                name: "tipoMuestra",
                table: "Solicitud");

            migrationBuilder.DropColumn(
                name: "urlFotoMuestra",
                table: "Solicitud");
        }
    }
}
