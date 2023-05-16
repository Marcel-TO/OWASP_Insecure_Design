
using Microsoft.EntityFrameworkCore;

using MySql.Data;
using MySqlConnector;

using SmartHomeApi.New.Models;
using SmartHomeApi.New.Contexts;

namespace SmartHomeApi.New.Repositories;
public class ThermostatRepo : IRepository<Thermostat,Guid>
{
    private SHDbContext context;
    private PasswordHasher passwordHasher;
    public ThermostatRepo(SHDbContext context){
        this.context = context;
        this.passwordHasher = new PasswordHasher();
    }


    public IEnumerable<Thermostat> GetAll()
    {     
        var thermostats = this.context.Thermostats.ToList();     
       
        return thermostats;
    }


    public Thermostat GetById(Guid id)
    {     
        var thermostat = this.context.Thermostats.ToList().Where(t=> t.Thermostat_Id == id).First();     
        return thermostat;
    }

    public bool Insert(Thermostat entry)
    {
      this.context.Thermostats.Add(entry);
      this.Save();
      return true;
    }
    
    public bool Update(Thermostat entry)
    {
       return false;
    }

    public bool Delete(Guid id)
    {  
        try
        {
            this.context.Thermostats.Remove(new Thermostat(id,Guid.Empty));
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