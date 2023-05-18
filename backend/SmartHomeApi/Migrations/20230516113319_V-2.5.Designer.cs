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
    [Migration("20230516113319_V-2.5")]
    partial class V25
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
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("Sensor_Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Smartbulb_Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("Target_Brightness")
                        .HasColumnType("int");

                    b.HasKey("Actuator_Id");

                    b.ToTable("bulb_actuators");
                });

            modelBuilder.Entity("SmartHomeApi.Api_Source_Code.Models.BulbSensor", b =>
                {
                    b.Property<Guid>("Sensor_Id")
                        .ValueGeneratedOnAdd()
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

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Sensor_Id");

                    b.ToTable("bulb_sensors");
                });

            modelBuilder.Entity("SmartHomeApi.Api_Source_Code.Models.JalousineActuator", b =>
                {
                    b.Property<Guid>("Actuator_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Jalousine_Id")
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

                    b.Property<int>("Target_State")
                        .HasColumnType("int");

                    b.HasKey("Actuator_Id");

                    b.ToTable("jalousine_actuators");
                });

            modelBuilder.Entity("SmartHomeApi.Api_Source_Code.Models.JalousineSensor", b =>
                {
                    b.Property<Guid>("Sensor_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Actuator_Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Jalousine_Id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Sensor_Id");

                    b.ToTable("jalousine_sensors");
                });

            modelBuilder.Entity("SmartHomeApi.Api_Source_Code.Models.SmartBulb", b =>
                {
                    b.Property<Guid>("Smartbulb_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Account_Id")
                        .HasColumnType("char(36)");

                    b.HasKey("Smartbulb_Id");

                    b.ToTable("light_bulbs");
                });

            modelBuilder.Entity("SmartHomeApi.Api_Source_Code.Models.SmartJalousine", b =>
                {
                    b.Property<Guid>("Jalousine_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Account_Id")
                        .HasColumnType("char(36)");

                    b.HasKey("Jalousine_Id");

                    b.ToTable("jalousines");
                });

            modelBuilder.Entity("SmartHomeApi.Api_Source_Code.Models.Thermostat", b =>
                {
                    b.Property<Guid>("Thermostat_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("Account_Id")
                        .HasColumnType("char(36)");

                    b.HasKey("Thermostat_Id");

                    b.ToTable("thermostats");
                });

            modelBuilder.Entity("SmartHomeApi.Api_Source_Code.Models.ThermostatActuator", b =>
                {
                    b.Property<Guid>("Actuator_Id")
                        .ValueGeneratedOnAdd()
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

                    b.HasKey("Actuator_Id");

                    b.ToTable("thermostat_actuator");
                });

            modelBuilder.Entity("SmartHomeApi.Api_Source_Code.Models.ThermostatSensor", b =>
                {
                    b.Property<Guid>("Sensor_Id")
                        .ValueGeneratedOnAdd()
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

                    b.HasKey("Sensor_Id");

                    b.HasIndex("Thermostat_Id");

                    b.ToTable("thermostat_sensors");
                });

            modelBuilder.Entity("SmartHomeApi.Api_Source_Code.Models.ThermostatSensor", b =>
                {
                    b.HasOne("SmartHomeApi.Api_Source_Code.Models.Thermostat", "Thermostat")
                        .WithMany()
                        .HasForeignKey("Thermostat_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Thermostat");
                });
#pragma warning restore 612, 618
        }
    }
}
