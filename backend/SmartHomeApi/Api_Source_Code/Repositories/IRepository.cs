
using MySql.Data.MySqlClient;
using System.Collections;
namespace SmartHomeApi.Api_Source_Code.Repositories;
public interface IRepository<T>
{
    Tuple<bool,int> Insert(T entry);
    bool Update(T entry);
    bool Delete(int entry);
    IEnumerable<T> GetAll();
    T FindByCondition(Func<string,bool> condition);
    
}