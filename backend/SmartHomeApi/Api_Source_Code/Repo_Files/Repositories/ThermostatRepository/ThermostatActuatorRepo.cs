
using Microsoft.EntityFrameworkCore;

using MySql.Data;
using MySqlConnector;

using SmartHomeApi.Api_Source_Code.Models;
using SmartHomeApi.Api_Source_Code.Contexts;

namespace SmartHomeApi.Api_Source_Code.Repositories;
public class ThermostatActuatorRepo : IRepository<ThermostatActuator, Guid>
{
    private SHDbContext context;
    public ThermostatActuatorRepo(SHDbContext context){
        this.context = context;
    }


    public IEnumerable<ThermostatActuator> GetAll()
    {     
        var Actuators = this.context.ThermostatActuators.ToList();      
        return Actuators;
    }

    public ThermostatActuator GetById(Guid id)
    {     
        var actuator = this.context.ThermostatActuators.ToList().Where(t=> t.Actuator_Id == id).First();     
        return actuator;
    }

    public Tuple<bool,Guid> Insert(ThermostatActuator entry)
    {
       
        var parent = context.Thermostats
                       .Where(b => entry.Therm_Id == b.Thermostat_Id)
                       .Include(b => b.Actuators)
                       .FirstOrDefault();
  
        if(parent is not null)
        {
            this.context.Entry(parent).State = EntityState.Modified;
            this.context.Entry(parent).Collection("Actuators").Load();
            var actuator = new ThermostatActuator(Guid.NewGuid(),entry.Name,entry.Status,entry.Target_Temperature,
            entry.Actuator_Id,parent.Thermostat_Id);
            parent.Actuators.Add(actuator);
            this.Save();
    
        return Tuple.Create(true, actuator.Actuator_Id);
        }

        
        return Tuple.Create(false, Guid.Empty);
    }
    
    public bool Update(ThermostatActuator entry)
    {
        try
        {
            var actuator = this.context.ThermostatActuators.Where(b => entry.Actuator_Id == b.Actuator_Id)
                       .FirstOrDefault();
            if(actuator is not null)
            {
                this.context.ThermostatActuators.Attach(actuator);
                this.context.Entry(actuator).Property(e => e.Name).IsModified = true;
                actuator.Name = entry.Name;
                this.context.Entry(actuator).Property(e => e.Status).IsModified = true;
                actuator.Status = entry.Status;
                this.context.Entry(actuator).Property(e => e.Target_Temperature).IsModified = true;
                actuator.Target_Temperature = entry.Target_Temperature;
                this.Save(); 
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

    public bool Delete(Guid id)
    {  
        try
        {
            var actuator = this.context.ThermostatActuators
                       .Where(b => id == b.Actuator_Id)
                       .FirstOrDefault();

            
            if (actuator is not null)
            {
                this.context.ThermostatActuators.Remove(actuator);
                this.Save();  
            
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