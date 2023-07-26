using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelEasy.EV.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class update_db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
              name: "Id",
              table: "Booking");

            migrationBuilder.AddColumn<string>(
              name: "Id",
              table: "Booking",
              type: "int",
              nullable: false,
              defaultValue: "").Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Booking",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
