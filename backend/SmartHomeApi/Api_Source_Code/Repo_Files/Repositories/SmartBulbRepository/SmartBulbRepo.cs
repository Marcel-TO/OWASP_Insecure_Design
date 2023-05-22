
using Microsoft.EntityFrameworkCore;

using MySql.Data;
using MySqlConnector;

using SmartHomeApi.Api_Source_Code.Models;
using SmartHomeApi.Api_Source_Code.Contexts;

namespace SmartHomeApi.Api_Source_Code.Repositories;
public class SmartBulbRepo : IRepository<SmartBulb,string>
{
    private SHDbContext context;
    public SmartBulbRepo(SHDbContext context){
        this.context = context;
    }


    public IEnumerable<SmartBulb> GetAll()
    {     
        var smartBulbs = this.context.SmartBulbs.ToList();   
        foreach(var t in smartBulbs)
        {
            this.context.Entry(t).Collection("Sensors").Load();
            foreach(var sensor in t.Sensors)
            {
                sensor.SmartBulb = null;
            }
            this.context.Entry(t).Collection("Actuators").Load();
            foreach(var actuator in t.Actuators)
            {
                actuator.SmartBulb = null;
            }
        }  
        return smartBulbs;
    }


    public SmartBulb GetById(string id)
    {     
        var smartBulb = this.context.SmartBulbs.Where(t=> t.Smartbulb_Id == id).First(); 
         
        if(smartBulb is not null)
        {
            this.context.Entry(smartBulb).Collection("Sensors").Load();
            foreach(var sensor in smartBulb.Sensors)
            {
                sensor.SmartBulb = null;
            }
            this.context.Entry(smartBulb).Collection("Actuators").Load();
            foreach(var sensor in smartBulb.Actuators)
            {
                sensor.SmartBulb = null;
            }
             return smartBulb;
        }
        return new SmartBulb(string.Empty,string.Empty);
        
        
       
    }

    public Tuple<bool,string> Insert(SmartBulb entry)
    {
        
        var parent = context.Accounts
                       .Where(acc => entry.Acc_Id == acc.Account_Id.ToString())
                       .Include(acc => acc.SmartBulbs)
                       .FirstOrDefault();
  
        if(parent is not null)
        { 
            this.context.Entry(parent).State = EntityState.Modified;
            this.context.Entry(parent).Collection("SmartBulbs").Load();
            var smartBulb =  new SmartBulb(Guid.NewGuid().ToString(),parent.Account_Id.ToString());
            smartBulb.Sensors = entry.Sensors;
            smartBulb.Actuators = entry.Actuators;
            parent.SmartBulbs.Add(smartBulb);
            this.Save();
        
             return Tuple.Create(true, smartBulb.Smartbulb_Id);
        }

       return Tuple.Create(false, string.Empty);
    }
    
    public bool Update(SmartBulb entry)
    {
       return false;
    }

    public bool Delete(string id)
    {  
        try
        {
           
            var parent = this.context.SmartBulbs
                       .Where(b => id == b.Smartbulb_Id)
                       .Include(b => b.Sensors)
                       .FirstOrDefault();
  
            
            if(parent is not null)
            {
                this.context.Entry(parent).State = EntityState.Modified;

                this.context.Entry(parent).Collection("Sensors").Load();
                this.context.RemoveRange(parent.Sensors);

                this.context.Entry(parent).Collection("Actuators").Load();
                this.context.RemoveRange(parent.Actuators);

                this.context.SmartBulbs.Remove(parent);
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