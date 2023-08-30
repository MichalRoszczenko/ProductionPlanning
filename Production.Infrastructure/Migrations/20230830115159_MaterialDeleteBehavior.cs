using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Production.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MaterialDeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InjectionMolds_Materials_MaterialId",
                table: "InjectionMolds");

            migrationBuilder.AddForeignKey(
                name: "FK_InjectionMolds_Materials_MaterialId",
                table: "InjectionMolds",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InjectionMolds_Materials_MaterialId",
                table: "InjectionMolds");

            migrationBuilder.AddForeignKey(
                name: "FK_InjectionMolds_Materials_MaterialId",
                table: "InjectionMolds",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id");
        }
    }
}
