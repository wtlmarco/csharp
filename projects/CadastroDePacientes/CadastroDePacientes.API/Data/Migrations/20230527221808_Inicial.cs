using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroDePacientes.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Convenios",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convenio", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataDeNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CPF = table.Column<string>(type: "char(11)", maxLength: 11, nullable: true),
                    RG = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    UFDoRG = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Celular = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    TelefoneFixo = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    ConvenioID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CarteirinhaDoConvenio = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ValidadeDaCarteirinha = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.ID);
                    table.CheckConstraint("CK_UmTelefoneInformado", "([Celular] IS NULL AND [TelefoneFixo] IS NOT NULL OR [Celular] IS NOT NULL AND [TelefoneFixo] IS NULL OR [Celular] IS NOT NULL AND [TelefoneFixo] IS NOT NULL)");
                    table.ForeignKey(
                        name: "FK_Pacientes_Convenios_ConvenioID",
                        column: x => x.ConvenioID,
                        principalTable: "Convenios",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_ConvenioID",
                table: "Pacientes",
                column: "ConvenioID");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_CPF",
                table: "Pacientes",
                column: "CPF",
                unique: true,
                filter: "[CPF] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Convenios");
        }
    }
}
