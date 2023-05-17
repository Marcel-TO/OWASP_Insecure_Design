using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHomeApi.Migrations
{
    /// <inheritdoc />
    public partial class V30 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_thermostat_sensors_thermostats_Thermostat_Id1",
                table: "thermostat_sensors");

            migrationBuilder.AlterColumn<Guid>(
                name: "Thermostat_Id1",
                table: "thermostat_sensors",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "Thermostat_Id1",
                table: "thermostat_actuator",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_thermostat_actuator_Thermostat_Id1",
                table: "thermostat_actuator",
                column: "Thermostat_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_thermostat_actuator_thermostats_Thermostat_Id1",
                table: "thermostat_actuator",
                column: "Thermostat_Id1",
                principalTable: "thermostats",
                principalColumn: "Thermostat_Id");

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
                name: "FK_thermostat_actuator_thermostats_Thermostat_Id1",
                table: "thermostat_actuator");

            migrationBuilder.DropForeignKey(
                name: "FK_thermostat_sensors_thermostats_Thermostat_Id1",
                table: "thermostat_sensors");

            migrationBuilder.DropIndex(
                name: "IX_thermostat_actuator_Thermostat_Id1",
                table: "thermostat_actuator");

            migrationBuilder.DropColumn(
                name: "Thermostat_Id1",
                table: "thermostat_actuator");

            migrationBuilder.AlterColumn<Guid>(
                name: "Thermostat_Id1",
                table: "thermostat_sensors",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_thermostat_sensors_thermostats_Thermostat_Id1",
                table: "thermostat_sensors",
                column: "Thermostat_Id1",
                principalTable: "thermostats",
                principalColumn: "Thermostat_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
