using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHomeApi.Migrations
{
    /// <inheritdoc />
    public partial class V26 : Migration
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
                name: "Thermostat_Id1",
                table: "thermostat_sensors",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_thermostat_sensors_Thermostat_Id1",
                table: "thermostat_sensors",
                column: "Thermostat_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_thermostat_sensors_thermostats_Thermostat_Id1",
                table: "thermostat_sensors",
                column: "Thermostat_Id1",
                principalTable: "thermostats",
                principalColumn: "Thermostat_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_thermostat_sensors_thermostats_Thermostat_Id1",
                table: "thermostat_sensors");

            migrationBuilder.DropIndex(
                name: "IX_thermostat_sensors_Thermostat_Id1",
                table: "thermostat_sensors");

            migrationBuilder.DropColumn(
                name: "Thermostat_Id1",
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
                principalColumn: "Thermostat_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
