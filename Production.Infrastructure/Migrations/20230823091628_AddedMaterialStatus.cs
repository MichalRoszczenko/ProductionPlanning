using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Production.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedMaterialStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaterialIsRdy",
                table: "Productions",
                newName: "MaterialStatus_MaterialIsAvailable");

            migrationBuilder.AddColumn<int>(
                name: "MaterialStatus_MaterialUsage",
                table: "Productions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialStatus_MaterialUsage",
                table: "Productions");

            migrationBuilder.RenameColumn(
                name: "MaterialStatus_MaterialIsAvailable",
                table: "Productions",
                newName: "MaterialIsRdy");
        }
    }
}
