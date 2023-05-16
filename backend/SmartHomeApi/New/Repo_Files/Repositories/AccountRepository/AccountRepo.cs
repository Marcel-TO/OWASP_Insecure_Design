
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MySql.Data;
using MySqlConnector;

using SmartHomeApi.New.Models;
using SmartHomeApi.New.Contexts;

namespace SmartHomeApi.New.Repositories;
public class AccountRepo : IRepository<Account, Guid>
{
    private SHDbContext context;
    private PasswordHasher passwordHasher;
    public AccountRepo(SHDbContext context){
        this.context = context;
        this.passwordHasher = new PasswordHasher();
    }


    public IEnumerable<Account> GetAll()
    {     
        var accounts = this.context.Accounts.ToList();      
        return accounts;
    }

    public bool Insert(Account entry)
    {
       entry.Password = this.passwordHasher.HashPassword(entry.Password);
       this.context.Accounts.Add(entry);
       this.Save();
       return true;
    }
    
    public bool Update(Account entry)
    {
        try
        {
            this.context.Accounts.Attach(entry);
            this.context.Entry(entry).Property(e => e.UserName).IsModified = true;
            this.context.Entry(entry).Property(e => e.Role).IsModified = true;
            this.Save();  
            return true;        
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
            this.context.Accounts.Remove(new Account(id,"","",""));
            this.Save();   
            return true;        
        }
        catch(DbUpdateConcurrencyException ex){
            ex.Entries.Single().Reload();
            this.Save();
            return false;
        }   
    }

    public Tuple<bool,Guid> Login(Login login)
    {
        var user = this.context.Accounts.ToList().Where(acc => acc.UserName == login.UserName && 
        this.passwordHasher.VerifyHashedPassword(acc.Password, login.Password) == PasswordVerificationResult.Success).First();
        
        if(user == null)
            return Tuple.Create(false,Guid.Empty);
        
        return Tuple.Create(true,user.Account_Id);
    }
   
    public void Save()
    {
        this.context.SaveChanges();   
    }
    
}