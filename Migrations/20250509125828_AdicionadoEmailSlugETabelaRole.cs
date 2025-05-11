using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyOrca.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoEmailSlugETabelaRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_USUARIO_Username",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Usuario");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Usuario",
                type: "varchar(160)",
                maxLength: 160,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Usuario",
                type: "VARCHAR(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Transacao",
                type: "decimal(14,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Saldo",
                table: "ContaFinanceira",
                type: "decimal(14,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldDefaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioRole",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRole", x => new { x.RoleId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_UsuarioRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioRole_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_Username",
                table: "Usuario",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRole_UsuarioId",
                table: "UsuarioRole",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioRole");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_USUARIO_Username",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Usuario");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Usuario",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Transacao",
                type: "decimal(18,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(14,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Saldo",
                table: "ContaFinanceira",
                type: "decimal(18,0)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(14,2)",
                oldDefaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_Username",
                table: "Usuario",
                column: "Username",
                unique: true);
        }
    }
}
