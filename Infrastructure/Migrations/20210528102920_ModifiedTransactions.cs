using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ModifiedTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseProfiles_AccountType_AccountTypeId",
                table: "BaseProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseProfiles_BaseProfiles_Accountd",
                table: "BaseProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseProfiles_BaseProfiles_CustomerId",
                table: "BaseProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_BaseProfiles_AccountId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_BaseProfiles_AccountTypeId",
                table: "BaseProfiles");

            migrationBuilder.DropIndex(
                name: "IX_BaseProfiles_CustomerId",
                table: "BaseProfiles");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "BaseProfiles");

            migrationBuilder.DropColumn(
                name: "AccountTypeId",
                table: "BaseProfiles");

            migrationBuilder.DropColumn(
                name: "CurrentAccountBalance",
                table: "BaseProfiles");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "BaseProfiles");

            migrationBuilder.DropColumn(
                name: "PINHash",
                table: "BaseProfiles");

            migrationBuilder.DropColumn(
                name: "PINSalt",
                table: "BaseProfiles");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Transactions",
                newName: "StatusMessage");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Transactions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceAccountNumber",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CurrentAccountBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccountTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PINHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PINSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    NewRecord = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountType_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalTable: "AccountType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounts_BaseProfiles_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "BaseProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountTypeId",
                table: "Accounts",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CustomerId",
                table: "Accounts",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseProfiles_Accounts_Accountd",
                table: "BaseProfiles",
                column: "Accountd",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseProfiles_Accounts_Accountd",
                table: "BaseProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "SourceAccountNumber",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "StatusMessage",
                table: "Transactions",
                newName: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "BaseProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AccountTypeId",
                table: "BaseProfiles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentAccountBalance",
                table: "BaseProfiles",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "BaseProfiles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PINHash",
                table: "BaseProfiles",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PINSalt",
                table: "BaseProfiles",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseProfiles_AccountTypeId",
                table: "BaseProfiles",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseProfiles_CustomerId",
                table: "BaseProfiles",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseProfiles_AccountType_AccountTypeId",
                table: "BaseProfiles",
                column: "AccountTypeId",
                principalTable: "AccountType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseProfiles_BaseProfiles_Accountd",
                table: "BaseProfiles",
                column: "Accountd",
                principalTable: "BaseProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseProfiles_BaseProfiles_CustomerId",
                table: "BaseProfiles",
                column: "CustomerId",
                principalTable: "BaseProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_BaseProfiles_AccountId",
                table: "Transactions",
                column: "AccountId",
                principalTable: "BaseProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
