
using MySql.Data.MySqlClient;
using SmartHomeApi.Api_Source_Code.Models;
namespace SmartHomeApi.Api_Source_Code.Repositories;
public class AccountRepo
{
    public AccountRepo(){}

    private MySqlConnection GetConnection()
    {
      return new MySqlConnection("server=localhost;port=3306;database=smart_home_db;user=root;password=password");
    }


    public List<User> GetUserByLogin(Login login){
        List<User> list = new List<User>();
        using (MySqlConnection conn = GetConnection())
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT role, username FROM accounts WHERE username =  \"{login.UserName}\" AND password =  \"{login.Password}\"", conn);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new User(
                        reader.GetString("role"),
                        reader.GetString("username")
                    ));
                }
            }
        }
        return list;
    }
}