using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagementSystem.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartmentTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PhoneNo = table.Column<string>(nullable: false),
                    GenderId = table.Column<int>(nullable: false),
                    Salary = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenderTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Gender = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GuestTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    GenderId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    City = table.Column<string>(maxLength: 30, nullable: false),
                    Country = table.Column<string>(maxLength: 30, nullable: false),
                    NICno = table.Column<string>(nullable: false),
                    PhoneNo = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReserveTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GuestId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    ReservationCode = table.Column<int>(nullable: false),
                    CheckIn = table.Column<DateTime>(nullable: false),
                    CheckOut = table.Column<DateTime>(nullable: false),
                    NoOfNights = table.Column<int>(nullable: false),
                    Adults = table.Column<int>(nullable: false),
                    Children = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReserveTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoomName = table.Column<string>(maxLength: 30, nullable: false),
                    BuildingNo = table.Column<int>(nullable: false),
                    StatusId = table.Column<bool>(nullable: false),
                    RoomTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypeTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    StandardPrice = table.Column<float>(nullable: false),
                    SinglePrice = table.Column<float>(nullable: false),
                    Adults = table.Column<int>(nullable: false),
                    Children = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypeTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCatagoryTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCatagoryTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<float>(nullable: false),
                    ServiceCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTable", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentTable");

            migrationBuilder.DropTable(
                name: "EmployeeTable");

            migrationBuilder.DropTable(
                name: "GenderTable");

            migrationBuilder.DropTable(
                name: "GuestTable");

            migrationBuilder.DropTable(
                name: "ReserveTable");

            migrationBuilder.DropTable(
                name: "RoomTable");

            migrationBuilder.DropTable(
                name: "RoomTypeTable");

            migrationBuilder.DropTable(
                name: "ServiceCatagoryTable");

            migrationBuilder.DropTable(
                name: "ServiceTable");
        }
    }
}
