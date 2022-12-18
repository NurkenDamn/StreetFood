using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreetFood.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderTableProperties1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Dishes_DishId",
                table: "Contents");

            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Ingredients_IngredientId",
                table: "Contents");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Dishes_DishId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_StockProducts_Ingredients_IngredientId",
                table: "StockProducts");

            migrationBuilder.DropIndex(
                name: "IX_StockProducts_IngredientId",
                table: "StockProducts");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DishId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Contents_DishId",
                table: "Contents");

            migrationBuilder.DropIndex(
                name: "IX_Contents_IngredientId",
                table: "Contents");

            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BIN = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PricePerItem = table.Column<int>(type: "int", nullable: false),
                    PurveyorId = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_Partners_PurveyorId",
                        column: x => x.PurveyorId,
                        principalTable: "Partners",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_PurveyorId",
                table: "Purchases",
                column: "PurveyorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.CreateIndex(
                name: "IX_StockProducts_IngredientId",
                table: "StockProducts",
                column: "IngredientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DishId",
                table: "Orders",
                column: "DishId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contents_DishId",
                table: "Contents",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_IngredientId",
                table: "Contents",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Dishes_DishId",
                table: "Contents",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Ingredients_IngredientId",
                table: "Contents",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Dishes_DishId",
                table: "Orders",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockProducts_Ingredients_IngredientId",
                table: "StockProducts",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
