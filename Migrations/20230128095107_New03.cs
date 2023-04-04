using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopSuphan.Migrations
{
    /// <inheritdoc />
    public partial class New03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LevelRarityID",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LevelRarity",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevelRarityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelRarity", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_LevelRarityID",
                table: "Product",
                column: "LevelRarityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_LevelRarity_LevelRarityID",
                table: "Product",
                column: "LevelRarityID",
                principalTable: "LevelRarity",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_LevelRarity_LevelRarityID",
                table: "Product");

            migrationBuilder.DropTable(
                name: "LevelRarity");

            migrationBuilder.DropIndex(
                name: "IX_Product_LevelRarityID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "LevelRarityID",
                table: "Product");
        }
    }
}
