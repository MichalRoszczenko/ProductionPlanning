using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Production.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MaterialStockAddedAndInjectionMoldNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_InjectionMolds_InjectionMoldId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_InjectionMoldId",
                table: "Materials");

            migrationBuilder.AlterColumn<Guid>(
                name: "InjectionMoldId",
                table: "Materials",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "Stock_MaterialInStock",
                table: "Materials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Stock_MaterialLeft",
                table: "Materials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Stock_MaterialOnProduction",
                table: "Materials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Stock_MaterialScheduledInStock",
                table: "Materials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_InjectionMoldId",
                table: "Materials",
                column: "InjectionMoldId",
                unique: true,
                filter: "[InjectionMoldId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_InjectionMolds_InjectionMoldId",
                table: "Materials",
                column: "InjectionMoldId",
                principalTable: "InjectionMolds",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_InjectionMolds_InjectionMoldId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_InjectionMoldId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "Stock_MaterialInStock",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "Stock_MaterialLeft",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "Stock_MaterialOnProduction",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "Stock_MaterialScheduledInStock",
                table: "Materials");

            migrationBuilder.AlterColumn<Guid>(
                name: "InjectionMoldId",
                table: "Materials",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_InjectionMoldId",
                table: "Materials",
                column: "InjectionMoldId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_InjectionMolds_InjectionMoldId",
                table: "Materials",
                column: "InjectionMoldId",
                principalTable: "InjectionMolds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
