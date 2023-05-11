using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopSuphan.Migrations
{
    /// <inheritdoc />
    public partial class newbiena : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressInformation",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubDistrict = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressInformation", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CommunityGroup",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommunityGroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubDistrict = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TextHistory = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityGroup", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Informations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nameinformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Detaiinformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informations", x => x.ID);
                });

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

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StatusAddress",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusAddress", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryProductID = table.Column<int>(type: "int", nullable: false),
                    CommunityGroupID = table.Column<int>(type: "int", nullable: false),
                    LevelRarityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Product_CategoryProduct_CategoryProductID",
                        column: x => x.CategoryProductID,
                        principalTable: "CategoryProduct",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_CommunityGroup_CommunityGroupID",
                        column: x => x.CommunityGroupID,
                        principalTable: "CommunityGroup",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_LevelRarity_LevelRarityID",
                        column: x => x.LevelRarityID,
                        principalTable: "LevelRarity",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tell = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Account_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDescription",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDescription", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductDescription_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountPassword",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountPassword", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AccountPassword_Account_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Account",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    StatusAddressID = table.Column<int>(type: "int", nullable: false),
                    AddressInformationID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Address_Account_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Account",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address_AddressInformation_AddressInformationID",
                        column: x => x.AddressInformationID,
                        principalTable: "AddressInformation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address_StatusAddress_StatusAddressID",
                        column: x => x.StatusAddressID,
                        principalTable: "StatusAddress",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    AmountProduct = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cart_Account_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Account",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cart_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reviews_Account_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Account",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderAccount",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    ProofOfPayment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PriceTotal = table.Column<int>(type: "int", nullable: false),
                    DeliveryFee = table.Column<int>(type: "int", nullable: false),
                    AccountStatus = table.Column<bool>(type: "bit", nullable: false),
                    AddressID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderAccount", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderAccount_Address_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Address",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewImages",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewImages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReviewImages_Reviews_ReviewID",
                        column: x => x.ReviewID,
                        principalTable: "Reviews",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderAccountID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ProductPrice = table.Column<int>(type: "int", nullable: false),
                    ProductAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderItem_OrderAccount_OrderAccountID",
                        column: x => x.OrderAccountID,
                        principalTable: "OrderAccount",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CategoryProduct",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 2, "category-01" },
                    { 3, "category-02" },
                    { 999, "rare" }
                });

            migrationBuilder.InsertData(
                table: "CommunityGroup",
                columns: new[] { "ID", "CommunityGroupName", "District", "SubDistrict", "TextHistory" },
                values: new object[,]
                {
                    { 1, "เอกชัย", "เมือง", "ท่าระหัด", null },
                    { 2, "ตลาดอู่ทอง", "อู่ทอง", "อู่ทอง", null }
                });

            migrationBuilder.InsertData(
                table: "LevelRarity",
                columns: new[] { "ID", "Date", "LevelRarityName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 9, 16, 56, 20, 644, DateTimeKind.Local).AddTicks(6764), "หาได้ทั่วไป" },
                    { 2, new DateTime(2023, 5, 9, 16, 56, 20, 644, DateTimeKind.Local).AddTicks(6767), "ปานกลาง" },
                    { 3, new DateTime(2023, 5, 9, 16, 56, 20, 644, DateTimeKind.Local).AddTicks(6768), "หายาก" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "User" },
                    { 2, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "StatusAddress",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "เป็นได้เเค่พี่น้อง" },
                    { 2, "เป็นได้เเค่เพื่อน" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_RoleID",
                table: "Account",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountPassword_AccountID",
                table: "AccountPassword",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Address_AccountID",
                table: "Address",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Address_AddressInformationID",
                table: "Address",
                column: "AddressInformationID");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StatusAddressID",
                table: "Address",
                column: "StatusAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_AccountID",
                table: "Cart",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ProductID",
                table: "Cart",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAccount_AddressID",
                table: "OrderAccount",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderAccountID",
                table: "OrderItem",
                column: "OrderAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductID",
                table: "OrderItem",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryProductID",
                table: "Product",
                column: "CategoryProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CommunityGroupID",
                table: "Product",
                column: "CommunityGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_LevelRarityID",
                table: "Product",
                column: "LevelRarityID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDescription_ProductID",
                table: "ProductDescription",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewImages_ReviewID",
                table: "ReviewImages",
                column: "ReviewID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AccountID",
                table: "Reviews",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductID",
                table: "Reviews",
                column: "ProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountPassword");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Informations");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "ProductDescription");

            migrationBuilder.DropTable(
                name: "ReviewImages");

            migrationBuilder.DropTable(
                name: "OrderAccount");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "AddressInformation");

            migrationBuilder.DropTable(
                name: "StatusAddress");

            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "CommunityGroup");

            migrationBuilder.DropTable(
                name: "LevelRarity");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
