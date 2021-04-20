using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.API.Migrations
{
    public partial class Liquors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    IdCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCategory = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ImageCategory = table.Column<byte[]>(type: "image", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.IdCategory);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    ProveedorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameProveedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactProveedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneProveedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressProveedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.ProveedorId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    CiUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PictureUser = table.Column<byte[]>(type: "image", nullable: false),
                    DisplaynameUser = table.Column<string>(type: "nvarchar(38)", maxLength: 38, nullable: false),
                    EmailUser = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PasswordUser = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneUser = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AddessUser = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateBirthUser = table.Column<DateTime>(type: "date", maxLength: 10, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.CiUser);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    CiClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CiUser = table.Column<int>(type: "int", nullable: false),
                    PictureClient = table.Column<byte[]>(type: "image", nullable: false),
                    DisplayNameClient = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EmailClient = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PasswordClient = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneClient = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AddessClient = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateBirthClient = table.Column<DateTime>(type: "date", maxLength: 10, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.CiClient);
                    table.ForeignKey(
                        name: "FK_Clients_Users_CiUser",
                        column: x => x.CiUser,
                        principalTable: "Users",
                        principalColumn: "CiUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryIdCategory = table.Column<int>(type: "int", nullable: true),
                    ProveedorId = table.Column<int>(type: "int", nullable: false),
                    CiUser = table.Column<int>(type: "int", nullable: false),
                    StateProduct = table.Column<int>(type: "int", nullable: false),
                    IdCategory = table.Column<int>(type: "int", nullable: false),
                    NameProduct = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ImageProduct = table.Column<byte[]>(type: "image", nullable: false),
                    PriceProduct = table.Column<double>(type: "float", nullable: false),
                    StockProduct = table.Column<int>(type: "int", nullable: false),
                    DetailProduct = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SalesProduct = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryIdCategory",
                        column: x => x.CategoryIdCategory,
                        principalTable: "Categories",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Users_CiUser",
                        column: x => x.CiUser,
                        principalTable: "Users",
                        principalColumn: "CiUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductProveedor",
                columns: table => new
                {
                    ProductsProductId = table.Column<int>(type: "int", nullable: false),
                    ProveedoresProveedorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProveedor", x => new { x.ProductsProductId, x.ProveedoresProveedorId });
                    table.ForeignKey(
                        name: "FK_ProductProveedor_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProveedor_Proveedores_ProveedoresProveedorId",
                        column: x => x.ProveedoresProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "ProveedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    IdOrder = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleIdSales = table.Column<int>(type: "int", nullable: true),
                    CiClient = table.Column<int>(type: "int", nullable: false),
                    IdProduct = table.Column<int>(type: "int", nullable: false),
                    DeliveryPrice = table.Column<double>(type: "float", nullable: false),
                    PriceOrder = table.Column<double>(type: "float", nullable: false),
                    AddressOrder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusOrder = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.IdOrder);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_CiClient",
                        column: x => x.CiClient,
                        principalTable: "Clients",
                        principalColumn: "CiClient",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrdersIdOrder = table.Column<int>(type: "int", nullable: false),
                    ProductsProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.OrdersIdOrder, x.ProductsProductId });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Orders_OrdersIdOrder",
                        column: x => x.OrdersIdOrder,
                        principalTable: "Orders",
                        principalColumn: "IdOrder",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    IdSales = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CiClient = table.Column<int>(type: "int", nullable: false),
                    IdOrder = table.Column<int>(type: "int", nullable: false),
                    PriceSale = table.Column<double>(type: "float", nullable: false),
                    PriceDelivery = table.Column<double>(type: "float", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IdPaymentSale = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.IdSales);
                    table.ForeignKey(
                        name: "FK_Sales_Clients_CiClient",
                        column: x => x.CiClient,
                        principalTable: "Clients",
                        principalColumn: "CiClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Orders_IdOrder",
                        column: x => x.IdOrder,
                        principalTable: "Orders",
                        principalColumn: "IdOrder",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CiUser",
                table: "Clients",
                column: "CiUser");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductsProductId",
                table: "OrderProduct",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CiClient",
                table: "Orders",
                column: "CiClient");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SaleIdSales",
                table: "Orders",
                column: "SaleIdSales");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProveedor_ProveedoresProveedorId",
                table: "ProductProveedor",
                column: "ProveedoresProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryIdCategory",
                table: "Products",
                column: "CategoryIdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CiUser",
                table: "Products",
                column: "CiUser");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CiClient",
                table: "Sales",
                column: "CiClient");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_IdOrder",
                table: "Sales",
                column: "IdOrder");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Sales_SaleIdSales",
                table: "Orders",
                column: "SaleIdSales",
                principalTable: "Sales",
                principalColumn: "IdSales",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_CiUser",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Orders_IdOrder",
                table: "Sales");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "ProductProveedor");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
