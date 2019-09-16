using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagementSystem.Migrations
{
    public partial class addingdeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "delete",
                table: "ServiceTable",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "delete",
                table: "RoomTable",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "delete",
                table: "ReserveTable",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "delete",
                table: "GuestTable",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "delete",
                table: "EmployeeTable",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "delete",
                table: "ServiceTable");

            migrationBuilder.DropColumn(
                name: "delete",
                table: "RoomTable");

            migrationBuilder.DropColumn(
                name: "delete",
                table: "ReserveTable");

            migrationBuilder.DropColumn(
                name: "delete",
                table: "GuestTable");

            migrationBuilder.DropColumn(
                name: "delete",
                table: "EmployeeTable");
        }
    }
}
