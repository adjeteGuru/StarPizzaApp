using Microsoft.EntityFrameworkCore.Migrations;

namespace StarPizzaShop.Migrations
{
    public partial class PropertiesKeysAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackIncs_Menus_MenuId",
                table: "PackIncs");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropIndex(
                name: "IX_PackIncs_MenuId",
                table: "PackIncs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderMenus",
                table: "OrderMenus");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "PackIncs");

            migrationBuilder.AddColumn<int>(
                name: "PackIncId",
                table: "Menus",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BuildingDetails",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Customers",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "County",
                table: "Customers",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HouseNo",
                table: "Customers",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Postcode",
                table: "Customers",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Customers",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tel",
                table: "Customers",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderMenus",
                table: "OrderMenus",
                columns: new[] { "OrderId", "MenuId", "DrinkId" });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_PackIncs_PackIncId",
                table: "Menus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderMenus",
                table: "OrderMenus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_PackIncId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "PackIncId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "BuildingDetails",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "County",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "HouseNo",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Postcode",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Tel",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "PackIncs",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderMenus",
                table: "OrderMenus",
                columns: new[] { "OrderId", "MenuId" });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    County = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    HouseNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Postcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackIncs_MenuId",
                table: "PackIncs",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_CustomerId",
                table: "PhoneNumbers",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PackIncs_Menus_MenuId",
                table: "PackIncs",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
