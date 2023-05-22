
using Microsoft.EntityFrameworkCore;

using MySql.Data;
using MySqlConnector;

using SmartHomeApi.Api_Source_Code.Models;
using SmartHomeApi.Api_Source_Code.Contexts;

namespace SmartHomeApi.Api_Source_Code.Repositories;
public class BulbSensorRepo : IRepository<BulbSensor, string>
{
    private SHDbContext context;
    public BulbSensorRepo(SHDbContext context){
        this.context = context;
    }


    public IEnumerable<BulbSensor> GetAll()
    {     
        var sensors = this.context.BulbSensors.ToList();      
        return sensors;
    }

    public BulbSensor GetById(string id)
    {     
        var sensor = this.context.BulbSensors.ToList().Where(t=> t.Sensor_Id == id).First();     
        return sensor;
    }

    public Tuple<bool,string> Insert(BulbSensor entry)
    {
        
        var parent = context.SmartBulbs
                       .Where(b => entry.Bulb_Id == b.Smartbulb_Id)
                       .Include(b => b.Sensors)
                       .FirstOrDefault();
  
        if(parent is not null)
        {
            this.context.Entry(parent).State = EntityState.Modified;
            this.context.Entry(parent).Collection("Sensors").Load();
            var sensor = new BulbSensor(Guid.NewGuid().ToString(),entry.Name,entry.Status,entry.Brightness,
            entry.Actuator_Id,parent.Smartbulb_Id);
            parent.Sensors.Add(sensor);
            this.Save();
        
            return Tuple.Create(true, sensor.Sensor_Id);
        }
        return Tuple.Create(false, string.Empty);
    }
    
    public bool Update(BulbSensor entry)
    {
        try
        {
            var sensor = this.context.BulbSensors.Where(b => entry.Sensor_Id == b.Sensor_Id)
                       .FirstOrDefault();
            if(sensor is not null)
            {
                this.context.BulbSensors.Attach(sensor);
                this.context.Entry(sensor).Property(e => e.Name).IsModified = true;
                sensor.Name = entry.Name;
                this.context.Entry(sensor).Property(e => e.Status).IsModified = true;
                sensor.Status = entry.Status;
                this.context.Entry(sensor).Property(e => e.Brightness).IsModified = true;
                sensor.Brightness = entry.Brightness;
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

    public bool Delete(string id)
    {  
        try
        {
            var sensor = this.context.BulbSensors
                       .Where(b => id == b.Sensor_Id)
                       .FirstOrDefault();

            
            if (sensor is not null)
            {
                this.context.BulbSensors.Remove(sensor);
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