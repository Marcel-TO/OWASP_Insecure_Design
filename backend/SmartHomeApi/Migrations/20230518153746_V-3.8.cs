using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHomeApi.Migrations
{
    /// <inheritdoc />
    public partial class V38 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bulb_actuators_light_bulbs_Smartbulb_Id",
                table: "bulb_actuators");

            migrationBuilder.DropForeignKey(
                name: "FK_bulb_sensors_light_bulbs_Smartbulb_Id",
                table: "bulb_sensors");

            migrationBuilder.DropForeignKey(
                name: "FK_jalousine_actuators_jalousines_SmartJalousineJalousine_Id",
                table: "jalousine_actuators");

            migrationBuilder.DropForeignKey(
                name: "FK_jalousine_sensors_jalousines_SmartJalousineJalousine_Id",
                table: "jalousine_sensors");

            migrationBuilder.DropIndex(
                name: "IX_jalousine_sensors_SmartJalousineJalousine_Id",
                table: "jalousine_sensors");

            migrationBuilder.DropIndex(
                name: "IX_jalousine_actuators_SmartJalousineJalousine_Id",
                table: "jalousine_actuators");

            migrationBuilder.DropIndex(
                name: "IX_bulb_sensors_Smartbulb_Id",
                table: "bulb_sensors");

            migrationBuilder.DropIndex(
                name: "IX_bulb_actuators_Smartbulb_Id",
                table: "bulb_actuators");

            migrationBuilder.DropColumn(
                name: "SmartJalousineJalousine_Id",
                table: "jalousine_sensors");

            migrationBuilder.DropColumn(
                name: "SmartJalousineJalousine_Id",
                table: "jalousine_actuators");

            migrationBuilder.DropColumn(
                name: "Smartbulb_Id",
                table: "bulb_sensors");

            migrationBuilder.DropColumn(
                name: "Smartbulb_Id",
                table: "bulb_actuators");

            migrationBuilder.CreateIndex(
                name: "IX_jalousine_sensors_Jal_Id",
                table: "jalousine_sensors",
                column: "Jal_Id");

            migrationBuilder.CreateIndex(
                name: "IX_jalousine_actuators_Jal_Id",
                table: "jalousine_actuators",
                column: "Jal_Id");

            migrationBuilder.CreateIndex(
                name: "IX_bulb_sensors_Bulb_Id",
                table: "bulb_sensors",
                column: "Bulb_Id");

            migrationBuilder.CreateIndex(
                name: "IX_bulb_actuators_Bulb_Id",
                table: "bulb_actuators",
                column: "Bulb_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_bulb_actuators_light_bulbs_Bulb_Id",
                table: "bulb_actuators",
                column: "Bulb_Id",
                principalTable: "light_bulbs",
                principalColumn: "Smartbulb_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bulb_sensors_light_bulbs_Bulb_Id",
                table: "bulb_sensors",
                column: "Bulb_Id",
                principalTable: "light_bulbs",
                principalColumn: "Smartbulb_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_jalousine_actuators_jalousines_Jal_Id",
                table: "jalousine_actuators",
                column: "Jal_Id",
                principalTable: "jalousines",
                principalColumn: "Jalousine_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_jalousine_sensors_jalousines_Jal_Id",
                table: "jalousine_sensors",
                column: "Jal_Id",
                principalTable: "jalousines",
                principalColumn: "Jalousine_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bulb_actuators_light_bulbs_Bulb_Id",
                table: "bulb_actuators");

            migrationBuilder.DropForeignKey(
                name: "FK_bulb_sensors_light_bulbs_Bulb_Id",
                table: "bulb_sensors");

            migrationBuilder.DropForeignKey(
                name: "FK_jalousine_actuators_jalousines_Jal_Id",
                table: "jalousine_actuators");

            migrationBuilder.DropForeignKey(
                name: "FK_jalousine_sensors_jalousines_Jal_Id",
                table: "jalousine_sensors");

            migrationBuilder.DropIndex(
                name: "IX_jalousine_sensors_Jal_Id",
                table: "jalousine_sensors");

            migrationBuilder.DropIndex(
                name: "IX_jalousine_actuators_Jal_Id",
                table: "jalousine_actuators");

            migrationBuilder.DropIndex(
                name: "IX_bulb_sensors_Bulb_Id",
                table: "bulb_sensors");

            migrationBuilder.DropIndex(
                name: "IX_bulb_actuators_Bulb_Id",
                table: "bulb_actuators");

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
                name: "Smartbulb_Id",
                table: "bulb_sensors",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "Smartbulb_Id",
                table: "bulb_actuators",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_jalousine_sensors_SmartJalousineJalousine_Id",
                table: "jalousine_sensors",
                column: "SmartJalousineJalousine_Id");

            migrationBuilder.CreateIndex(
                name: "IX_jalousine_actuators_SmartJalousineJalousine_Id",
                table: "jalousine_actuators",
                column: "SmartJalousineJalousine_Id");

            migrationBuilder.CreateIndex(
                name: "IX_bulb_sensors_Smartbulb_Id",
                table: "bulb_sensors",
                column: "Smartbulb_Id");

            migrationBuilder.CreateIndex(
                name: "IX_bulb_actuators_Smartbulb_Id",
                table: "bulb_actuators",
                column: "Smartbulb_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_bulb_actuators_light_bulbs_Smartbulb_Id",
                table: "bulb_actuators",
                column: "Smartbulb_Id",
                principalTable: "light_bulbs",
                principalColumn: "Smartbulb_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_bulb_sensors_light_bulbs_Smartbulb_Id",
                table: "bulb_sensors",
                column: "Smartbulb_Id",
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
        }
    }
}
