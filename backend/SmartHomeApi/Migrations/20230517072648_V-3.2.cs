using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHomeApi.Migrations
{
    /// <inheritdoc />
    public partial class V32 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Account_Id1",
                table: "thermostats",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_thermostats_Account_Id1",
                table: "thermostats",
                column: "Account_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_thermostats_accounts_Account_Id1",
                table: "thermostats",
                column: "Account_Id1",
                principalTable: "accounts",
                principalColumn: "Account_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_thermostats_accounts_Account_Id1",
                table: "thermostats");

            migrationBuilder.DropIndex(
                name: "IX_thermostats_Account_Id1",
                table: "thermostats");

            migrationBuilder.DropColumn(
                name: "Account_Id1",
                table: "thermostats");
        }
    }
}
