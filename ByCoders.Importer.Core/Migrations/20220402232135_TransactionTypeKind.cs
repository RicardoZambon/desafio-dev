using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByCoders.Importer.Core.Migrations
{
    public partial class TransactionTypeKind : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Kind",
                table: "TransactionTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "ID",
                keyValue: 2,
                column: "Kind",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "ID",
                keyValue: 3,
                column: "Kind",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "ID",
                keyValue: 9,
                column: "Kind",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "PasswordHash",
                value: "nvqe6Ku4Te4EwukbPWq3VSVeAIKD5E88cZ8QVUMCGseQi5LBIZNqNPUWQuir6QQF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kind",
                table: "TransactionTypes");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "PasswordHash",
                value: "n5k1zxaYniGEmfLn0YREEZiugK5ikRhvcTjkcahi81YiJZ9quoUN+k4XN7QT8QSf");
        }
    }
}
