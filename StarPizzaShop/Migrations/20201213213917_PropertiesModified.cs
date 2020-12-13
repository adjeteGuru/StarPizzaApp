using Microsoft.EntityFrameworkCore.Migrations;

namespace StarPizzaShop.Migrations
{
    public partial class PropertiesModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_PackIncs_PackIncId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderMenus_Drinks_DrinkId",
                table: "OrderMenus");

            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "PackIncs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderMenus",
                table: "OrderMenus");

            migrationBuilder.DropIndex(
                name: "IX_OrderMenus_DrinkId",
                table: "OrderMenus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_PackIncId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "DrinkId",
                table: "OrderMenus");

            migrationBuilder.DropColumn(
                name: "PackIncId",
                table: "Menus");

            migrationBuilder.AddColumn<float>(
                name: "DeliveryCharge",
                table: "Orders",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OrderMenus",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "OrderMenus",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Menus",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Menus",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Menus",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Whereabouts",
                table: "Customers",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderMenus",
                table: "OrderMenus",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderMenus_OrderId",
                table: "OrderMenus",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_CategoryId",
                table: "Menus",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Categories_CategoryId",
                table: "Menus",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Categories_CategoryId",
                table: "Menus");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderMenus",
                table: "OrderMenus");

            migrationBuilder.DropIndex(
                name: "IX_OrderMenus_OrderId",
                table: "OrderMenus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_CategoryId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "DeliveryCharge",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrderMenus");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderMenus");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "Whereabouts",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "DrinkId",
                table: "OrderMenus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PackIncId",
                table: "Menus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderMenus",
                table: "OrderMenus",
                columns: new[] { "OrderId", "MenuId", "DrinkId" });

            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackIncs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackIncs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderMenus_DrinkId",
                table: "OrderMenus",
                column: "DrinkId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_PackIncId",
                table: "Menus",
                column: "PackIncId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_PackIncs_PackIncId",
                table: "Menus",
                column: "PackIncId",
                principalTable: "PackIncs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMenus_Drinks_DrinkId",
                table: "OrderMenus",
                column: "DrinkId",
                principalTable: "Drinks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
