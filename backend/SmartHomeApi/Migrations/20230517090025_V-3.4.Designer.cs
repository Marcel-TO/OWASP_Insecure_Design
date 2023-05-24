﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartHomeApi.Api_Source_Code.Contexts;

#nullable disable

namespace SmartHomeApi.Migrations
{
    [DbContext(typeof(SHDbContext))]
    [Migration("20230517090025_V-3.4")]
    partial class V34
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SmartHomeApi.Api_Source_Code.Models.Account", b =>
                {
                    b.Property<Guid>("Account_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.HasKey("Account_Id");

                    b.ToTable("accounts");
                });

            modelBuilder.Entity("SmartHomeApi.Api_Source_Code.Models.BulbActuator", b =>
                {
                    b.Property<Guid>("Actuator_Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("Sensor_Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Smartbulb_Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("Smartbulb_Id1")
                        .HasColumnType("char(36)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("Target_Brightness")
                        .HasColumnType("int");

                    b.HasKey("Actuator_Id");

                    b.HasIndex("Smartbulb_Id1");

                    b.ToTable("bulb_actuators");
                });

            modelBuilder.Entity("SmartHomeApi.Api_Source_Code.Models.BulbSensor", b =>
                {
                    b.Property<Guid>("Sensor_Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Actuator_Id")
                        .HasColumnType("char(36)");

                    b.Property<int>("Brightness")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("Smartbulb_Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("Smartbulb_Id1")
                        .HasColumnType("char(36)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Sensor_Id");

                    b.HasIndex("Smartbulb_Id1");

                    b.ToTable("bulb_sensors");
                });

            modelBuilder.Entity("SmartHomeApi.Api_Source_Code.Models.JalousineActuator", b =>
                {
                    b.Property<Guid>("Actuator_Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Jalousine_Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("Sensor_Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("SmartJalousineJalousine_Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("Target_State")
                        .HasColumnType("int");

                    b.HasKey("Actuator_Id");

                    b.HasIndex("SmartJalousineJalousine_Id");

                    b.ToTable("jalousine_actuators");
                });

            modelBuilder.Entity("SmartHomeApi.Api_Source_Code.Models.JalousineSensor", b =>
                {
                    b.Property<Guid>("Sensor_Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Actuator_Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Jalousine_Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid?>("SmartJalousineJalousine_Id")
                        .HasColumnType("char(36)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Sensor_Id");

                    b.HasIndex("SmartJalousineJalousine_Id");

                    b.ToTable("jalousine_sensors");
                });

            modelBuilder.Entity("SmartHomeApi.Api_Source_Code.Models.SmartBulb", b =>
                {
                    b.Property<Guid>("Smartbulb_Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Account_Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("Account_Id1")
                        .HasColumnType("char(36)");

                    b.HasKey("Smartbulb_Id");

                    b.HasIndex("Account_Id1");

                    b.ToTable("light_bulbs");
                });

            modelBuilder.Entity("SmartHomeApi.Api_Source_Code.Models.SmartJalousine", b =>
                {
                    b.Property<Guid>("Jalousine_Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Account_Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("Account_Id1")
                        .HasColumnType("char(36)");

                    b.HasKey("Jalousine_Id");

                    b.HasIndex("Account_Id1");

                    b.ToTable("jalousines");
                });

            modelBuilder.Entity("SmartHomeApi.Api_Source_Code.Models.Thermostat", b =>
                {
                    b.Property<Guid>("Thermostat_Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Account_Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("Account_Id1")
                        .HasColumnType("char(36)");

                    b.HasKey("Thermostat_Id");

                    b.HasIndex("Account_Id1");

                    b.ToTable("thermostats");
                });

            modelBuilder.Entity("SmartHomeApi.Api_Source_Code.Models.ThermostatActuator", b =>
                {
                    b.Property<Guid>("Actuator_Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("Sensor_Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("Target_Temperature")
                        .HasColumnType("int");

                    b.Property<Guid>("Thermostat_Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("Thermostat_Id1")
                        .HasColumnType("char(36)");

                    b.HasKey("Actuator_Id");

                    b.HasIndex("Thermostat_Id1");

                    b.ToTable("thermostat_actuator");
                });

            modelBuilder.Entity("SmartHomeApi.Api_Source_Code.Models.ThermostatSensor", b =>
                {
                    b.Property<Guid>("Sensor_Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Actuator_Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("Temperature")
                        .HasColumnType("int");

                    b.Property<Guid>("Thermostat_Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("Thermostat_Id1")
                        .HasColumnType("char(36)");

                    b.HasKey("Sensor_Id");

                    b.HasIndex("Thermostat_Id1");

                    b.ToTable("thermostat_sensors");
                });

            modelBuilder.Entity("SmartHomeApi.Api_Source_Code.Models.BulbActuator", b =>
                {
                    b.HasOne("SmartHomeApi.Api_Source_Code.Models.SmartBulb", "SmartBulb")
                        .WithMany("Actuators")
                        .HasForeignKey("Smartbulb_Id1");

                    b.Navigation("SmartBulb");
                });

            modelBuilder.Entity("SmartHomeApi.Api_Source_Code.Models.BulbSensor", b =>
                {
                    b.HasOne("SmartHomeApi.Api_Source_Code.Models.SmartBulb", "SmartBulb")
                        .WithMany("Sensors")
                        .HasForeignKey("Smartbulb_Id1");

                    b.Navigation("SmartBulb");
                });

            modelBuilder.Entity("SmartHomeApi.Api_Source_Code.Models.JalousineActuator", b =>
                {
                    b.HasOne("SmartHomeApi.Api_Source_Code.Models.SmartJalousine", "SmartJalousine")
                        .WithMany("Actuators")
                        .HasForeignKey("SmartJalousineJalousine_Id");

                    b.Navigation("SmartJalousine");
                });

            modelBuilder.Entity("SmartHomeApi.Api_Source_Code.Models.JalousineSensor", b =>
                {
                    b.HasOne("SmartHomeApi.Api_Source_Code.Models.SmartJalousine", "SmartJalousine")
                        .WithMany("Sensors")
                        .HasForeignKey("SmartJalousineJalousine_Id");

                    b.Navigation("SmartJalousine");
                });

            modelBuilder.Entity("SmartHomeApi.Api_Source_Code.Models.SmartBulb", b =>
                {
                    b.HasOne("SmartHomeApi.Api_Source_Code.Models.Account", null)
                        .WithMany("SmartBulbs")
                        .HasForeignKey("Account_Id1");
                });

            modelBuilder.Entity("SmartHomeApi.Api_Source_Code.Models.SmartJalousine", b =>
                {
                    b.HasOne("SmartHomeApi.Api_Source_Code.Models.Account", null)
                        .WithMany("SmartJalousines")
                        .HasForeignKey("Account_Id1");
                });

            modelBuilder.Entity("SmartHomeApi.Api_Source_Code.Models.Thermostat", b =>
                {
                    b.HasOne("SmartHomeApi.Api_Source_Code.Models.Account", null)
                        .WithMany("Thermostats")
                        .HasForeignKey("Account_Id1");
                });

            modelBuilder.Entity("SmartHomeApi.Api_Source_Code.Models.ThermostatActuator", b =>
                {
                    b.HasOne("SmartHomeApi.Api_Source_Code.Models.Thermostat", "Thermostat")
                        .WithMany("Actuators")
                        .HasForeignKey("Thermostat_Id1");

                    b.Navigation("Thermostat");
                });

            modelBuilder.Entity("SmartHomeApi.Api_Source_Code.Models.ThermostatSensor", b =>
                {
                    b.HasOne("SmartHomeApi.Api_Source_Code.Models.Thermostat", "Thermostat")
                        .WithMany("Sensors")
                        .HasForeignKey("Thermostat_Id1");

                    b.Navigation("Thermostat");
                });

            modelBuilder.Entity("SmartHomeApi.Api_Source_Code.Models.Account", b =>
                {
                    b.Navigation("SmartBulbs");

                    b.Navigation("SmartJalousines");

                    b.Navigation("Thermostats");
                });

            modelBuilder.Entity("SmartHomeApi.Api_Source_Code.Models.SmartBulb", b =>
                {
                    b.Navigation("Actuators");

                    b.Navigation("Sensors");
                });

            modelBuilder.Entity("SmartHomeApi.Api_Source_Code.Models.SmartJalousine", b =>
                {
                    b.Navigation("Actuators");

                    b.Navigation("Sensors");
                });

            modelBuilder.Entity("SmartHomeApi.Api_Source_Code.Models.Thermostat", b =>
                {
                    b.Navigation("Actuators");

                    b.Navigation("Sensors");
                });
#pragma warning restore 612, 618
        }
    }
}
