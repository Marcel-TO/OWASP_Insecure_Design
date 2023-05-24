using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHomeApi.Migrations
{
    /// <inheritdoc />
    public partial class V18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_thermostat_sensors_thermostats_Thermostat_Id",
                table: "thermostat_sensors");

            migrationBuilder.DropIndex(
                name: "IX_thermostat_sensors_Thermostat_Id",
                table: "thermostat_sensors");

            migrationBuilder.AddColumn<Guid>(
                name: "ParentThermostatThermostat_Id",
                table: "thermostat_sensors",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_thermostat_sensors_ParentThermostatThermostat_Id",
                table: "thermostat_sensors",
                column: "ParentThermostatThermostat_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_thermostat_sensors_thermostats_ParentThermostatThermostat_Id",
                table: "thermostat_sensors",
                column: "ParentThermostatThermostat_Id",
                principalTable: "thermostats",
                principalColumn: "Thermostat_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_thermostat_sensors_thermostats_ParentThermostatThermostat_Id",
                table: "thermostat_sensors");

            migrationBuilder.DropIndex(
                name: "IX_thermostat_sensors_ParentThermostatThermostat_Id",
                table: "thermostat_sensors");

            migrationBuilder.DropColumn(
                name: "ParentThermostatThermostat_Id",
                table: "thermostat_sensors");

            migrationBuilder.CreateIndex(
                name: "IX_thermostat_sensors_Thermostat_Id",
                table: "thermostat_sensors",
                column: "Thermostat_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_thermostat_sensors_thermostats_Thermostat_Id",
                table: "thermostat_sensors",
                column: "Thermostat_Id",
                principalTable: "thermostats",
                principalColumn: "Thermostat_Id");
        }
    }
}
