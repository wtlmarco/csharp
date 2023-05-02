using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aula08_Database.Migrations
{
    /// <inheritdoc />
    public partial class Versao9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Usuario",
                type: "TEXT",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoEntrega_Referencia",
                table: "Pedido",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoEntrega_Numero",
                table: "Pedido",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoEntrega_Logradouro",
                table: "Pedido",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoEntrega_Estado",
                table: "Pedido",
                type: "char(2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(2)");

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoEntrega_Complemento",
                table: "Pedido",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoEntrega_Cidade",
                table: "Pedido",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoEntrega_CEP",
                table: "Pedido",
                type: "char(9)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(9)");

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoEntrega_Bairro",
                table: "Pedido",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Usuario",
                type: "TEXT",
                maxLength: 128,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoEntrega_Referencia",
                table: "Pedido",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoEntrega_Numero",
                table: "Pedido",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoEntrega_Logradouro",
                table: "Pedido",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoEntrega_Estado",
                table: "Pedido",
                type: "char(2)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoEntrega_Complemento",
                table: "Pedido",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoEntrega_Cidade",
                table: "Pedido",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoEntrega_CEP",
                table: "Pedido",
                type: "char(9)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(9)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EnderecoEntrega_Bairro",
                table: "Pedido",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
