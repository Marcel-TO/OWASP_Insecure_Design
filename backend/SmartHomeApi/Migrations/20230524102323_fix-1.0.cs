using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHomeApi.Migrations
{
    /// <inheritdoc />
    public partial class fix10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    Account_Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Role = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.Account_Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "jalousines",
                columns: table => new
                {
                    Jalousine_Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Acc_Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jalousines", x => x.Jalousine_Id);
                    table.ForeignKey(
                        name: "FK_jalousines_accounts_Acc_Id",
                        column: x => x.Acc_Id,
                        principalTable: "accounts",
                        principalColumn: "Account_Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "light_bulbs",
                columns: table => new
                {
                    Smartbulb_Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Acc_Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_light_bulbs", x => x.Smartbulb_Id);
                    table.ForeignKey(
                        name: "FK_light_bulbs_accounts_Acc_Id",
                        column: x => x.Acc_Id,
                        principalTable: "accounts",
                        principalColumn: "Account_Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "thermostats",
                columns: table => new
                {
                    Thermostat_Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Acc_Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thermostats", x => x.Thermostat_Id);
                    table.ForeignKey(
                        name: "FK_thermostats_accounts_Acc_Id",
                        column: x => x.Acc_Id,
                        principalTable: "accounts",
                        principalColumn: "Account_Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "jalousine_actuators",
                columns: table => new
                {
                    Actuator_Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Target_State = table.Column<int>(type: "int", nullable: false),
                    Sensor_Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Jal_Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jalousine_actuators", x => x.Actuator_Id);
                    table.ForeignKey(
                        name: "FK_jalousine_actuators_jalousines_Jal_Id",
                        column: x => x.Jal_Id,
                        principalTable: "jalousines",
                        principalColumn: "Jalousine_Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "jalousine_sensors",
                columns: table => new
                {
                    Sensor_Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    State = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Actuator_Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Jal_Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jalousine_sensors", x => x.Sensor_Id);
                    table.ForeignKey(
                        name: "FK_jalousine_sensors_jalousines_Jal_Id",
                        column: x => x.Jal_Id,
                        principalTable: "jalousines",
                        principalColumn: "Jalousine_Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "bulb_actuators",
                columns: table => new
                {
                    Actuator_Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Target_Brightness = table.Column<int>(type: "int", nullable: false),
                    Sensor_Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Bulb_Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bulb_actuators", x => x.Actuator_Id);
                    table.ForeignKey(
                        name: "FK_bulb_actuators_light_bulbs_Bulb_Id",
                        column: x => x.Bulb_Id,
                        principalTable: "light_bulbs",
                        principalColumn: "Smartbulb_Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "bulb_sensors",
                columns: table => new
                {
                    Sensor_Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Brightness = table.Column<int>(type: "int", nullable: false),
                    Actuator_Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Bulb_Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bulb_sensors", x => x.Sensor_Id);
                    table.ForeignKey(
                        name: "FK_bulb_sensors_light_bulbs_Bulb_Id",
                        column: x => x.Bulb_Id,
                        principalTable: "light_bulbs",
                        principalColumn: "Smartbulb_Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "thermostat_actuator",
                columns: table => new
                {
                    Actuator_Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Target_Temperature = table.Column<int>(type: "int", nullable: false),
                    Sensor_Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Therm_Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thermostat_actuator", x => x.Actuator_Id);
                    table.ForeignKey(
                        name: "FK_thermostat_actuator_thermostats_Therm_Id",
                        column: x => x.Therm_Id,
                        principalTable: "thermostats",
                        principalColumn: "Thermostat_Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "thermostat_sensors",
                columns: table => new
                {
                    Sensor_Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Temperature = table.Column<int>(type: "int", nullable: false),
                    Actuator_Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Therm_Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thermostat_sensors", x => x.Sensor_Id);
                    table.ForeignKey(
                        name: "FK_thermostat_sensors_thermostats_Therm_Id",
                        column: x => x.Therm_Id,
                        principalTable: "thermostats",
                        principalColumn: "Thermostat_Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_bulb_actuators_Bulb_Id",
                table: "bulb_actuators",
                column: "Bulb_Id");

            migrationBuilder.CreateIndex(
                name: "IX_bulb_sensors_Bulb_Id",
                table: "bulb_sensors",
                column: "Bulb_Id");

            migrationBuilder.CreateIndex(
                name: "IX_jalousine_actuators_Jal_Id",
                table: "jalousine_actuators",
                column: "Jal_Id");

            migrationBuilder.CreateIndex(
                name: "IX_jalousine_sensors_Jal_Id",
                table: "jalousine_sensors",
                column: "Jal_Id");

            migrationBuilder.CreateIndex(
                name: "IX_jalousines_Acc_Id",
                table: "jalousines",
                column: "Acc_Id");

            migrationBuilder.CreateIndex(
                name: "IX_light_bulbs_Acc_Id",
                table: "light_bulbs",
                column: "Acc_Id");

            migrationBuilder.CreateIndex(
                name: "IX_thermostat_actuator_Therm_Id",
                table: "thermostat_actuator",
                column: "Therm_Id");

            migrationBuilder.CreateIndex(
                name: "IX_thermostat_sensors_Therm_Id",
                table: "thermostat_sensors",
                column: "Therm_Id");

            migrationBuilder.CreateIndex(
                name: "IX_thermostats_Acc_Id",
                table: "thermostats",
                column: "Acc_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bulb_actuators");

            migrationBuilder.DropTable(
                name: "bulb_sensors");

            migrationBuilder.DropTable(
                name: "jalousine_actuators");

            migrationBuilder.DropTable(
                name: "jalousine_sensors");

            migrationBuilder.DropTable(
                name: "thermostat_actuator");

            migrationBuilder.DropTable(
                name: "thermostat_sensors");

            migrationBuilder.DropTable(
                name: "light_bulbs");

            migrationBuilder.DropTable(
                name: "jalousines");

            migrationBuilder.DropTable(
                name: "thermostats");

            migrationBuilder.DropTable(
                name: "accounts");
        }
    }
}
