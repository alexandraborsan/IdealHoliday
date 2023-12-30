using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdealHoliday.Migrations
{
    public partial class ReservationDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReturnDate",
                table: "Booking",
                newName: "ReservationDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReservationDate",
                table: "Booking",
                newName: "ReturnDate");
        }
    }
}
