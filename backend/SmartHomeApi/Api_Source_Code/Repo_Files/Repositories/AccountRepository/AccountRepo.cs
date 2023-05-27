
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MySql.Data;
using MySqlConnector;

using SmartHomeApi.Api_Source_Code.Models;
using SmartHomeApi.Api_Source_Code.Contexts;

namespace SmartHomeApi.Api_Source_Code.Repositories;
public class AccountRepo : IRepository<DT_Account, Guid>
{
    private SHDbContext context;
    private PasswordHasher passwordHasher;
    public AccountRepo(SHDbContext context){
        this.context = context;
        this.passwordHasher = new PasswordHasher();
    }


    public IEnumerable<DT_Account> GetAll()
    {     
        
        var accounts = this.context.Accounts.ToList();  
        var mappedAccounts = Mapper.MapAccounts(accounts);
        /*foreach(var acc in accounts)
        {
            this.context.Entry(acc).Collection("Thermostats").Load();  
            foreach(var t in acc.Thermostats)
            {
                this.context.Entry(t).Collection("Sensors").Load(); 
                this.context.Entry(t).Collection("Actuators").Load();
            }
            this.context.Entry(acc).Collection("SmartBulbs").Load();   
            foreach(var s in acc.SmartBulbs)
            {
                this.context.Entry(s).Collection("Sensors").Load(); 
                this.context.Entry(s).Collection("Actuators").Load();
            }
            this.context.Entry(acc).Collection("SmartJalousines").Load(); 
            foreach(var j in acc.SmartJalousines)
            {
                this.context.Entry(j).Collection("Sensors").Load(); 
                this.context.Entry(j).Collection("Actuators").Load();
            }   
        }*/
        if(mappedAccounts is not null)
        {
            return mappedAccounts;
        }
        return new List<DT_Account>();
    }

    public DT_Account GetById(Guid id)
    {     
        var accounts = this.context.Accounts.Where(acc => acc.Account_Id == id).ToList();  
        var mappedAccounts = Mapper.MapAccounts(accounts);
        if(mappedAccounts is not null)
        {
            return mappedAccounts.ToList()[0];
        }
        return new DT_Account(Guid.Empty,string.Empty,string.Empty,string.Empty);
    }

    public Tuple<bool,Guid> Insert(DT_Account entry)
    {
       entry.Password = this.passwordHasher.HashPassword(entry.Password);
       entry.Account_Id = Guid.NewGuid();
       Account account = new Account(entry.Account_Id,entry.Role,entry.UserName,entry.Password);
       this.context.Accounts.Add(account);
       this.Save();
    return Tuple.Create(true, entry.Account_Id);
    }
    
    public bool Update(DT_Account entry)
    {
        try
        {
            var account = this.context.Accounts.Find(entry.Account_Id);
            if(account is not null)
            {
                this.context.Accounts.Attach(account);
                this.context.Entry(account).Property(e => e.UserName).IsModified = true;
                this.context.Entry(account).Property(e => e.Role).IsModified = true;
                this.context.Entry(account).Property(e => e.Password).IsModified = true;
                account.UserName = entry.UserName;
                account.Role = entry.Role;
                account.Password = this.passwordHasher.HashPassword(entry.Password);
                this.Save();  
                return true;
            }
            else return false;
                   
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
            var parent = this.context.Accounts.Where(acc => acc.Account_Id == id).FirstOrDefault();
            if(parent is not null)
            {
                this.context.Entry(parent).State = EntityState.Modified;
                this.context.Entry(parent).Collection("Thermostats").Load();
                foreach(var t in parent.Thermostats)
                {
                    this.context.Entry(t).Collection("Sensors").Load();
                    this.context.RemoveRange(t.Sensors);
                    this.context.Entry(t).Collection("Actuators").Load();
                    this.context.RemoveRange(t.Actuators);
                }
                this.context.RemoveRange(parent.Thermostats);
                this.context.Entry(parent).Collection("SmartBulbs").Load();
                foreach(var s in parent.SmartBulbs)
                {
                    this.context.Entry(s).Collection("Sensors").Load();
                    this.context.RemoveRange(s.Sensors);
                    this.context.Entry(s).Collection("Actuators").Load();
                    this.context.RemoveRange(s.Actuators);
                }
                this.context.RemoveRange(parent.SmartBulbs);
                this.context.Entry(parent).Collection("SmartJalousines").Load();
                foreach(var j in parent.SmartJalousines)
                {
                    this.context.Entry(j).Collection("Sensors").Load();
                    this.context.RemoveRange(j.Sensors);
                    this.context.Entry(j).Collection("Actuators").Load();
                    this.context.RemoveRange(j.Actuators);
                }
                this.context.RemoveRange(parent.SmartJalousines);
                this.context.Remove(parent);
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

    public Tuple<bool,Guid> Login(Login login)
    {
        try{
            var user = this.context.Accounts.ToList().Where(acc => acc.UserName == login.UserName && 
            this.passwordHasher.VerifyHashedPassword(acc.Password, login.Password) == PasswordVerificationResult.Success).First();
            return Tuple.Create(true,user.Account_Id);
        }
        catch(Exception)
        {
            return Tuple.Create(false,Guid.Empty);
        }    
        
    }
   
    public void Save()
    {
        this.context.SaveChanges();   
    }
    
}