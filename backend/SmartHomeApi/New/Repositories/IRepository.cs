
using MySql.Data.MySqlClient;
using System.Collections;
namespace SmartHomeApi.New.Repositories;
public interface IRepository<T>
{
    void Insert(T entry);
    void Update(T entry);
    void Delete(T entry);
    IEnumerable<T> GetAll();
    T FindByCondition(Func<string,bool> condition);
    
}