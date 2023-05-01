namespace SmartHomeApi.Api_Source_Code.Models;
public class User{
    public string Role{get;set;}
    public string UserName{get;set;}
    public User(string role, string userName){
        this.Role = role;
        this.UserName = userName;
    }
}