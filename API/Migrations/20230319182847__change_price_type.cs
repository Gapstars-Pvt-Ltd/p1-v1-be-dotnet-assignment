using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class _change_price_type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price_Currency",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Price_Value",
                table: "OrderItems");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "OrderItems",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "OrderItems");

            migrationBuilder.AddColumn<int>(
                name: "Price_Currency",
                table: "OrderItems",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price_Value",
                table: "OrderItems",
                type: "numeric",
                nullable: true);
        }
    }
}
