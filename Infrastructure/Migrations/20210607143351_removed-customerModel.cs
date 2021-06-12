using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class removedcustomerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseProfiles_BaseProfiles_CustomerId",
                table: "BaseProfiles");

            migrationBuilder.DropIndex(
                name: "IX_BaseProfiles_CustomerId",
                table: "BaseProfiles");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "BaseProfiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "BaseProfiles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseProfiles_CustomerId",
                table: "BaseProfiles",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseProfiles_BaseProfiles_CustomerId",
                table: "BaseProfiles",
                column: "CustomerId",
                principalTable: "BaseProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
