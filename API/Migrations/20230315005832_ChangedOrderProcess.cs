using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class ChangedOrderProcess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Orders_OrderId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Passenger_PassengerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Passenger_Orders_OrderId",
                table: "Passenger");

            migrationBuilder.DropIndex(
                name: "IX_Passenger_OrderId",
                table: "Passenger");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PassengerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Flights_OrderId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Passenger");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Passenger");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Passenger");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Passenger");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Passenger");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Passenger");

            migrationBuilder.DropColumn(
                name: "ClassName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FlightId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "NoOfSeats",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PassengerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Flights");

            migrationBuilder.AddColumn<Guid>(
                name: "PassengerId",
                table: "Passenger",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Orders",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Orders",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Orders",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrderItemId = table.Column<Guid>(nullable: false),
                    FlightId = table.Column<Guid>(nullable: false),
                    NoOfSeats = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Passenger_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Passenger",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Passenger_CustomerId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PassengerId",
                table: "Passenger");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Passenger",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Passenger",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Passenger",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Passenger",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Passenger",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Passenger",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClassName",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FlightId",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "NoOfSeats",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "PassengerId",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Flights",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Passenger_OrderId",
                table: "Passenger",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PassengerId",
                table: "Orders",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_OrderId",
                table: "Flights",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Orders_OrderId",
                table: "Flights",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Passenger_PassengerId",
                table: "Orders",
                column: "PassengerId",
                principalTable: "Passenger",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Passenger_Orders_OrderId",
                table: "Passenger",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
