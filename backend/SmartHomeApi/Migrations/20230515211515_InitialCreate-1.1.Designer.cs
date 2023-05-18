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
    [Migration("20230515211515_InitialCreate-1.1")]
    partial class InitialCreate11
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
                    b.Property<Guid>("Account_id")
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

                    b.HasKey("Account_id");

                    b.ToTable("accounts");
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

                    b.ToTable("thermostat_sensors");
                });
#pragma warning restore 612, 618
        }
    }
}
