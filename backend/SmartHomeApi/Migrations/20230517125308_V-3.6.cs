using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHomeApi.Migrations
{
    /// <inheritdoc />
    public partial class V36 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_thermostat_actuator_thermostats_Thermostat_Id",
                table: "thermostat_actuator");

            migrationBuilder.DropForeignKey(
                name: "FK_thermostat_sensors_thermostats_Thermostat_Id",
                table: "thermostat_sensors");

            migrationBuilder.DropIndex(
                name: "IX_thermostat_sensors_Thermostat_Id",
                table: "thermostat_sensors");

            migrationBuilder.DropIndex(
                name: "IX_thermostat_actuator_Thermostat_Id",
                table: "thermostat_actuator");

            migrationBuilder.DropColumn(
                name: "Thermostat_Id",
                table: "thermostat_sensors");

            migrationBuilder.DropColumn(
                name: "Thermostat_Id",
                table: "thermostat_actuator");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "jalousine_sensors",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_thermostat_sensors_Therm_Id",
                table: "thermostat_sensors",
                column: "Therm_Id");

            migrationBuilder.CreateIndex(
                name: "IX_thermostat_actuator_Therm_Id",
                table: "thermostat_actuator",
                column: "Therm_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_thermostat_actuator_thermostats_Therm_Id",
                table: "thermostat_actuator",
                column: "Therm_Id",
                principalTable: "thermostats",
                principalColumn: "Thermostat_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_thermostat_sensors_thermostats_Therm_Id",
                table: "thermostat_sensors",
                column: "Therm_Id",
                principalTable: "thermostats",
                principalColumn: "Thermostat_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_thermostat_actuator_thermostats_Therm_Id",
                table: "thermostat_actuator");

            migrationBuilder.DropForeignKey(
                name: "FK_thermostat_sensors_thermostats_Therm_Id",
                table: "thermostat_sensors");

            migrationBuilder.DropIndex(
                name: "IX_thermostat_sensors_Therm_Id",
                table: "thermostat_sensors");

            migrationBuilder.DropIndex(
                name: "IX_thermostat_actuator_Therm_Id",
                table: "thermostat_actuator");

            migrationBuilder.AddColumn<Guid>(
                name: "Thermostat_Id",
                table: "thermostat_sensors",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "Thermostat_Id",
                table: "thermostat_actuator",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "jalousine_sensors",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_thermostat_sensors_Thermostat_Id",
                table: "thermostat_sensors",
                column: "Thermostat_Id");

            migrationBuilder.CreateIndex(
                name: "IX_thermostat_actuator_Thermostat_Id",
                table: "thermostat_actuator",
                column: "Thermostat_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_thermostat_actuator_thermostats_Thermostat_Id",
                table: "thermostat_actuator",
                column: "Thermostat_Id",
                principalTable: "thermostats",
                principalColumn: "Thermostat_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_thermostat_sensors_thermostats_Thermostat_Id",
                table: "thermostat_sensors",
                column: "Thermostat_Id",
                principalTable: "thermostats",
                principalColumn: "Thermostat_Id");
        }
    }
}
