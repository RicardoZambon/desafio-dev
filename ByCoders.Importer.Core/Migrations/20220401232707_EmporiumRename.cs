using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByCoders.Importer.Core.Migrations
{
    public partial class EmporiumRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmporiumOwner",
                table: "Transactions",
                newName: "ShopOwner");

            migrationBuilder.RenameColumn(
                name: "EmporiumName",
                table: "Transactions",
                newName: "ShopName");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "PasswordHash",
                value: "n5k1zxaYniGEmfLn0YREEZiugK5ikRhvcTjkcahi81YiJZ9quoUN+k4XN7QT8QSf");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShopOwner",
                table: "Transactions",
                newName: "EmporiumOwner");

            migrationBuilder.RenameColumn(
                name: "ShopName",
                table: "Transactions",
                newName: "EmporiumName");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "PasswordHash",
                value: "MqLSnQFdlCO+hdmysNBtyYWcd7p5RiH6BMU5+pqcDHGsUdG2OG7hO+JtcXW49/AU");
        }
    }
}
