using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelEasy.EV.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddedBookinTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBooked",
                table: "ElectricVehicles");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ElectricVehicles",
                newName: "CarId");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "ElectricVehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "ElectricVehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    UsertId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "ElectricVehicles");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "ElectricVehicles");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "ElectricVehicles",
                newName: "Id");

            migrationBuilder.AddColumn<bool>(
                name: "IsBooked",
                table: "ElectricVehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
