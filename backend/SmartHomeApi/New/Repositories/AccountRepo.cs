
using MySql.Data;
using MySqlConnector;
using SmartHomeApi.New.Models;
using SmartHomeApi.New.Contexts;
namespace SmartHomeApi.New.Repositories;
public class AccountRepo : IAccountRepo
{
    SHDbContext context;
    public AccountRepo(SHDbContext context){
        this.context = context;
    }


    public IEnumerable<Account> GetAll()
    {       
        return this.context.Accounts.ToList();;
    }

    public void Insert(Account entry){
       
        
    }
    public void Update(Account entry){

    }
    public void Delete(Account entry){
        
    }
   
    public Account FindByCondition(Func<string,bool> condition){
        return new Account(0,"","","");
    }


    
}