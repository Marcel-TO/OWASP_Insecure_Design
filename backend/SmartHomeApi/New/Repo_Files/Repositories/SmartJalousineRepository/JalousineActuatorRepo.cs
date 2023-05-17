
using Microsoft.EntityFrameworkCore;

using MySql.Data;
using MySqlConnector;

using SmartHomeApi.New.Models;
using SmartHomeApi.New.Contexts;

namespace SmartHomeApi.New.Repositories;
public class JalousineActuatorRepo : IRepository<JalousineActuator, Guid>
{
    private SHDbContext context;
    public JalousineActuatorRepo(SHDbContext context){
        this.context = context;
    }


    public IEnumerable<JalousineActuator> GetAll()
    {     
        var actuators = this.context.JalousineActuators.ToList();      
        return actuators;
    }

    public JalousineActuator GetById(Guid id)
    {     
        var actuator = this.context.JalousineActuators.ToList().Where(t=> t.Actuator_Id == id).First();     
        return actuator;
    }

    public bool Insert(JalousineActuator entry)
    {
       
        var parent = context.SmartJalousines
                       .Where(b => entry.Jal_Id == b.Jalousine_Id)
                       .Include(b => b.Actuators)
                       .FirstOrDefault();
  
        if(parent is not null)
        {
            this.context.Entry(parent).State = EntityState.Modified;
            this.context.Entry(parent).Collection("Actuators").Load();
            
            parent.Actuators.Add(new JalousineActuator(Guid.NewGuid(),entry.Name,entry.Status,entry.Target_State,
            entry.Actuator_Id,parent.Jalousine_Id));
            this.Save();
    
        return true;
        }

        
        return false;
    }
    
    public bool Update(JalousineActuator entry)
    {
        try
        {
            var actuator = this.context.JalousineActuators.Where(b => entry.Actuator_Id == b.Actuator_Id)
                       .FirstOrDefault();
            if(actuator is not null)
            {
                this.context.JalousineActuators.Attach(actuator);
                this.context.Entry(actuator).Property(e => e.Name).IsModified = true;
                actuator.Name = entry.Name;
                this.context.Entry(actuator).Property(e => e.Status).IsModified = true;
                actuator.Status = entry.Status;
                this.context.Entry(actuator).Property(e => e.Target_State).IsModified = true;
                actuator.Target_State = entry.Target_State;
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
            var actuator = this.context.JalousineActuators
                       .Where(b => id == b.Actuator_Id)
                       .FirstOrDefault();

            
            if (actuator is not null)
            {
                this.context.JalousineActuators.Remove(actuator);
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