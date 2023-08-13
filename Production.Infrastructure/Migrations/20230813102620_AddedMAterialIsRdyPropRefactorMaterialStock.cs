using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Production.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedMAterialIsRdyPropRefactorMaterialStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Stock_MaterialScheduledInStock",
                table: "Materials",
                newName: "Stock_PlannedMaterialDemand");

            migrationBuilder.RenameColumn(
                name: "Stock_MaterialLeft",
                table: "Materials",
                newName: "Stock_MaterialToOrder");

            migrationBuilder.AddColumn<bool>(
                name: "MaterialIsRdy",
                table: "Productions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialIsRdy",
                table: "Productions");

            migrationBuilder.RenameColumn(
                name: "Stock_PlannedMaterialDemand",
                table: "Materials",
                newName: "Stock_MaterialScheduledInStock");

            migrationBuilder.RenameColumn(
                name: "Stock_MaterialToOrder",
                table: "Materials",
                newName: "Stock_MaterialLeft");
        }
    }
}
