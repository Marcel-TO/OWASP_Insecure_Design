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
    public DbSet<ThermostatActuator> ThermostatsAcutatos{get;set;}

    public DbSet<SmartJalousine> Jalousines{get;set;}
    public DbSet<JalousineSensor> JalousineSensors{get;set;}
    public DbSet<JalousineActuator> JalousineActuators{get;set;}

     public DbSet<SmartBulb> SmartBulbs{get;set;}
    public DbSet<BulbSensor> BulbSensors{get;set;}
    public DbSet<BulbActuator> BulbActuators{get;set;}
     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>()
            .Property(b => b.Account_Id);
    }
 }