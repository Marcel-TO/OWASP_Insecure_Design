namespace SmartHomeApi.Api_Source_Code.Models.UserModel;
public class Login{
    public string UserName{get;set;}
    public string Password{get;set;}
    public Login(string userName, string password){
        this.UserName = userName;
        this.Password = password;
    }
}