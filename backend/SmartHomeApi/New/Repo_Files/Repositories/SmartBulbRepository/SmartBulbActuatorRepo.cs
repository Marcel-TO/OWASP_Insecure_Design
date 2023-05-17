
using Microsoft.EntityFrameworkCore;

using MySql.Data;
using MySqlConnector;

using SmartHomeApi.New.Models;
using SmartHomeApi.New.Contexts;

namespace SmartHomeApi.New.Repositories;
public class SmartBulbActuatorRepo : IRepository<BulbActuator, Guid>
{
    private SHDbContext context;
    private ILogger logger;
    public SmartBulbActuatorRepo(ILogger logger, SHDbContext context){
        this.context = context;
        this.logger = logger;
    }


    public IEnumerable<BulbActuator> GetAll()
    {     
        var Actuators = this.context.BulbActuators.ToList();      
        return Actuators;
    }

    public BulbActuator GetById(Guid id)
    {     
        var actuator = this.context.BulbActuators.ToList().Where(t=> t.Actuator_Id == id).First();     
        return actuator;
    }

    public bool Insert(BulbActuator entry)
    {
       
        var parent = context.SmartBulbs
                       .Where(b => entry.Bulb_Id == b.Smartbulb_Id)
                       .Include(b => b.Actuators)
                       .FirstOrDefault();
  
        if(parent is not null)
        {
            this.context.Entry(parent).State = EntityState.Modified;
            this.context.Entry(parent).Collection("Actuators").Load();
            
            parent.Actuators.Add(new BulbActuator(Guid.NewGuid(),entry.Name,entry.Status,entry.Target_Brightness,
            entry.Sensor_Id,entry.Bulb_Id));
            this.Save();
    
        return true;
        }

        
        return false;
    }
    
    public bool Update(BulbActuator entry)
    {
        try
        {
            var actuator = this.context.BulbActuators.Where(b => entry.Actuator_Id == b.Actuator_Id)
                       .FirstOrDefault();
            if(actuator is not null)
            {
                this.context.BulbActuators.Attach(actuator);
                this.context.Entry(actuator).Property(e => e.Name).IsModified = true;
                actuator.Name = entry.Name;
                this.context.Entry(actuator).Property(e => e.Status).IsModified = true;
                actuator.Status = entry.Status;
                this.context.Entry(actuator).Property(e => e.Target_Brightness).IsModified = true;
                actuator.Target_Brightness = entry.Target_Brightness;
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
            var actuator = this.context.BulbActuators
                       .Where(b => id == b.Actuator_Id)
                       .FirstOrDefault();

            
            if (actuator is not null)
            {
                this.context.BulbActuators.Remove(actuator);
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