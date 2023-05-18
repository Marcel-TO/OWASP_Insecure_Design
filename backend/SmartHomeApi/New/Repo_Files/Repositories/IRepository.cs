
using MySql.Data.MySqlClient;
using System.Collections;
namespace SmartHomeApi.New.Repositories;
public interface IRepository<T,V>
{
    bool Insert(T entry);
    bool Update(T entry);
    bool Delete(V entry);
    IEnumerable<T> GetAll();
    void Save();
    
}