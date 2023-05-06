
using MySql.Data;
using MySqlConnector;
using SmartHomeApi.Api_Source_Code.Models.SystemModel;
namespace SmartHomeApi.Api_Source_Code.Repositories.SystemRepo;
public class SensorRepo : IRepository<Sensor>
{
    public SensorRepo(){}

    private MySqlConnection GetConnection()
    {
      return new MySqlConnection("server=localhost;port=3306;database=smart_home_db;user=root;password=password");
    }


    public Tuple<bool,int> Insert(Sensor entry){
        using (MySqlConnection conn = GetConnection())
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"INSERT INTO sensors (name,temp,status, account_id) VALUES (\"{entry.Name}\", {entry.Temperature}, \"{entry.Status}\", {entry.AccountId})", conn);
            int rowsAffected = cmd.ExecuteNonQuery();   
             int index = 0;  
             if(rowsAffected > 0 && int.TryParse($"{cmd.LastInsertedId}",out index)){
                conn.Close();
                return Tuple.Create(true,index);
            }

            conn.Close();
            return Tuple.Create(false,index);
            // MySqlCommand cmd = _conn.CreateCommand();
            //cmd.CommandText = sqlCommandString;
            //cmd.ExecuteNonQuery();
            //long imageId = cmd.LastInsertedId;
        }    
    }
    public bool Update(Sensor entry){
        using (MySqlConnection conn = GetConnection())
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"UPDATE sensors SET name = \"{entry.Name}\", temp = {entry.Temperature}, status = \"{entry.Status}\", WHERE actuator_id = {entry.Id}",conn);
            int rowsAffected = cmd.ExecuteNonQuery();   
            conn.Close();
            return rowsAffected > 0;
        }  
    }
    public bool Delete(int id){
        using (MySqlConnection conn = GetConnection())
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"DELETE FROM sensors WHERE actuator_id = {id}", conn);
            int rowsAffected = cmd.ExecuteNonQuery();    
            conn.Close();
            return rowsAffected > 0;
        }
    }
    public IEnumerable<Sensor> GetAll(){
        List<Sensor> list = new List<Sensor>();
        using (MySqlConnection conn = GetConnection())
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM sensors", conn);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new Sensor(
                        reader.GetInt32("sensor_id"),
                        reader.GetString("name"),
                        reader.GetInt32("temp"),
                        reader.GetString("status"),
                        reader.GetInt32("system_id")
                    ));
                }
                reader.Close();
            }
            conn.Close();
        }
        return list;
    }

    public IEnumerable<Sensor> GetById(int accountId){
        List<Sensor> sensors = new List<Sensor>();
        using (MySqlConnection conn = GetConnection())
        {
            string connString = $"SELECT * from sensors WHERE account_id = {accountId}";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(connString, conn);
            using(var reader = cmd.ExecuteReader()){
                while(reader.Read()){           
                 sensors.Add(new Sensor(
                        reader.GetInt32("sensor_id"),
                        reader.GetString("name"),
                        reader.GetInt32("temp"),
                        reader.GetString("status"),
                        reader.GetInt32("account_id")
                    ));     
                }
                reader.Close();
            }   
            conn.Close();
            return sensors;
        }
    }
    

    

    public Sensor FindByCondition(Func<string,bool> condition){
        return new Sensor(0,"",0, "",0);
    }
}