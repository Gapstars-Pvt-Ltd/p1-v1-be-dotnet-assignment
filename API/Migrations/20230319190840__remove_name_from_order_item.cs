using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class _remove_name_from_order_item : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "OrderItems");

            migrationBuilder.AddColumn<Guid>(
                name: "FlightRateId",
                table: "OrderItems",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlightRateId",
                table: "OrderItems");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OrderItems",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
