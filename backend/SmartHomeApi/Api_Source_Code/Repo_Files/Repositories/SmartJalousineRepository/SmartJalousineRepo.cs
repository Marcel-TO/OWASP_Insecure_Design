
using Microsoft.EntityFrameworkCore;

using MySql.Data;
using MySqlConnector;

using SmartHomeApi.Api_Source_Code.Models;
using SmartHomeApi.Api_Source_Code.Contexts;

namespace SmartHomeApi.Api_Source_Code.Repositories;
public class SmartJalousineRepo : IRepository<SmartJalousine,Guid>
{
    private SHDbContext context;
    public SmartJalousineRepo(SHDbContext context){
        this.context = context;
    }


    public IEnumerable<SmartJalousine> GetAll()
    {     
        var smartJalousines = this.context.SmartJalousines.ToList();   
        foreach(var t in smartJalousines)
        {
            this.context.Entry(t).Collection("Sensors").Load();
            foreach(var sensor in t.Sensors)
            {
                sensor.SmartJalousine = null;
            }
            this.context.Entry(t).Collection("Actuators").Load();
            foreach(var actuator in t.Actuators)
            {
                actuator.SmartJalousine = null;
            }
        }  
        return smartJalousines;
    }


    public SmartJalousine GetById(Guid id)
    {     
        var smartJalousine = this.context.SmartJalousines.Where(t=> t.Jalousine_Id == id).First(); 
         

        if(smartJalousine is not null)
        {
            this.context.Entry(smartJalousine).Collection("Sensors").Load();
            foreach(var sensor in smartJalousine.Sensors)
            {
                sensor.SmartJalousine = null;
            }
            this.context.Entry(smartJalousine).Collection("Actuators").Load();
            foreach(var sensor in smartJalousine.Actuators)
            {
                sensor.SmartJalousine = null;
            }
            return smartJalousine;
        }
            
        return new SmartJalousine(Guid.Empty,Guid.Empty);
        
        
    }

    public Tuple<bool,Guid> Insert(SmartJalousine entry)
    {
        
        var parent = context.Accounts
                       .Where(acc => entry.Acc_Id == acc.Account_Id)
                       .Include(acc => acc.SmartJalousines)
                       .FirstOrDefault();
  
        if(parent is not null)
        { 
            this.context.Entry(parent).State = EntityState.Modified;
            this.context.Entry(parent).Collection("SmartJalousines").Load();
            var smartJalousine =  new SmartJalousine(Guid.NewGuid(),parent.Account_Id);
            smartJalousine.Sensors = entry.Sensors;
            smartJalousine.Actuators = entry.Actuators;
            parent.SmartJalousines.Add(smartJalousine);
            this.Save();
        
           return Tuple.Create(true, smartJalousine.Jalousine_Id);
        }

        return Tuple.Create(false, Guid.Empty);
    }
    
    public bool Update(SmartJalousine entry)
    {
       return false;
    }

    public bool Delete(Guid id)
    {  
        try
        { 
            var parent = this.context.SmartJalousines
                       .Where(b => id == b.Jalousine_Id)
                       .Include(b => b.Sensors)
                       .FirstOrDefault();
  
            
            if(parent is not null)
            {
                this.context.Entry(parent).State = EntityState.Modified;

                this.context.Entry(parent).Collection("Sensors").Load();
                this.context.RemoveRange(parent.Sensors);

                this.context.Entry(parent).Collection("Actuators").Load();
                this.context.RemoveRange(parent.Actuators);

                this.context.SmartJalousines.Remove(parent);
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