using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopSuphan.Migrations
{
    /// <inheritdoc />
    public partial class New01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommunityGroupID",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CommunityGroup",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommunityGroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubDistrict = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityGroup", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CommunityGroupID",
                table: "Product",
                column: "CommunityGroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_CommunityGroup_CommunityGroupID",
                table: "Product",
                column: "CommunityGroupID",
                principalTable: "CommunityGroup",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_CommunityGroup_CommunityGroupID",
                table: "Product");

            migrationBuilder.DropTable(
                name: "CommunityGroup");

            migrationBuilder.DropIndex(
                name: "IX_Product_CommunityGroupID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CommunityGroupID",
                table: "Product");
        }
    }
}
