using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHomeApi.Migrations
{
    /// <inheritdoc />
    public partial class V35 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bulb_actuators_light_bulbs_Smartbulb_Id1",
                table: "bulb_actuators");

            migrationBuilder.DropForeignKey(
                name: "FK_bulb_sensors_light_bulbs_Smartbulb_Id1",
                table: "bulb_sensors");

            migrationBuilder.DropForeignKey(
                name: "FK_jalousines_accounts_Account_Id1",
                table: "jalousines");

            migrationBuilder.DropForeignKey(
                name: "FK_light_bulbs_accounts_Account_Id1",
                table: "light_bulbs");

            migrationBuilder.DropForeignKey(
                name: "FK_thermostat_actuator_thermostats_Thermostat_Id1",
                table: "thermostat_actuator");

            migrationBuilder.DropForeignKey(
                name: "FK_thermostat_sensors_thermostats_Thermostat_Id1",
                table: "thermostat_sensors");

            migrationBuilder.DropForeignKey(
                name: "FK_thermostats_accounts_Account_Id1",
                table: "thermostats");

            migrationBuilder.DropIndex(
                name: "IX_thermostats_Account_Id1",
                table: "thermostats");

            migrationBuilder.DropIndex(
                name: "IX_thermostat_sensors_Thermostat_Id1",
                table: "thermostat_sensors");

            migrationBuilder.DropIndex(
                name: "IX_thermostat_actuator_Thermostat_Id1",
                table: "thermostat_actuator");

            migrationBuilder.DropIndex(
                name: "IX_light_bulbs_Account_Id1",
                table: "light_bulbs");

            migrationBuilder.DropIndex(
                name: "IX_jalousines_Account_Id1",
                table: "jalousines");

            migrationBuilder.DropIndex(
                name: "IX_bulb_sensors_Smartbulb_Id1",
                table: "bulb_sensors");

            migrationBuilder.DropIndex(
                name: "IX_bulb_actuators_Smartbulb_Id1",
                table: "bulb_actuators");

            migrationBuilder.DropColumn(
                name: "Account_Id1",
                table: "thermostats");

            migrationBuilder.DropColumn(
                name: "Thermostat_Id1",
                table: "thermostat_sensors");

            migrationBuilder.DropColumn(
                name: "Thermostat_Id1",
                table: "thermostat_actuator");

            migrationBuilder.DropColumn(
                name: "Account_Id1",
                table: "light_bulbs");

            migrationBuilder.DropColumn(
                name: "Account_Id1",
                table: "jalousines");

            migrationBuilder.DropColumn(
                name: "Smartbulb_Id1",
                table: "bulb_sensors");

            migrationBuilder.DropColumn(
                name: "Smartbulb_Id1",
                table: "bulb_actuators");

            migrationBuilder.RenameColumn(
                name: "Account_Id",
                table: "thermostats",
                newName: "Acc_Id");

            migrationBuilder.RenameColumn(
                name: "Account_Id",
                table: "light_bulbs",
                newName: "Acc_Id");

            migrationBuilder.RenameColumn(
                name: "Account_Id",
                table: "jalousines",
                newName: "Acc_Id");

            migrationBuilder.RenameColumn(
                name: "Jalousine_Id",
                table: "jalousine_sensors",
                newName: "Jal_Id");

            migrationBuilder.RenameColumn(
                name: "Jalousine_Id",
                table: "jalousine_actuators",
                newName: "Jal_Id");

            migrationBuilder.AlterColumn<Guid>(
                name: "Thermostat_Id",
                table: "thermostat_sensors",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "Therm_Id",
                table: "thermostat_sensors",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Thermostat_Id",
                table: "thermostat_actuator",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "Therm_Id",
                table: "thermostat_actuator",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Smartbulb_Id",
                table: "bulb_sensors",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "Bulb_Id",
                table: "bulb_sensors",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Smartbulb_Id",
                table: "bulb_actuators",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "Bulb_Id",
                table: "bulb_actuators",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_thermostats_Acc_Id",
                table: "thermostats",
                column: "Acc_Id");

            migrationBuilder.CreateIndex(
                name: "IX_thermostat_sensors_Thermostat_Id",
                table: "thermostat_sensors",
                column: "Thermostat_Id");

            migrationBuilder.CreateIndex(
                name: "IX_thermostat_actuator_Thermostat_Id",
                table: "thermostat_actuator",
                column: "Thermostat_Id");

            migrationBuilder.CreateIndex(
                name: "IX_light_bulbs_Acc_Id",
                table: "light_bulbs",
                column: "Acc_Id");

            migrationBuilder.CreateIndex(
                name: "IX_jalousines_Acc_Id",
                table: "jalousines",
                column: "Acc_Id");

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
                name: "FK_jalousines_accounts_Acc_Id",
                table: "jalousines",
                column: "Acc_Id",
                principalTable: "accounts",
                principalColumn: "Account_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_light_bulbs_accounts_Acc_Id",
                table: "light_bulbs",
                column: "Acc_Id",
                principalTable: "accounts",
                principalColumn: "Account_Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_thermostats_accounts_Acc_Id",
                table: "thermostats",
                column: "Acc_Id",
                principalTable: "accounts",
                principalColumn: "Account_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bulb_actuators_light_bulbs_Smartbulb_Id",
                table: "bulb_actuators");

            migrationBuilder.DropForeignKey(
                name: "FK_bulb_sensors_light_bulbs_Smartbulb_Id",
                table: "bulb_sensors");

            migrationBuilder.DropForeignKey(
                name: "FK_jalousines_accounts_Acc_Id",
                table: "jalousines");

            migrationBuilder.DropForeignKey(
                name: "FK_light_bulbs_accounts_Acc_Id",
                table: "light_bulbs");

            migrationBuilder.DropForeignKey(
                name: "FK_thermostat_actuator_thermostats_Thermostat_Id",
                table: "thermostat_actuator");

            migrationBuilder.DropForeignKey(
                name: "FK_thermostat_sensors_thermostats_Thermostat_Id",
                table: "thermostat_sensors");

            migrationBuilder.DropForeignKey(
                name: "FK_thermostats_accounts_Acc_Id",
                table: "thermostats");

            migrationBuilder.DropIndex(
                name: "IX_thermostats_Acc_Id",
                table: "thermostats");

            migrationBuilder.DropIndex(
                name: "IX_thermostat_sensors_Thermostat_Id",
                table: "thermostat_sensors");

            migrationBuilder.DropIndex(
                name: "IX_thermostat_actuator_Thermostat_Id",
                table: "thermostat_actuator");

            migrationBuilder.DropIndex(
                name: "IX_light_bulbs_Acc_Id",
                table: "light_bulbs");

            migrationBuilder.DropIndex(
                name: "IX_jalousines_Acc_Id",
                table: "jalousines");

            migrationBuilder.DropIndex(
                name: "IX_bulb_sensors_Smartbulb_Id",
                table: "bulb_sensors");

            migrationBuilder.DropIndex(
                name: "IX_bulb_actuators_Smartbulb_Id",
                table: "bulb_actuators");

            migrationBuilder.DropColumn(
                name: "Therm_Id",
                table: "thermostat_sensors");

            migrationBuilder.DropColumn(
                name: "Therm_Id",
                table: "thermostat_actuator");

            migrationBuilder.DropColumn(
                name: "Bulb_Id",
                table: "bulb_sensors");

            migrationBuilder.DropColumn(
                name: "Bulb_Id",
                table: "bulb_actuators");

            migrationBuilder.RenameColumn(
                name: "Acc_Id",
                table: "thermostats",
                newName: "Account_Id");

            migrationBuilder.RenameColumn(
                name: "Acc_Id",
                table: "light_bulbs",
                newName: "Account_Id");

            migrationBuilder.RenameColumn(
                name: "Acc_Id",
                table: "jalousines",
                newName: "Account_Id");

            migrationBuilder.RenameColumn(
                name: "Jal_Id",
                table: "jalousine_sensors",
                newName: "Jalousine_Id");

            migrationBuilder.RenameColumn(
                name: "Jal_Id",
                table: "jalousine_actuators",
                newName: "Jalousine_Id");

            migrationBuilder.AddColumn<Guid>(
                name: "Account_Id1",
                table: "thermostats",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Thermostat_Id",
                table: "thermostat_sensors",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "Thermostat_Id1",
                table: "thermostat_sensors",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Thermostat_Id",
                table: "thermostat_actuator",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "Thermostat_Id1",
                table: "thermostat_actuator",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "Smartbulb_Id",
                table: "bulb_sensors",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "Smartbulb_Id1",
                table: "bulb_sensors",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Smartbulb_Id",
                table: "bulb_actuators",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "Smartbulb_Id1",
                table: "bulb_actuators",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_thermostats_Account_Id1",
                table: "thermostats",
                column: "Account_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_thermostat_sensors_Thermostat_Id1",
                table: "thermostat_sensors",
                column: "Thermostat_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_thermostat_actuator_Thermostat_Id1",
                table: "thermostat_actuator",
                column: "Thermostat_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_light_bulbs_Account_Id1",
                table: "light_bulbs",
                column: "Account_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_jalousines_Account_Id1",
                table: "jalousines",
                column: "Account_Id1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_thermostats_accounts_Account_Id1",
                table: "thermostats",
                column: "Account_Id1",
                principalTable: "accounts",
                principalColumn: "Account_Id");
        }
    }
}
