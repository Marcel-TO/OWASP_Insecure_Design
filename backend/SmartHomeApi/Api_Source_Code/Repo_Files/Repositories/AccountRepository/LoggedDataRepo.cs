
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MySql.Data;
using MySqlConnector;

using SmartHomeApi.Api_Source_Code.Models;
using SmartHomeApi.Api_Source_Code.Contexts;

namespace SmartHomeApi.Api_Source_Code.Repositories;
public class LoggedDataRepo : IRepository<LoggedData, Guid>
{
    private SHDbContext context;
    public LoggedDataRepo(SHDbContext context){
        this.context = context;
    }


    public IEnumerable<LoggedData> GetAll()
    {      
        var loggedData = this.context.LoggedDatas.ToList();  
      
        if(loggedData is not null)
        {
            return loggedData;
        }
        return new List<LoggedData>();
    }

    public LoggedData GetById(Guid id)
    {     
        var loggedData = this.context.LoggedDatas.Where(log => log.Log_Id == id).FirstOrDefault();  
        if(loggedData is not null)
        {
            return loggedData;
        }
        return new LoggedData(Guid.Empty,Guid.Empty,string.Empty);
    }

    public IEnumerable<LoggedData> GetByAccountId(Guid id)
    {     
        var loggedData = this.context.LoggedDatas.Where(acc => acc.Acc_Id == id).ToList();  
        if(loggedData is not null)
        {
            return loggedData;
        }
        return new List<LoggedData>();
    }

    public Tuple<bool,Guid> Insert(LoggedData entry)
    {
       entry.Log_Id = Guid.NewGuid();
       LoggedData loggedData = new LoggedData(entry.Log_Id,entry.Acc_Id,entry.Data);
       this.context.LoggedDatas.Add(loggedData);
       this.Save();
    return Tuple.Create(true, entry.Log_Id);
    }
    
    public bool Delete(Guid id)
    {  
         try
        {
            var loggedData = this.context.LoggedDatas
                       .Where(b => id == b.Log_Id)
                       .FirstOrDefault();

            
            if (loggedData is not null)
            {
                this.context.LoggedDatas.Remove(loggedData);
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

    public bool Update(LoggedData entry)
    {
        return false;
    }
}