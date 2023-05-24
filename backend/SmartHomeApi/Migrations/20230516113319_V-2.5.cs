using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHomeApi.Migrations
{
    /// <inheritdoc />
    public partial class V25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_thermostat_sensors_Thermostat_Id",
                table: "thermostat_sensors",
                column: "Thermostat_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_thermostat_sensors_thermostats_Thermostat_Id",
                table: "thermostat_sensors",
                column: "Thermostat_Id",
                principalTable: "thermostats",
                principalColumn: "Thermostat_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_thermostat_sensors_thermostats_Thermostat_Id",
                table: "thermostat_sensors");

            migrationBuilder.DropIndex(
                name: "IX_thermostat_sensors_Thermostat_Id",
                table: "thermostat_sensors");
        }
    }
}
