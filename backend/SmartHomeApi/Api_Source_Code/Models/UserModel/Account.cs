namespace SmartHomeApi.Api_Source_Code.Models.UserModel;
public class Account{
    public int Id{get;set;}
    public string Role{get;set;}
    public string UserName{get;set;}
    public string Password{get;set;}
    public Account(int id, string role, string userName, string password){
        this.Id = id;
        this.Role = role;
        this.UserName = userName;
        this.Password = password;
    }
}