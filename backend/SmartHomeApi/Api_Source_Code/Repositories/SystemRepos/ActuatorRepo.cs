
using MySql.Data;
using MySqlConnector;
using SmartHomeApi.Api_Source_Code.Models.SystemModel;
namespace SmartHomeApi.Api_Source_Code.Repositories.SystemRepo;
public class ActuatorRepo : IRepository<Actuator>
{
    public ActuatorRepo(){}

    private MySqlConnection GetConnection()
    {
      return new MySqlConnection("server=localhost;port=3306;database=smart_home_db;user=root;password=password");
    }


    public Tuple<bool,int> Insert(Actuator entry){
        using (MySqlConnection conn = GetConnection())
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"INSERT INTO actuators (name,target_temperature, account_id) VALUES (\"{entry.Name}\", {entry.TargetTemperature}, {entry.AccountId})", conn);
            int rowsAffected = cmd.ExecuteNonQuery();   
              int index = 0;  
             if(rowsAffected > 0 && int.TryParse($"{cmd.LastInsertedId}",out index)){
                conn.Close();
                return Tuple.Create(true,index);
            }

            conn.Close();
            return Tuple.Create(false,index);
        }    
    }
    public bool Update(Actuator entry){
        using (MySqlConnection conn = GetConnection())
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"UPDATE actuators SET name = \"{entry.Name}\", target_temperature = {entry.TargetTemperature} WHERE actuator_id = {entry.Id}",conn);
            int rowsAffected = cmd.ExecuteNonQuery();   
            conn.Close();
            return rowsAffected > 0;
        }  
    }
    public bool Delete(int id){
        using (MySqlConnection conn = GetConnection())
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"DELETE FROM actuators WHERE actuator_id = {id}", conn);
            int rowsAffected = cmd.ExecuteNonQuery();    
            conn.Close();
            return rowsAffected > 0;
        }
    }
    public IEnumerable<Actuator> GetAll(){
        List<Actuator> list = new List<Actuator>();
        using (MySqlConnection conn = GetConnection())
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM actuators", conn);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new Actuator(
                        reader.GetInt32("actuator_id"),
                        reader.GetString("name"),
                        reader.GetInt32("target_temperature"),
                        reader.GetInt32("account_id")
                    ));
                }
                reader.Close();
            }
            conn.Close();
        }
        return list;
    }
    public IEnumerable<Actuator> GetById(int accountId){
        List<Actuator> actuators = new List<Actuator>();
        using (MySqlConnection conn = GetConnection())
        {
            string connString = $"SELECT * from actuators WHERE account_id = {accountId}";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(connString, conn);
            using(var reader = cmd.ExecuteReader()){
                while(reader.Read()){           
                 actuators.Add(new Actuator(
                        reader.GetInt32("actuator_id"),
                        reader.GetString("name"),
                        reader.GetInt32("target_temperature"),
                        reader.GetInt32("account_id")
                    ));     
                }
                reader.Close();
            }   
            conn.Close();
            return actuators;
        }
    }

    public Actuator FindByCondition(Func<string,bool> condition){
        return new Actuator(0,"",0,0);
    }
}