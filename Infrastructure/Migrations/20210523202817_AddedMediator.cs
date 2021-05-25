using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddedMediator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Charge",
                table: "TransactionTypes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: new Guid("18a36c90-82c0-40be-91f2-e6da29765b8c"),
                column: "Charge",
                value: 50m);

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: new Guid("713243a4-65e6-4ec1-a21b-967323e59612"),
                column: "Charge",
                value: 10m);

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: new Guid("d2e757b1-aa06-4c53-b99c-a487c89608d5"),
                columns: new[] { "Charge", "Description" },
                values: new object[] { 100m, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Charge",
                table: "TransactionTypes");

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: new Guid("d2e757b1-aa06-4c53-b99c-a487c89608d5"),
                column: "Description",
                value: 0);
        }
    }
}
