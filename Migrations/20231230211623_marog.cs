using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdealHoliday.Migrations
{
    public partial class marog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Holiday",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Holiday_CustomerId",
                table: "Holiday",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Holiday_Customer_CustomerId",
                table: "Holiday",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Holiday_Customer_CustomerId",
                table: "Holiday");

            migrationBuilder.DropIndex(
                name: "IX_Holiday_CustomerId",
                table: "Holiday");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Holiday");
        }
    }
}
