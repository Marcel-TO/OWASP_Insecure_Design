
using Microsoft.EntityFrameworkCore;

using MySql.Data;
using MySqlConnector;

using SmartHomeApi.New.Models;
using SmartHomeApi.New.Contexts;

namespace SmartHomeApi.New.Repositories;
public class ThermostatSensorRepo : IRepository<ThermostatSensor, Guid>
{
    private SHDbContext context;
    public ThermostatSensorRepo(SHDbContext context){
        this.context = context;
    }


    public IEnumerable<ThermostatSensor> GetAll()
    {     
        var sensors = this.context.ThermostatSensors.ToList();      
        return sensors;
    }

    public bool Insert(ThermostatSensor entry)
    {
      if(this.context.Thermostats.Any(t => t.Thermostat_Id == entry.Thermostat_Id)){
        this.context.ThermostatSensors.Add(entry);
        this.Save();
        return true;
      }
      else{
        return false;
      }  
    }
    
    public bool Update(ThermostatSensor entry)
    {
        try
        {
            this.context.ThermostatSensors.Attach(entry);
            this.context.Entry(entry).Property(e => e.Name).IsModified = true;
            this.context.Entry(entry).Property(e => e.Status).IsModified = true;
            this.context.Entry(entry).Property(e => e.Temperature).IsModified = true;
            this.Save();  
            return true;        
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
            this.context.ThermostatSensors.Remove(new ThermostatSensor(id,"","",0,Guid.Empty,Guid.Empty));
            this.Save();   
            return true;        
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