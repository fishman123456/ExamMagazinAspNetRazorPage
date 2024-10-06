using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamMagazinAspNetRazorPage.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders_t",
                columns: table => new
                {
                    IdOrder_f = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    СodeOrder_f = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientOrder_f = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders_t", x => x.IdOrder_f);
                });

            migrationBuilder.CreateTable(
                name: "Products_t",
                columns: table => new
                {
                    IdProduct_f = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberProduct_f = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameProduct_f = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityProduct_f = table.Column<int>(type: "int", nullable: false),
                    PriceUnitProduct_f = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_t", x => x.IdProduct_f);
                });

            migrationBuilder.CreateTable(
                name: "Clients_t",
                columns: table => new
                {
                    IdClient_f = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName_f = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientLast_f = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientEmail_f = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients_t", x => x.IdClient_f);
                    table.ForeignKey(
                        name: "FK_Clients_t_Orders_t_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders_t",
                        principalColumn: "IdOrder_f");
                });

            migrationBuilder.CreateTable(
                name: "ShopingCarts_t",
                columns: table => new
                {
                    IdOrderProduct_f = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuantityOrderProduct_f = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopingCarts_t", x => x.IdOrderProduct_f);
                    table.ForeignKey(
                        name: "FK_ShopingCarts_t_Orders_t_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders_t",
                        principalColumn: "IdOrder_f");
                    table.ForeignKey(
                        name: "FK_ShopingCarts_t_Products_t_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products_t",
                        principalColumn: "IdProduct_f");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_t_ClientEmail_f",
                table: "Clients_t",
                column: "ClientEmail_f",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_t_OrderId",
                table: "Clients_t",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_t_СodeOrder_f",
                table: "Orders_t",
                column: "СodeOrder_f",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShopingCarts_t_OrderId",
                table: "ShopingCarts_t",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopingCarts_t_ProductId",
                table: "ShopingCarts_t",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients_t");

            migrationBuilder.DropTable(
                name: "ShopingCarts_t");

            migrationBuilder.DropTable(
                name: "Orders_t");

            migrationBuilder.DropTable(
                name: "Products_t");
        }
    }
}
