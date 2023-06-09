
using Microsoft.EntityFrameworkCore;

using MySql.Data;
using MySqlConnector;

using SmartHomeApi.Api_Source_Code.Models;
using SmartHomeApi.Api_Source_Code.Contexts;

namespace SmartHomeApi.Api_Source_Code.Repositories;
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

    public ThermostatSensor GetById(Guid id)
    {     
        var sensor = this.context.ThermostatSensors.ToList().Where(t=> t.Sensor_Id == id).First();     
        return sensor;
    }

    public Tuple<bool,Guid> Insert(ThermostatSensor entry)
    {
        var parent = context.Thermostats
                       .Where(b => entry.Therm_Id == b.Thermostat_Id)
                       .Include(b => b.Sensors)
                       .FirstOrDefault();
  
        if(parent is not null)
        {       
            this.context.Entry(parent).State = EntityState.Modified;
            this.context.Entry(parent).Collection("Sensors").Load();
            var sensor = new ThermostatSensor(Guid.NewGuid(),entry.Name,entry.Status,entry.Temperature,
            entry.Actuator_Id,parent.Thermostat_Id);
            parent.Sensors.Add(sensor);
            this.Save();
        
            return Tuple.Create(true, sensor.Sensor_Id);
        }
        return Tuple.Create(false, Guid.Empty);
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