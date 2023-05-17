
using Microsoft.EntityFrameworkCore;

using MySql.Data;
using MySqlConnector;

using SmartHomeApi.New.Models;
using SmartHomeApi.New.Contexts;

namespace SmartHomeApi.New.Repositories;
public class JalousineSensorRepo : IRepository<JalousineSensor, Guid>
{
    private SHDbContext context;
    public JalousineSensorRepo(SHDbContext context){
        this.context = context;
    }


    public IEnumerable<JalousineSensor> GetAll()
    {     
        var sensors = this.context.JalousineSensors.ToList();      
        return sensors;
    }

    public JalousineSensor GetById(Guid id)
    {     
        var sensor = this.context.JalousineSensors.ToList().Where(t=> t.Sensor_Id == id).First();     
        return sensor;
    }

    public bool Insert(JalousineSensor entry)
    {
        var parent = new SmartJalousine(Guid.Empty, Guid.Empty);
        var p = context.SmartJalousines
                       .Where(b => entry.Jal_Id == b.Jalousine_Id)
                       .Include(b => b.Sensors)
                       .FirstOrDefault();
  
        if(p == null){
            return false;
        }
        parent = p;
        this.context.Entry(parent).State = EntityState.Modified;
        this.context.Entry(parent).Collection("Sensors").Load();
        
        parent.Sensors.Add(new JalousineSensor(Guid.NewGuid(),entry.Name,entry.Status,entry.State,
        entry.Actuator_Id,parent.Jalousine_Id));
        this.Save();
    
        return true;
    }
    
    public bool Update(JalousineSensor entry)
    {
        try
        {
            var sensor = this.context.JalousineSensors.Where(b => entry.Sensor_Id == b.Sensor_Id)
                       .FirstOrDefault();
            if(sensor is not null)
            {
                this.context.JalousineSensors.Attach(sensor);
                this.context.Entry(sensor).Property(e => e.Name).IsModified = true;
                sensor.Name = entry.Name;
                this.context.Entry(sensor).Property(e => e.Status).IsModified = true;
                sensor.Status = entry.Status;
                this.context.Entry(sensor).Property(e => e.State).IsModified = true;
                sensor.State = entry.State;
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
            var sensor = this.context.JalousineSensors
                       .Where(b => id == b.Sensor_Id)
                       .FirstOrDefault();

            
            if (sensor is not null)
            {
                this.context.JalousineSensors.Remove(sensor);
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