using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySQL.Data.EntityFrameworkCore;
using SmartHomeApi.New.Models;

namespace SmartHomeApi.New.Contexts;
 public class SHDbContext : DbContext
 {
    
    public SHDbContext(DbContextOptions options):base(options){ }

    public DbSet<Account> Accounts{get;set;}

    public DbSet<Thermostat> Thermostats{get;set;}
    public DbSet<ThermostatSensor> ThermostatSensors{get;set;}
    public DbSet<ThermostatActuator> ThermostatActuators{get;set;}

    public DbSet<SmartJalousine> SmartJalousines{get;set;}
    public DbSet<JalousineSensor> JalousineSensors{get;set;}
    public DbSet<JalousineActuator> JalousineActuators{get;set;}

    public DbSet<SmartBulb> SmartBulbs{get;set;}
    public DbSet<BulbSensor> BulbSensors{get;set;}
    public DbSet<BulbActuator> BulbActuators{get;set;}
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
      modelBuilder.Entity<Account>()
            .HasMany(e => e.SmartBulbs)
            .WithOne(e => e.Account)
            .HasForeignKey(e => e.Acc_Id)
            .HasPrincipalKey(e => e.Account_Id);

            modelBuilder.Entity<Account>()
            .HasMany(e => e.Thermostats)
            .WithOne(e => e.Account)
            .HasForeignKey(e => e.Acc_Id)
            .HasPrincipalKey(e => e.Account_Id);

            modelBuilder.Entity<Account>()
            .HasMany(e => e.SmartJalousines)
            .WithOne(e => e.Account)
            .HasForeignKey(e => e.Acc_Id)
            .HasPrincipalKey(e => e.Account_Id);

             modelBuilder.Entity<Thermostat>()
            .HasMany(e => e.Sensors)
            .WithOne(e => e.Thermostat)
            .HasForeignKey(e => e.Therm_Id)
            .HasPrincipalKey(e => e.Thermostat_Id);

            modelBuilder.Entity<Thermostat>()
            .HasMany(e => e.Actuators)
            .WithOne(e => e.Thermostat)
            .HasForeignKey(e => e.Therm_Id)
            .HasPrincipalKey(e => e.Thermostat_Id);


           modelBuilder.Entity<SmartBulb>()
            .HasMany(e => e.Sensors)
            .WithOne(e => e.SmartBulb)
            .HasForeignKey(e => e.Bulb_Id)
            .HasPrincipalKey(e => e.Smartbulb_Id);

            modelBuilder.Entity<SmartBulb>()
            .HasMany(e => e.Actuators)
            .WithOne(e => e.SmartBulb)
            .HasForeignKey(e => e.Bulb_Id)
            .HasPrincipalKey(e => e.Smartbulb_Id);


            modelBuilder.Entity<SmartJalousine>()
            .HasMany(e => e.Sensors)
            .WithOne(e => e.SmartJalousine)
            .HasForeignKey(e => e.Jal_Id)
            .HasPrincipalKey(e => e.Jalousine_Id);

            modelBuilder.Entity<SmartJalousine>()
            .HasMany(e => e.Actuators)
            .WithOne(e => e.SmartJalousine)
            .HasForeignKey(e => e.Jal_Id)
            .HasPrincipalKey(e => e.Jalousine_Id);

            
    }
 }