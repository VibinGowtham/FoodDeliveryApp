using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDeliveryApp.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressLine1",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "AddressLine2",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "AddressLine3",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "DeliveryPrice",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "RestaurantName",
                table: "Restaurants");

            migrationBuilder.RenameColumn(
                name: "UserIdRef",
                table: "Restaurants",
                newName: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_UserId",
                table: "Restaurants",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Users_UserId",
                table: "Restaurants",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Users_UserId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_UserId",
                table: "Restaurants");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Restaurants",
                newName: "UserIdRef");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                table: "Restaurants",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine2",
                table: "Restaurants",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine3",
                table: "Restaurants",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryPrice",
                table: "Restaurants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RestaurantName",
                table: "Restaurants",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
