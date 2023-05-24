using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHomeApi.Migrations
{
    /// <inheritdoc />
    public partial class V33 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Account_Id1",
                table: "light_bulbs",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "Account_Id1",
                table: "jalousines",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "SmartJalousineJalousine_Id",
                table: "jalousine_sensors",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "SmartJalousineJalousine_Id",
                table: "jalousine_actuators",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "Smartbulb_Id1",
                table: "bulb_sensors",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "Smartbulb_Id1",
                table: "bulb_actuators",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_light_bulbs_Account_Id1",
                table: "light_bulbs",
                column: "Account_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_jalousines_Account_Id1",
                table: "jalousines",
                column: "Account_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_jalousine_sensors_SmartJalousineJalousine_Id",
                table: "jalousine_sensors",
                column: "SmartJalousineJalousine_Id");

            migrationBuilder.CreateIndex(
                name: "IX_jalousine_actuators_SmartJalousineJalousine_Id",
                table: "jalousine_actuators",
                column: "SmartJalousineJalousine_Id");

            migrationBuilder.CreateIndex(
                name: "IX_bulb_sensors_Smartbulb_Id1",
                table: "bulb_sensors",
                column: "Smartbulb_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_bulb_actuators_Smartbulb_Id1",
                table: "bulb_actuators",
                column: "Smartbulb_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_bulb_actuators_light_bulbs_Smartbulb_Id1",
                table: "bulb_actuators",
                column: "Smartbulb_Id1",
                principalTable: "light_bulbs",
                principalColumn: "Smartbulb_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_bulb_sensors_light_bulbs_Smartbulb_Id1",
                table: "bulb_sensors",
                column: "Smartbulb_Id1",
                principalTable: "light_bulbs",
                principalColumn: "Smartbulb_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_jalousine_actuators_jalousines_SmartJalousineJalousine_Id",
                table: "jalousine_actuators",
                column: "SmartJalousineJalousine_Id",
                principalTable: "jalousines",
                principalColumn: "Jalousine_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_jalousine_sensors_jalousines_SmartJalousineJalousine_Id",
                table: "jalousine_sensors",
                column: "SmartJalousineJalousine_Id",
                principalTable: "jalousines",
                principalColumn: "Jalousine_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_jalousines_accounts_Account_Id1",
                table: "jalousines",
                column: "Account_Id1",
                principalTable: "accounts",
                principalColumn: "Account_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_light_bulbs_accounts_Account_Id1",
                table: "light_bulbs",
                column: "Account_Id1",
                principalTable: "accounts",
                principalColumn: "Account_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bulb_actuators_light_bulbs_Smartbulb_Id1",
                table: "bulb_actuators");

            migrationBuilder.DropForeignKey(
                name: "FK_bulb_sensors_light_bulbs_Smartbulb_Id1",
                table: "bulb_sensors");

            migrationBuilder.DropForeignKey(
                name: "FK_jalousine_actuators_jalousines_SmartJalousineJalousine_Id",
                table: "jalousine_actuators");

            migrationBuilder.DropForeignKey(
                name: "FK_jalousine_sensors_jalousines_SmartJalousineJalousine_Id",
                table: "jalousine_sensors");

            migrationBuilder.DropForeignKey(
                name: "FK_jalousines_accounts_Account_Id1",
                table: "jalousines");

            migrationBuilder.DropForeignKey(
                name: "FK_light_bulbs_accounts_Account_Id1",
                table: "light_bulbs");

            migrationBuilder.DropIndex(
                name: "IX_light_bulbs_Account_Id1",
                table: "light_bulbs");

            migrationBuilder.DropIndex(
                name: "IX_jalousines_Account_Id1",
                table: "jalousines");

            migrationBuilder.DropIndex(
                name: "IX_jalousine_sensors_SmartJalousineJalousine_Id",
                table: "jalousine_sensors");

            migrationBuilder.DropIndex(
                name: "IX_jalousine_actuators_SmartJalousineJalousine_Id",
                table: "jalousine_actuators");

            migrationBuilder.DropIndex(
                name: "IX_bulb_sensors_Smartbulb_Id1",
                table: "bulb_sensors");

            migrationBuilder.DropIndex(
                name: "IX_bulb_actuators_Smartbulb_Id1",
                table: "bulb_actuators");

            migrationBuilder.DropColumn(
                name: "Account_Id1",
                table: "light_bulbs");

            migrationBuilder.DropColumn(
                name: "Account_Id1",
                table: "jalousines");

            migrationBuilder.DropColumn(
                name: "SmartJalousineJalousine_Id",
                table: "jalousine_sensors");

            migrationBuilder.DropColumn(
                name: "SmartJalousineJalousine_Id",
                table: "jalousine_actuators");

            migrationBuilder.DropColumn(
                name: "Smartbulb_Id1",
                table: "bulb_sensors");

            migrationBuilder.DropColumn(
                name: "Smartbulb_Id1",
                table: "bulb_actuators");
        }
    }
}
