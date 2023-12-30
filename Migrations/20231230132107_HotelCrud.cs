using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdealHoliday.Migrations
{
    public partial class HotelCrud : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Holiday",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfStars = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Holiday_HotelId",
                table: "Holiday",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Holiday_Hotel_HotelId",
                table: "Holiday",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Holiday_Hotel_HotelId",
                table: "Holiday");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropIndex(
                name: "IX_Holiday_HotelId",
                table: "Holiday");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Holiday");
        }
    }
}
