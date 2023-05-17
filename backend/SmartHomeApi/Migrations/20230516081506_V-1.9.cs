using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHomeApi.Migrations
{
    /// <inheritdoc />
    public partial class V19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_thermostat_sensors_thermostats_ParentThermostatThermostat_Id",
                table: "thermostat_sensors");

            migrationBuilder.RenameColumn(
                name: "ParentThermostatThermostat_Id",
                table: "thermostat_sensors",
                newName: "Thermostat_Id1");

            migrationBuilder.RenameIndex(
                name: "IX_thermostat_sensors_ParentThermostatThermostat_Id",
                table: "thermostat_sensors",
                newName: "IX_thermostat_sensors_Thermostat_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_thermostat_sensors_thermostats_Thermostat_Id1",
                table: "thermostat_sensors",
                column: "Thermostat_Id1",
                principalTable: "thermostats",
                principalColumn: "Thermostat_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_thermostat_sensors_thermostats_Thermostat_Id1",
                table: "thermostat_sensors");

            migrationBuilder.RenameColumn(
                name: "Thermostat_Id1",
                table: "thermostat_sensors",
                newName: "ParentThermostatThermostat_Id");

            migrationBuilder.RenameIndex(
                name: "IX_thermostat_sensors_Thermostat_Id1",
                table: "thermostat_sensors",
                newName: "IX_thermostat_sensors_ParentThermostatThermostat_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_thermostat_sensors_thermostats_ParentThermostatThermostat_Id",
                table: "thermostat_sensors",
                column: "ParentThermostatThermostat_Id",
                principalTable: "thermostats",
                principalColumn: "Thermostat_Id");
        }
    }
}
