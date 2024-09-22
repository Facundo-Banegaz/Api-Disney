using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Disney.Migrations
{
    /// <inheritdoc />
    public partial class user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "SegundoNombre",
                table: "Users",
                newName: "Rol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rol",
                table: "Users",
                newName: "SegundoNombre");

            migrationBuilder.AddColumn<string>(
                name: "Imagen",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
