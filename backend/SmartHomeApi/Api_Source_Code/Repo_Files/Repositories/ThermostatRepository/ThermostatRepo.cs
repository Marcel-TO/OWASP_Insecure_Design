
using Microsoft.EntityFrameworkCore;

using MySql.Data;
using MySqlConnector;

using SmartHomeApi.Api_Source_Code.Models;
using SmartHomeApi.Api_Source_Code.Contexts;

namespace SmartHomeApi.Api_Source_Code.Repositories;
public class ThermostatRepo : IRepository<Thermostat,string>
{
    private SHDbContext context;
    private PasswordHasher passwordHasher;
    public ThermostatRepo(SHDbContext context){
        this.context = context;
        this.passwordHasher = new PasswordHasher();
    }


    public IEnumerable<Thermostat> GetAll()
    {     
        var thermostats = this.context.Thermostats.ToList();   
        foreach(var t in thermostats)
        {
            this.context.Entry(t).Collection("Sensors").Load();
            foreach(var sensor in t.Sensors)
            {
                sensor.Thermostat = null;
            }
            this.context.Entry(t).Collection("Actuators").Load();
            foreach(var actuator in t.Actuators)
            {
                actuator.Thermostat = null;
            }
        }  
        return thermostats;
    }


    public Thermostat GetById(string id)
    {     
        var thermostat = this.context.Thermostats.Where(t=> t.Thermostat_Id == id).First(); 
         
            this.context.Entry(thermostat).Collection("Sensors").Load();
            foreach(var sensor in thermostat.Sensors)
            {
                sensor.Thermostat = null;
            }
            this.context.Entry(thermostat).Collection("Actuators").Load();
            foreach(var sensor in thermostat.Actuators)
            {
                sensor.Thermostat = null;
            }
        
        
        return thermostat;
    }

    public Tuple<bool,string> Insert(Thermostat entry)
    {
        
        var parent = context.Accounts
                       .Where(acc => entry.Acc_Id == acc.Account_Id.ToString())
                       .Include(acc => acc.Thermostats)
                       .FirstOrDefault();
  
        if(parent is not null)
        { 
            this.context.Entry(parent).State = EntityState.Modified;
            this.context.Entry(parent).Collection("Thermostats").Load();
            var thermostat =  new Thermostat(Guid.NewGuid().ToString(),parent.Account_Id.ToString());
            thermostat.Sensors = entry.Sensors;
            thermostat.Actuators = entry.Actuators;
            parent.Thermostats.Add(thermostat);
            this.Save();
        
            return Tuple.Create(true, thermostat.Thermostat_Id);
        }

      return Tuple.Create(false, string.Empty);
    }
    
    public bool Update(Thermostat entry)
    {
       return false;
    }

    public bool Delete(string id)
    {  
        try
        {
           
            var parent = this.context.Thermostats
                       .Where(b => id == b.Thermostat_Id)
                       .Include(b => b.Sensors)
                       .FirstOrDefault();
  
            
            if(parent is not null)
            {
                this.context.Entry(parent).State = EntityState.Modified;

                this.context.Entry(parent).Collection("Sensors").Load();
                this.context.RemoveRange(parent.Sensors);

                this.context.Entry(parent).Collection("Actuators").Load();
                this.context.RemoveRange(parent.Actuators);

                this.context.Thermostats.Remove(parent);
                this.context.SaveChanges();   
                return true;        
            }
            return false;
            
        }
        catch(DbUpdateConcurrencyException ex){
            ex.Entries.Single().Reload();
            this.Save();
            return false;
        }   
    }
   
    public void Save()
    {
        this.context.SaveChanges();   
    }
    
}