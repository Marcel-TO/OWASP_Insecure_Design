
using MySql.Data.MySqlClient;
using System.Collections;
namespace SmartHomeApi.Api_Source_Code.Repositories;
public interface IRepository<T,V>
{
    Tuple<bool,string> Insert(T entry);
    bool Update(T entry);
    bool Delete(V entry);
    IEnumerable<T> GetAll();
    void Save();
    
}