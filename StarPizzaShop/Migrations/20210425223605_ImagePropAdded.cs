using Microsoft.EntityFrameworkCore.Migrations;

namespace StarPizzaShop.Migrations
{
    public partial class ImagePropAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgPathUrl",
                table: "Menus",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgPathUrl",
                table: "Menus");
        }
    }
}
