using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class OrderEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_DestinationAirportId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_OriginAirportId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_DestinationAirportId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_OriginAirportId",
                table: "Flights");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FlightId = table.Column<Guid>(type: "uuid", nullable: false),
                    FlightRateId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    SeatCount = table.Column<int>(type: "integer", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_DestinationAirportId",
                table: "Flights",
                column: "DestinationAirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_OriginAirportId",
                table: "Flights",
                column: "OriginAirportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airports_DestinationAirportId",
                table: "Flights",
                column: "DestinationAirportId",
                principalTable: "Airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airports_OriginAirportId",
                table: "Flights",
                column: "OriginAirportId",
                principalTable: "Airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
