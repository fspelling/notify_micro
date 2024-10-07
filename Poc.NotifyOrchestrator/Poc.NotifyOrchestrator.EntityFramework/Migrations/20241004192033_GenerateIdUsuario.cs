using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Poc.NotifyOrchestrator.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class GenerateIdUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "Usuario",
                type: "nvarchar(450)",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "Usuario",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValueSql: "newsequentialid()");
        }
    }
}
