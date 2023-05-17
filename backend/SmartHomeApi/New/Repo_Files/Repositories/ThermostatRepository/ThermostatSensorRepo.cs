
using Microsoft.EntityFrameworkCore;

using MySql.Data;
using MySqlConnector;

using SmartHomeApi.New.Models;
using SmartHomeApi.New.Contexts;

namespace SmartHomeApi.New.Repositories;
public class ThermostatSensorRepo : IRepository<ThermostatSensor, Guid>
{
    private SHDbContext context;
    private ILogger logger;
    public ThermostatSensorRepo(ILogger logger, SHDbContext context){
        this.context = context;
        this.logger = logger;
    }


    public IEnumerable<ThermostatSensor> GetAll()
    {     
        var sensors = this.context.ThermostatSensors.ToList();      
        return sensors;
    }

    public ThermostatSensor GetById(Guid id)
    {     
        var sensor = this.context.ThermostatSensors.ToList().Where(t=> t.Sensor_Id == id).First();     
        return sensor;
    }

    public bool Insert(ThermostatSensor entry)
    {
        var parent = new Thermostat(Guid.Empty, Guid.Empty);
        var p = context.Thermostats
                       .Where(b => entry.Therm_Id == b.Thermostat_Id)
                       .Include(b => b.Sensors)
                       .FirstOrDefault();
  
        if(p == null){
            return false;
        }
        parent = p;
        this.context.Entry(parent).State = EntityState.Modified;
        this.context.Entry(parent).Collection("Sensors").Load();
        
        parent.Sensors.Add(new ThermostatSensor(Guid.NewGuid(),entry.Name,entry.Status,entry.Temperature,
        entry.Actuator_Id,parent.Thermostat_Id));
        this.Save();
    
        return true;
    }
    
    public bool Update(ThermostatSensor entry)
    {
        try
        {
            var sensor = this.context.ThermostatSensors.Where(b => entry.Sensor_Id == b.Sensor_Id)
                       .FirstOrDefault();
            if(sensor is not null)
            {
                this.context.ThermostatSensors.Attach(sensor);
                this.context.Entry(sensor).Property(e => e.Name).IsModified = true;
                sensor.Name = entry.Name;
                this.context.Entry(sensor).Property(e => e.Status).IsModified = true;
                sensor.Status = entry.Status;
                this.context.Entry(sensor).Property(e => e.Temperature).IsModified = true;
                sensor.Temperature = entry.Temperature;
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
            var sensor = this.context.ThermostatSensors
                       .Where(b => id == b.Sensor_Id)
                       .FirstOrDefault();

            
            if (sensor is not null)
            {
                this.context.ThermostatSensors.Remove(sensor);
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