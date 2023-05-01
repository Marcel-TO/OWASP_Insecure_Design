
using MySql.Data.MySqlClient;
namespace SmartHomeApi.Api_Source_Code.Repositories;
public interface IRepository<T>
{
    public void Insert(T entry);
    public void Update(T entry);
    public void Delete(T entry);
    public void GetAll();
    public void FindByCondition(Func<T,bool> condition);
    
}