using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Production.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MoldReferenceToMaterial : Migration
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

            migrationBuilder.DropColumn(
                name: "InjectionMoldId",
                table: "Materials");

            migrationBuilder.AddColumn<decimal>(
                name: "Consumption",
                table: "InjectionMolds",
                type: "decimal(4,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "InjectionMolds",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InjectionMolds_MaterialId",
                table: "InjectionMolds",
                column: "MaterialId",
                unique: true,
                filter: "[MaterialId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_InjectionMolds_Materials_MaterialId",
                table: "InjectionMolds",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InjectionMolds_Materials_MaterialId",
                table: "InjectionMolds");

            migrationBuilder.DropIndex(
                name: "IX_InjectionMolds_MaterialId",
                table: "InjectionMolds");

            migrationBuilder.DropColumn(
                name: "Consumption",
                table: "InjectionMolds");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "InjectionMolds");

            migrationBuilder.AddColumn<Guid>(
                name: "InjectionMoldId",
                table: "Materials",
                type: "uniqueidentifier",
                nullable: true);

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
    }
}
