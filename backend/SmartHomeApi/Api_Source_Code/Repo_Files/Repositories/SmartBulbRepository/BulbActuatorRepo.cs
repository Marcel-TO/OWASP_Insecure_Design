
using Microsoft.EntityFrameworkCore;

using MySql.Data;
using MySqlConnector;

using SmartHomeApi.Api_Source_Code.Models;
using SmartHomeApi.Api_Source_Code.Contexts;

namespace SmartHomeApi.Api_Source_Code.Repositories;
public class BulbActuatorRepo : IRepository<BulbActuator, Guid>
{
    private SHDbContext context;
    public BulbActuatorRepo(SHDbContext context){
        this.context = context;
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

    public Tuple<bool,Guid> Insert(BulbActuator entry)
    {
       
        var parent = context.SmartBulbs
                       .Where(b => entry.Bulb_Id == b.Smartbulb_Id)
                       .Include(b => b.Actuators)
                       .FirstOrDefault();
  
        if(parent is not null)
        {
            this.context.Entry(parent).State = EntityState.Modified;
            this.context.Entry(parent).Collection("Actuators").Load();
            var actuator = new BulbActuator(Guid.NewGuid(),entry.Name,entry.Status,entry.Target_Brightness,
            entry.Sensor_Id,entry.Bulb_Id);
            parent.Actuators.Add(actuator);
            this.Save();
    
            return Tuple.Create(false, actuator.Actuator_Id);
        }

        
         return Tuple.Create(false, Guid.Empty);
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