
using MySql.Data;
using MySqlConnector;
using SmartHomeApi.Api_Source_Code.Models.UserModel;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
namespace SmartHomeApi.Api_Source_Code.Repositories.UserRepo;
public class AccountRepo : IRepository<Account>
{
    private readonly PasswordHasher passwordHasher;
    public AccountRepo(){
        this.passwordHasher = new PasswordHasher();
    }

    private MySqlConnection GetConnection()
    {
      return new MySqlConnection("server=localhost;port=3306;database=smart_home_db;user=root;password=password");
    }


    public Tuple<bool,int> Insert(Account entry)
    {
        
        using (MySqlConnection conn = GetConnection())
        {
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(@"Insert Into accounts (role,username,password) VALUES(@role,@username,@password)", conn);


            string hashedPassword = this.passwordHasher.HashPassword(entry.Password);

            cmd.Parameters.Add("@role", MySqlDbType.VarChar).Value = entry.Role;
            cmd.Parameters.Add("@username",  MySqlDbType.VarChar).Value = entry.UserName;
            cmd.Parameters.Add("@password",  MySqlDbType.VarChar).Value = hashedPassword;


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
    public bool Update(Account entry){
        using (MySqlConnection conn = GetConnection())
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"UPDATE accounts SET role = \"{entry.Role}\", username = {entry.UserName}, password = {entry.Password} WHERE actuator_id = {entry.Id}",conn);
            int rowsAffected = cmd.ExecuteNonQuery();   
            conn.Close();
            return rowsAffected > 0;
        }
    }
    public bool Delete(int id){
        using (MySqlConnection conn = GetConnection())
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"DELETE FROM accounts WHERE account_id = {id}", conn);
            int rowsAffected = cmd.ExecuteNonQuery();  
            conn.Close();
            return rowsAffected > 0;
        }
    }
    public IEnumerable<Account> GetAll(){
        List<Account> list = new List<Account>();
        using (MySqlConnection conn = GetConnection())
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT account_id,username,role FROM accounts", conn);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new Account(
                        reader.GetInt32("account_id"),
                        reader.GetString("role"),
                        reader.GetString("username"),
                        ""
                    ));
                }
                reader.Close();
            }
            conn.Close();
        }
        return list;
    }
    public Account FindByCondition(Func<string,bool> condition){
        return new Account(0,"","","");
    }


    public Tuple<PasswordVerificationResult,Account> Login(Login login){
       
        List<Account> list = new List<Account>();
        using (MySqlConnection conn = GetConnection())
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM accounts WHERE username =  \"{login.UserName}\"", conn);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string password = reader.GetString("password");
                    PasswordVerificationResult verificationResult = this.passwordHasher.VerifyHashedPassword(password,login.Password);
                    if(verificationResult == PasswordVerificationResult.Success || verificationResult == PasswordVerificationResult.SuccessRehashNeeded){
                       return Tuple.Create(verificationResult, new Account(
                        reader.GetInt32("account_id"),
                        reader.GetString("role"),
                        reader.GetString("username"),
                        "")); 
                    }
                    
                }
                reader.Close();
            }
            conn.Close();
        }
        return Tuple.Create<PasswordVerificationResult,Account>(PasswordVerificationResult.Failed, new Account());
    }
}