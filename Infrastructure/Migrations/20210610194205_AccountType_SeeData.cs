using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AccountType_SeeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "NewRecord",
                table: "AccountType",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "AccountType",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "AccountType",
                columns: new[] { "Id", "AccountCode", "AccountTypeDescription", "Code", "InterestRateId", "Name", "Title" },
                values: new object[] { new Guid("c7807bd9-9621-4336-8219-8120833ce1f4"), "XB214", 1, null, 10m, null, "Premuim Savings" });

            migrationBuilder.InsertData(
                table: "AccountType",
                columns: new[] { "Id", "AccountCode", "AccountTypeDescription", "Code", "InterestRateId", "Name", "Title" },
                values: new object[] { new Guid("1680ca16-54dc-465e-b057-6b690ca040e3"), "OD204", 0, null, 5m, null, "Classic Savings" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountType",
                keyColumn: "Id",
                keyValue: new Guid("1680ca16-54dc-465e-b057-6b690ca040e3"));

            migrationBuilder.DeleteData(
                table: "AccountType",
                keyColumn: "Id",
                keyValue: new Guid("c7807bd9-9621-4336-8219-8120833ce1f4"));

            migrationBuilder.AlterColumn<bool>(
                name: "NewRecord",
                table: "AccountType",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "AccountType",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);
        }
    }
}
