using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class RemovalofBaseProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_BaseProfiles_CustomerId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_BaseProfiles_EmployeeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseProfiles_AccountType_AccountTypeId",
                table: "BaseProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseProfiles_BaseProfiles_Customer_EmployeeId",
                table: "BaseProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseProfiles_BaseProfiles_EmployeeId",
                table: "BaseProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_BaseProfiles_AccountId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountType",
                table: "AccountType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseProfiles",
                table: "BaseProfiles");

            migrationBuilder.DropIndex(
                name: "IX_BaseProfiles_AccountTypeId",
                table: "BaseProfiles");

            migrationBuilder.DropIndex(
                name: "IX_BaseProfiles_Customer_EmployeeId",
                table: "BaseProfiles");

            migrationBuilder.DropIndex(
                name: "IX_BaseProfiles_EmployeeId",
                table: "BaseProfiles");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "BaseProfiles");

            migrationBuilder.DropColumn(
                name: "AccountTypeId",
                table: "BaseProfiles");

            migrationBuilder.DropColumn(
                name: "BrokerCode",
                table: "BaseProfiles");

            migrationBuilder.DropColumn(
                name: "CurrentAccountBalance",
                table: "BaseProfiles");

            migrationBuilder.DropColumn(
                name: "Customer_BrokerCode",
                table: "BaseProfiles");

            migrationBuilder.DropColumn(
                name: "Customer_EmployeeId",
                table: "BaseProfiles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseProfiles");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "BaseProfiles");

            migrationBuilder.DropColumn(
                name: "PINHash",
                table: "BaseProfiles");

            migrationBuilder.DropColumn(
                name: "PINSalt",
                table: "BaseProfiles");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "BaseProfiles");

            migrationBuilder.RenameTable(
                name: "AccountType",
                newName: "AccountTypes");

            migrationBuilder.RenameTable(
                name: "BaseProfiles",
                newName: "Employees");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountTypes",
                table: "AccountTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BrokerCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BVN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentificationType = table.Column<int>(type: "int", nullable: true),
                    IdentificationNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountTypes_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalTable: "AccountTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BrokerCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    NewRecord = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BVN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentificationType = table.Column<int>(type: "int", nullable: true),
                    IdentificationNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountTypeId",
                table: "Accounts",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_EmployeeId",
                table: "Accounts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_EmployeeId",
                table: "Customer",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Customer_CustomerId",
                table: "AspNetUsers",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Employees_EmployeeId",
                table: "AspNetUsers",
                column: "EmployeeId",
                principalTable: "Employees",
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
                name: "FK_AspNetUsers_Customer_CustomerId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Employees_EmployeeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountTypes",
                table: "AccountTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "AccountTypes",
                newName: "AccountType");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "BaseProfiles");

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

            migrationBuilder.AddColumn<string>(
                name: "BrokerCode",
                table: "BaseProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentAccountBalance",
                table: "BaseProfiles",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Customer_BrokerCode",
                table: "BaseProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Customer_EmployeeId",
                table: "BaseProfiles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
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

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "BaseProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountType",
                table: "AccountType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseProfiles",
                table: "BaseProfiles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BaseProfiles_AccountTypeId",
                table: "BaseProfiles",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseProfiles_Customer_EmployeeId",
                table: "BaseProfiles",
                column: "Customer_EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseProfiles_EmployeeId",
                table: "BaseProfiles",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_BaseProfiles_CustomerId",
                table: "AspNetUsers",
                column: "CustomerId",
                principalTable: "BaseProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_BaseProfiles_EmployeeId",
                table: "AspNetUsers",
                column: "EmployeeId",
                principalTable: "BaseProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseProfiles_AccountType_AccountTypeId",
                table: "BaseProfiles",
                column: "AccountTypeId",
                principalTable: "AccountType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseProfiles_BaseProfiles_Customer_EmployeeId",
                table: "BaseProfiles",
                column: "Customer_EmployeeId",
                principalTable: "BaseProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseProfiles_BaseProfiles_EmployeeId",
                table: "BaseProfiles",
                column: "EmployeeId",
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
